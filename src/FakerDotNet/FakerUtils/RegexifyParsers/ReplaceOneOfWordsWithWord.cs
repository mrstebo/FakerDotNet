using System.Text.RegularExpressions;

namespace FakerDotNet.FakerUtils.RegexifyParsers
{
    internal class ReplaceOneOfWordsWithWord : IRegexifyParser
    {
        private readonly IFakerContainer _fakerContainer;

        public ReplaceOneOfWordsWithWord(IFakerContainer fakerContainer)
        {
            _fakerContainer = fakerContainer;
        }
        
        public string Run(string pattern)
        {
            return Regex.Replace(pattern, @"\((.*?)\)", m =>
            {
                var elements = Regex.Replace(m.Value, @"[\(\)]", "").Split('|');
                return _fakerContainer.Random.Element(elements); // (this|that) becomes 'this' or 'that'
            });
        }
    }
}
