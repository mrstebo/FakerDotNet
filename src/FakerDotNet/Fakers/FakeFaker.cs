using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using FakerDotNet.Wrappers;

namespace FakerDotNet.Fakers
{
    public interface IFakeFaker
    {
        string F(string format);
    }

    internal class FakeFaker : IFakeFaker
    {
        private readonly IFakerContainer _fakerContainer;
        private readonly IStackTraceWrapper _stackTraceWrapper;

        public FakeFaker(IFakerContainer fakerContainer)
            : this(fakerContainer, new StackTraceWrapper())
        {
        }

        internal FakeFaker(IFakerContainer fakerContainer, IStackTraceWrapper stackTraceWrapper)
        {
            _fakerContainer = fakerContainer;
            _stackTraceWrapper = stackTraceWrapper;
        }

        public string F(string format)
        {
            if (string.IsNullOrEmpty(format)) return string.Empty;

            var calleeFaker = GetCalleeFaker();
            var result = format;
            FakerMatch match;

            while ((match = ExtractMatchFrom(calleeFaker, result)).Success)
            {
                result = Parse(result, match);
            }
            
            while ((match = ExtractMatchFrom(result)).Success)
            {
                result = Parse(result, match);
            }

            return result;
        }

        private string GetCalleeFaker()
        {
            var callee = _stackTraceWrapper.GetClassAtFrame(2) ?? "";

            return Regex.Replace(callee, @"Faker$", "");
        }

        private static FakerMatch ExtractMatchFrom(string calleeFaker, string input)
        {
            const string pattern = @"\{(\w+)\}";
            var match = Regex.Match(input, pattern);

            return match.Success
                ? new FakerMatch
                {
                    Success = true,
                    Index = match.Index,
                    Length = match.Length,
                    Name = calleeFaker,
                    Method = match.Groups[1].Value
                }
                : new FakerMatch();
        }

        private static FakerMatch ExtractMatchFrom(string input)
        {
            const string pattern = @"\{(\w+)\.(\w+)\}";
            var match = Regex.Match(input, pattern);

            return match.Success
                ? new FakerMatch
                {
                    Success = true,
                    Index = match.Index,
                    Length = match.Length,
                    Name = match.Groups[1].Value,
                    Method = match.Groups[2].Value
                }
                : new FakerMatch();
        }

        private string Parse(string input, FakerMatch match)
        {
            var faker = GetFaker(match.Name);
            var value = GetValue(faker, match.Method);
            var start = input.Substring(0, match.Index);
            var end = input.Substring(match.Index + match.Length);

            return $"{start}{value}{end}";
        }
        
        private PropertyInfo GetFaker(string name)
        {
            const BindingFlags flags = BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance;
            
            return _fakerContainer.GetType().GetProperty(name, flags)
                ?? throw new FormatException($"Invalid module: {name}");
        }

        private string GetValue(PropertyInfo propertyInfo, string methodName)
        {
            const BindingFlags flags = BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance;
            var method = propertyInfo.PropertyType.GetMethod(methodName, flags)
                ?? throw new FormatException($"Invalid method: {propertyInfo.Name}.{methodName}");
            
            var parameters = method.GetParameters().Select(DefaultValue).ToArray();
            var value = method.Invoke(propertyInfo.GetValue(_fakerContainer, null), parameters);

            return Convert.ToString(value);
        }

        private static object DefaultValue(ParameterInfo parameterInfo)
        {
            return parameterInfo.ParameterType.IsValueType
                ? Activator.CreateInstance(parameterInfo.ParameterType)
                : null;
        }

        private struct FakerMatch
        {
            public bool Success;
            public int Index;
            public int Length;
            public string Name;
            public string Method;
        }
    }
}
