using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            var replacements = new Dictionary<string, string>();
            Match match;
            while ((match = Regex.Match(result, @"\{(\w+.\w+)\}")).Success)
            {
                var value = ConvertToValue(match);

                if (value == match.Value)
                {
                    var key = Guid.NewGuid().ToString("N").Substring(0, 4);
                    replacements.Add(key, value);
                    result = result.Replace(value, key);
                }
                else
                {
                    result = $"{result.Substring(0, match.Index)}{value}{result.Substring(match.Index + match.Length)}";
                }
            }

            foreach (var replacement in replacements)
            {
                result = result.Replace(replacement.Key, replacement.Value);
            }
            
            return result;
        }

        private string ConvertToValue(Match match)
        {
            var classAndMethod = match.Groups[1].Value;
            var className = classAndMethod.Split('.')[0];
            var methodName = classAndMethod.Split('.')[1];
            var propertyInfo = _fakerContainer.GetType().GetProperty(className);

            if (propertyInfo == null) return match.Value;
            
            var method = propertyInfo.PropertyType.GetMethod(methodName);

            if (method == null) return match.Value;

            return Convert.ToString(method.Invoke(propertyInfo.GetValue(_fakerContainer, null), new object[] { }));
        }
    }
}