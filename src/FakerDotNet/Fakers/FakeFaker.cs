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
            if (string.IsNullOrEmpty(format)) throw new FormatException("A string must be specified");

            var result = format;
            Match match;
            while ((match = Regex.Match(result, @"\{(\w+).(\w+)\}")).Success)
            {
                var matchData = ExtractMatchDataFrom(match);
                var faker = GetFaker(matchData.faker);
                var value = GetValue(faker, matchData.method);

                result = $"{result.Substring(0, match.Index)}{value}{result.Substring(match.Index + match.Length)}";
            }

            return result;
        }
        
        private static (string faker, string method) ExtractMatchDataFrom(Match match)
        {
            var className = match.Groups[1].Value;
            var methodName = match.Groups[2].Value;

            return (className, methodName);
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
    }
}
