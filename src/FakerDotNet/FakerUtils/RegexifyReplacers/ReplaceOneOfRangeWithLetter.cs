using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace FakerDotNet.FakerUtils.RegexifyReplacers
{
    internal class ReplaceOneOfRangeWithLetter : IRegexifyReplacer
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
                    return _fakerContainer.Random.Element(BuildRange(min, max));
                });
            }); // All A-Z inside of [] become C (or X, or whatever)
        }
        
        private static IEnumerable<string> BuildRange(string min, string max)
        {
            var minChar = char.Parse(min);
            var maxChar = char.Parse(max);
            return Enumerable.Range(minChar, maxChar - minChar).Select(c => c.ToString());
        }
    }
}
