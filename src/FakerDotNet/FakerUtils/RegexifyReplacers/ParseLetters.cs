using System.Text.RegularExpressions;

namespace FakerDotNet.FakerUtils.RegexifyReplacers
{
    internal class ParseLetters : IRegexifyReplacer
    {
        private readonly IFakerContainer _fakerContainer;

        public ParseLetters(IFakerContainer fakerContainer)
        {
            _fakerContainer = fakerContainer;
        }

        public string Run(string pattern)
        {
            return Regex.Replace(pattern, @"\w", _ => _fakerContainer.Lorem.Character());
        }
    }
}
