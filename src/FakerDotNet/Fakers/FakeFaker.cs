using System;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace FakerDotNet.Fakers
{
    public interface IFakeFaker
    {
        string F(string format);
    }

    internal class FakeFaker : IFakeFaker
    {
        private readonly IFakerContainer _fakerContainer;

        public FakeFaker(IFakerContainer fakerContainer)
        {
            _fakerContainer = fakerContainer;
        }

        public string F(string format)
        {
            if (string.IsNullOrEmpty(format)) return string.Empty;

            var result = format;
            FakerMatch match;
            while ((match = ExtractMatchFrom(result)).Success)
            {
                var faker = GetFaker(match.Name);
                var value = GetValue(faker, match.Method);
                var start = result.Substring(0, match.Index);
                var end = result.Substring(match.Index + match.Length);

                result = $"{start}{value}{end}";
            }

            return result;
        }

        private static FakerMatch ExtractMatchFrom(string input)
        {
            const string pattern = @"\{(\w+).(\w+)\}";
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

        private PropertyInfo GetFaker(string name)
        {
            var propertyInfo = _fakerContainer.GetType()
                .GetProperty(name, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

            return propertyInfo ?? throw new FormatException($"Invalid module: {name}");
        }

        private string GetValue(PropertyInfo propertyInfo, string methodName)
        {
            var method = propertyInfo.PropertyType
                .GetMethod(methodName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

            if (method == null) throw new FormatException($"Invalid method: {propertyInfo.Name}.{methodName}");

            var parameters = method.GetParameters().Select(DefaultValue).ToArray();

            return Convert.ToString(method.Invoke(propertyInfo.GetValue(_fakerContainer, null), parameters));
        }

        private static object DefaultValue(ParameterInfo parameterInfo)
        {
            return parameterInfo.ParameterType.IsValueType
                ? Activator.CreateInstance(parameterInfo.ParameterType)
                : null;
        }

        struct FakerMatch
        {
            public bool Success;
            public int Index;
            public int Length;
            public string Name;
            public string Method;
        }
    }
}
