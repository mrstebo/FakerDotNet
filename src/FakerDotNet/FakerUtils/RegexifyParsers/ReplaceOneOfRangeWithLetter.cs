using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace FakerDotNet.FakerUtils.RegexifyParsers
{
    internal class ReplaceOneOfRangeWithLetter : IRegexifyParser
    {
        private readonly IFakerContainer _fakerContainer;

        public ReplaceOneOfRangeWithLetter(IFakerContainer fakerContainer)
        {
            _fakerContainer = fakerContainer;
        }

        public string Run(string pattern)
        {
            return Regex.Replace(pattern, @"\[([^\]]+)\]", m =>
            {
                return Regex.Replace(m.Value, @"(\w\-\w)", range =>
                {
                    var v = range.Value.Split('-');
                    var min = v[0];
                    var max = v[1];
                    var elements = BuildRange(min, max);
                    return _fakerContainer.Random.Element(elements);
                });
            }); // All A-Z inside of [] become C (or X, or whatever)
        }
        
        private static IEnumerable<string> BuildRange(string min, string max)
        {
            var minChar = char.Parse(min);
            var maxChar = char.Parse(max);
            return Enumerable.Range(minChar, maxChar - minChar + 1)
                .Select(c => new string((char) c, 1))
                .ToArray();
        }
    }
}
