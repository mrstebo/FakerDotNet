using System.Collections.Generic;
using System.Linq;
using FakerDotNet.FakerUtils.RegexifyReplacers;

namespace FakerDotNet.FakerUtils
{
    internal interface IRegexify
    {
        string Parse(string pattern);
    }
    
    internal class Regexify : IRegexify
    {
        private readonly IList<IRegexifyReplacer> _regexifyReplacers;

        public Regexify(IFakerContainer fakerContainer)
        {
            _regexifyReplacers = new IRegexifyReplacer[]
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
            return _regexifyReplacers.Aggregate(pattern ?? "", (result, replacer) => replacer.Run(result));
        }
    }
}
