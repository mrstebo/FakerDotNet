using System;
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

        private PropertyInfo GetFaker(string name)
        {
            var propertyInfo = _fakerContainer.GetType().GetProperty(name);

            return propertyInfo ?? throw new FormatException($"Invalid module: {name}");
        }

        private string GetValue(PropertyInfo propertyInfo, string methodName)
        {
            var method = propertyInfo.PropertyType.GetMethod(methodName);

            if (method == null) throw new FormatException($"Invalid method: {propertyInfo.Name}.{methodName}");

            return Convert.ToString(method.Invoke(propertyInfo.GetValue(_fakerContainer, null), new object[] { }));
        }

        private static (string faker, string method) ExtractMatchDataFrom(Match match)
        {
            var className = match.Groups[1].Value;
            var methodName = match.Groups[2].Value;

            return (className, methodName);
        }
    }
}
