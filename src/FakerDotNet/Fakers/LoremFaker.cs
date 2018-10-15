using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using FakerDotNet.Data;

namespace FakerDotNet.Fakers
{
    public interface ILoremFaker
    {
        string Word();
        IEnumerable<string> Words(int count = 3, bool supplemental = false);
        string Multibyte();
        string Character();
        string Characters(int count = 255);
        string Sentence(int words = 4, bool supplemental = false, int randomWordsToAdd = 6);
        IEnumerable<string> Sentences(int count = 3, bool supplemental = false);
        string Paragraph(int sentences = 3, bool supplemental = false, int randomSentencesToAdd = 3);
        IEnumerable<string> Paragraphs(int count = 3, bool supplemental = false);
        string Question();
        IEnumerable<string> Questions();
        string ParagraphByChars();
    }
    
    internal class LoremFaker : ILoremFaker
    {
        private readonly IFakerContainer _fakerContainer;

        public LoremFaker(IFakerContainer fakerContainer)
        {
            _fakerContainer = fakerContainer;
        }

        public string Word()
        {
            return _fakerContainer.Random.Element(LoremData.Words);
        }

        public IEnumerable<string> Words(int count = 3, bool supplemental = false)
        {
            var wordList = supplemental
                ? LoremData.Words.Concat(LoremData.Supplemental)
                : LoremData.Words;
            return _fakerContainer.Random.Assortment(wordList, count);
        }

        public string Multibyte()
        {
            return Encoding.UTF8.GetString(_fakerContainer.Random.Element(LoremData.Multibytes));
        }

        public string Character()
        {
            return _fakerContainer.Random.Element(LoremData.Characters);
        }

        public string Characters(int count = 255)
        {
            return count > 0
                ? string.Join("", Enumerable.Range(0, count).Select(_ => Character()))
                : "";
        }

        public string Sentence(int words = 4, bool supplemental = false, int randomWordsToAdd = 6)
        {
            var wordCount = words + (int) _fakerContainer.Number.Between(0, randomWordsToAdd);
            var text = Capitalize(string.Join(" ", Words(wordCount, supplemental)));
            return text.Length > 0 ? $"{text}." : "";
        }

        public IEnumerable<string> Sentences(int count = 3, bool supplemental = false)
        {
            return Enumerable.Range(0, count).Select(_ => Sentence(3, supplemental));
        }

        public string Paragraph(int sentences = 3, bool supplemental = false, int randomSentencesToAdd = 3)
        {
            var sentenceCount = sentences + (int) _fakerContainer.Number.Between(0, randomSentencesToAdd);
            return string.Join(" ", Sentences(sentenceCount, supplemental));
        }

        public IEnumerable<string> Paragraphs(int count = 3, bool supplemental = false)
        {
            return Enumerable.Range(0, count).Select(_ => Paragraph(3, supplemental));
        }

        public string Question()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<string> Questions()
        {
            throw new System.NotImplementedException();
        }

        public string ParagraphByChars()
        {
            throw new System.NotImplementedException();
        }

        private static string Capitalize(string text)
        {
            return Regex.Replace(text, @"^\w", m => m.Value.ToUpperInvariant());
        }
    }
}
