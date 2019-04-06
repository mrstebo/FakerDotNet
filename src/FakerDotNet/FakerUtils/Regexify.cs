using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using FakerDotNet.Extensions;

namespace FakerDotNet.FakerUtils
{
    internal interface IRegexify
    {
        string Parse(string pattern);
    }
    
    internal class Regexify : IRegexify
    {
        private readonly IFakerContainer _fakerContainer;

        public Regexify(IFakerContainer fakerContainer)
        {
            _fakerContainer = fakerContainer;
        }

        public string Parse(string pattern)
        {
            var result = pattern ?? "";
            result = DitchAnchors(result);
            result = NumberPatternToRange(result);
            result = ParseRanges(result);
            result = ReplaceOneOfWordsWithWord(result);
            result = ReplaceOneOfRangeWithLetter(result);
            result = ReplaceOneOfLettersWithLetter(result);
            result = ParseNumbers(result);
            result = ParseLetters(result);
            return result;
        }

        private static string DitchAnchors(string pattern)
        {
            var result = pattern;
            result = Regex.Replace(result, @"^\/?\^?", "");
            result = Regex.Replace(result, @"\$\/?$", "");
            return result;
        }

        private static string NumberPatternToRange(string pattern)
        {
            var result = pattern;
            result = Regex.Replace(result, @"\{(\d+)\}",
                m => $@"{{\{m.Groups[1].Value}, \{m.Groups[2].Value}}}"); // All {2} become {2,2}
            result = Regex.Replace(result, @"\?", "{0,1}"); // All ? become {0,1}
            return result;
        }

        private string ParseRanges(string pattern)
        {
            var evaluator = new MatchEvaluator(m =>
            {
                var value = m.Groups[1].Value;
                var min = int.Parse(m.Groups[2].Value);
                var max = int.Parse(m.Groups[3].Value);
                return string.Join("", Enumerable
                    .Range(min, (int) _fakerContainer.Number.Between(min, max - min))
                    .Select(_ => value));
            });
            
            var result = pattern;
            result = Regex.Replace(result, @"(\[[^\]]+\])\{(\d+),(\d+)\}", evaluator); // [12]{1,2} becomes [12] or [12][12]
            result = Regex.Replace(result, @"(\[[^\]]+\])\{(\d+),(\d+)\}", evaluator); // (12|34){1,2} becomes (12|34) or (12|34)(12|34)
            result = Regex.Replace(result, @"(\\?.)\{(\d+),(\d+)\}", evaluator); // A{1,2} becomes A or AA or \d{3} becomes \d\d\d
            return result;
        }

        private string ReplaceOneOfWordsWithWord(string pattern)
        {
            return Regex.Replace(pattern, @"\((.*?)\)", m =>
            {
                var elements = Regex.Replace(m.Value, @"[\(\)]", "").Split('|');
                return _fakerContainer.Random.Element(elements); // (this|that) becomes 'this' or 'that'
            });
        }

        private string ReplaceOneOfRangeWithLetter(string pattern)
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

        private string ReplaceOneOfLettersWithLetter(string pattern)
        {
            return Regex.Replace(pattern, @"\[([^\]]+)\]", m =>
            {
                var elements = m.Groups[1].Value.Characters();
                return _fakerContainer.Random.Element(elements);
            }); // All [ABC] become B (or A or C)
        }

        private string ParseNumbers(string pattern)
        {
            return Regex.Replace(pattern, @"\d", _ => _fakerContainer.Number.Digit());
        }

        private string ParseLetters(string pattern)
        {
            return Regex.Replace(pattern, @"\d", _ => _fakerContainer.Lorem.Character());
        }

        private static IEnumerable<string> BuildRange(string min, string max)
        {
            var minChar = char.Parse(min);
            var maxChar = char.Parse(max);
            return Enumerable.Range(minChar, maxChar - minChar).Select(c => c.ToString());
        }
    }
}
