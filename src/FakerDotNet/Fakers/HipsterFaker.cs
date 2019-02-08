using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using FakerDotNet.Data;

namespace FakerDotNet.Fakers
{
    public interface IHipsterFaker
    {
        string Word();
        IEnumerable<string> Words(int count = 3, bool supplemental = false, bool spacesAllowed = false);
        string Sentence(int wordCount = 4, bool supplemental = false, int randomWordsToAdd = 6);
        IEnumerable<string> Sentences(int sentenceCount = 3, bool supplemental = false);
        string Paragraph(int sentenceCount = 3, bool supplemental = false, int randomSentencesToAdd = 3);
        IEnumerable<string> Paragraphs(int paragraphCount = 3, bool supplemental = false);
        string ParagraphByChars(int chars = 256, bool supplemental = false);
    }

    internal class HipsterFaker : IHipsterFaker
    {
        private readonly IFakerContainer _fakerContainer;

        public HipsterFaker(IFakerContainer fakerContainer)
        {
            _fakerContainer = fakerContainer;
        }

        public string Word()
        {
            var word = _fakerContainer.Random.Element(HipsterData.Words);

            return word.Contains(" ") ? Word() : word;
        }

        public IEnumerable<string> Words(int count = 3, bool supplemental = false, bool spacesAllowed = false)
        {
            var wordList = supplemental
                ? HipsterData.Words.Concat(LoremData.Supplemental)
                : HipsterData.Words;

            if (!spacesAllowed) wordList = wordList.Where(word => !word.Contains(" "));

            return _fakerContainer.Random.Assortment(wordList, count);
        }

        public string Sentence(int wordCount = 4, bool supplemental = false, int randomWordsToAdd = 6)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> Sentences(int sentenceCount = 3, bool supplemental = false)
        {
            throw new NotImplementedException();
        }

        public string Paragraph(int sentenceCount = 3, bool supplemental = false, int randomSentencesToAdd = 3)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> Paragraphs(int paragraphCount = 3, bool supplemental = false)
        {
            throw new NotImplementedException();
        }

        public string ParagraphByChars(int chars = 256, bool supplemental = false)
        {
            throw new NotImplementedException();
        }
    }
}
        
