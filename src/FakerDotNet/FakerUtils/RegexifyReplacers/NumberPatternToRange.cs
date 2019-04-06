using System.Text.RegularExpressions;

namespace FakerDotNet.FakerUtils.RegexifyReplacers
{
    internal class NumberPatternToRange : IRegexifyReplacer
    {
        public string Run(string pattern)
        {
            var result = pattern;
            result = Regex.Replace(result, @"\{(\d+)\}",
                m => $@"{{\{m.Groups[1].Value}, \{m.Groups[2].Value}}}"); // All {2} become {2,2}
            result = Regex.Replace(result, @"\?", "{0,1}"); // All ? become {0,1}
            return result;
        }
    }
}
