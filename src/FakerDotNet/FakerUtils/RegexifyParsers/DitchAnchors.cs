using System.Text.RegularExpressions;

namespace FakerDotNet.FakerUtils.RegexifyParsers
{
    internal class DitchAnchors : IRegexifyParser
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
