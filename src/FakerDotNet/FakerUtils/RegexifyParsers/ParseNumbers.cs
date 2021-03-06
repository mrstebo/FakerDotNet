using System.Text.RegularExpressions;

namespace FakerDotNet.FakerUtils.RegexifyParsers
{
    internal class ParseNumbers : IRegexifyParser
    {
        private readonly IFakerContainer _fakerContainer;

        public ParseNumbers(IFakerContainer fakerContainer)
        {
            _fakerContainer = fakerContainer;
        }

        public string Run(string pattern)
        {
            return Regex.Replace(pattern, @"\\d", _ => _fakerContainer.Number.Digit());
        }
    }
}
