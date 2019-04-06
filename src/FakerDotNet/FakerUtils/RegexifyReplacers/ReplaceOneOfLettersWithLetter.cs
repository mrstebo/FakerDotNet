using System.Text.RegularExpressions;
using FakerDotNet.Extensions;

namespace FakerDotNet.FakerUtils.RegexifyReplacers
{
    internal class ReplaceOneOfLettersWithLetter : IRegexifyReplacer
    {
        private readonly IFakerContainer _fakerContainer;

        public ReplaceOneOfLettersWithLetter(IFakerContainer fakerContainer)
        {
            _fakerContainer = fakerContainer;
        }

        public string Run(string pattern)
        {
            return Regex.Replace(pattern, @"\[([^\]]+)\]", m =>
            {
                var elements = m.Groups[1].Value.Characters();
                return _fakerContainer.Random.Element(elements);
            }); // All [ABC] become B (or A or C)
        }
    }
}
