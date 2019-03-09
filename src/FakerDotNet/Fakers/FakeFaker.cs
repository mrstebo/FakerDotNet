using System;
using System.Collections.Generic;
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
            var placeholders = GetPlaceholders(format).ToArray();
            var result = placeholders.Aggregate(format,
                (current, placeholder) => Parse(current, GetFakerMatch(calleeFaker, placeholder, current)));

            return Numerify(result);
        }

        private string GetCalleeFaker()
        {
            var callee = _stackTraceWrapper.GetClassAtFrame(2) ?? "";

            return Regex.Replace(callee, @"(Faker|FakerTests)$", "");
        }

        private static IEnumerable<string> GetPlaceholders(string input)
        {
            const string pattern = @"\{(\w+)\}|\{(\w+)\.(\w+)\}";

            return Regex.Matches(input, pattern)
                .Cast<Match>()
                .Where(x => x.Success)
                .Select(x => x.Value);
        }
        
        private static FakerMatch GetFakerMatch(string calleeFaker, string placeholder, string input)
        {
            var pattern = Regex.Escape(placeholder);
            var match = Regex.Match(input, pattern);
            
            if (!match.Success) return new FakerMatch();

            var split = match.Value.Replace("{", "").Replace("}", "").Split('.');
            var name = split.Length > 1 ? split[0] : calleeFaker;
            var method = split.Length > 1 ? split[1] : split[0];

            return new FakerMatch
            {
                Success = true,
                Index = match.Index,
                Length = match.Length,
                Name = name,
                Method = method
            };
        }

        private string Parse(string input, FakerMatch match)
        {
            try
            {
                if (!match.Success) return input;

                var faker = GetFaker(match.Name);
                var value = GetValue(faker, match.Method);
                var start = input.Substring(0, match.Index);
                var end = input.Substring(match.Index + match.Length);

                return $"{start}{value}{end}";
            }
            catch
            {
                return input;
            }
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

        private string Numerify(string input)
        {
            return Regex.Replace(input, "#", m => _fakerContainer.Number.NonZeroDigit());
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
