using System.Linq;
using System.Text.RegularExpressions;

namespace FakerDotNet.FakerUtils.RegexifyParsers
{
    internal class ParseRanges : IRegexifyParser
    {
        private readonly IFakerContainer _fakerContainer;

        public ParseRanges(IFakerContainer fakerContainer)
        {
            _fakerContainer = fakerContainer;
        }
        
        public string Run(string pattern)
        {
            var rangeEvaluator = GetRangeEvaluator();
            var copyEvaluator = GetCopyEvaluator();
            
            var result = pattern;
            result = Regex.Replace(result, @"(\[[^\]]+\])\{(\d+),(\d+)\}", rangeEvaluator); // [12]{1,2} becomes [12] or [12][12]
            result = Regex.Replace(result, @"(\([^\)]+\))\{(\d+),(\d+)\}", rangeEvaluator); // (12|34){1,2} becomes (12|34) or (12|34)(12|34)
            result = Regex.Replace(result, @"(\\?.)\{(\d+),(\d+)\}", rangeEvaluator); // A{1,2} becomes A or AA
            result = Regex.Replace(result, @"(\\?.)\{(\d+)\}", copyEvaluator); // \d{3} becomes \d\d\d
            return result;
        }

        private MatchEvaluator GetRangeEvaluator()
        {
            return m =>
            {
                var value = m.Groups[1].Value;
                var min = int.Parse(m.Groups[2].Value);
                var max = int.Parse(m.Groups[3].Value);
                var values = Enumerable
                    .Range(0, (int) _fakerContainer.Number.Between(min, max))
                    .Select(_ => value);
                return string.Join("", values);
            };
        }

        private static MatchEvaluator GetCopyEvaluator()
        {
            return m =>
            {
                var value = m.Groups[1].Value;
                var count = int.Parse(m.Groups[2].Value);
                var values = Enumerable
                    .Range(0, count)
                    .Select(_ => value);
                return string.Join("", values);
            };
        }
    }
}
