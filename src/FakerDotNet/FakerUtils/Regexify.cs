using System.Collections.Generic;
using System.Linq;
using FakerDotNet.FakerUtils.RegexifyParsers;

namespace FakerDotNet.FakerUtils
{
    internal interface IRegexify
    {
        string Parse(string pattern);
    }
    
    internal class Regexify : IRegexify
    {
        private readonly IList<IRegexifyParser> _parsers;

        public Regexify(IFakerContainer fakerContainer)
        {
            _parsers = new IRegexifyParser[]
            {
                new DitchAnchors(),
                new NumberPatternToRange(),
                new ParseRanges(fakerContainer),
                new ReplaceOneOfWordsWithWord(fakerContainer), 
                new ReplaceOneOfRangeWithLetter(fakerContainer),
                new ReplaceOneOfLettersWithLetter(fakerContainer),
                new ParseNumbers(fakerContainer),
                new ParseLetters(fakerContainer), 
            };
        }

        public string Parse(string pattern)
        {
            return _parsers.Aggregate(pattern ?? "", (result, replacer) => replacer.Run(result));
        }
    }
}
