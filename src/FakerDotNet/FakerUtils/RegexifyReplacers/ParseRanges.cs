using System.Linq;
using System.Text.RegularExpressions;

namespace FakerDotNet.FakerUtils.RegexifyReplacers
{
    internal class ParseRanges : IRegexifyReplacer
    {
        private readonly IFakerContainer _fakerContainer;

        public ParseRanges(IFakerContainer fakerContainer)
        {
            _fakerContainer = fakerContainer;
        }
        
        public string Run(string pattern)
        {
            var evaluator = new MatchEvaluator(m =>
            {
                var value = m.Groups[1].Value;
                var min = int.Parse(m.Groups[2].Value);
                var max = int.Parse(m.Groups[3].Value);
                var values = Enumerable
                    .Range(0, (int) _fakerContainer.Number.Between(min, max))
                    .Select(_ => value);
                return string.Join("", values);
            });
            
            var result = pattern;
            result = Regex.Replace(result, @"(\[[^\]]+\])\{(\d+),(\d+)\}", evaluator); // [12]{1,2} becomes [12] or [12][12]
            result = Regex.Replace(result, @"(\[[^\]]+\])\{(\d+),(\d+)\}", evaluator); // (12|34){1,2} becomes (12|34) or (12|34)(12|34)
            result = Regex.Replace(result, @"(\\?.)\{(\d+),(\d+)\}", evaluator); // A{1,2} becomes A or AA or \d{3} becomes \d\d\d
            return result;
        }
    }
}
