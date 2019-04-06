using System.Text.RegularExpressions;

namespace FakerDotNet.FakerUtils.RegexifyReplacers
{
    internal class DitchAnchors : IRegexifyReplacer
    {
        public string Run(string pattern)
        {
            var result = pattern;
            result = Regex.Replace(result, @"^\/?\^?", "");
            result = Regex.Replace(result, @"\$\/?$", "");
            return result;
        }
    }
}
