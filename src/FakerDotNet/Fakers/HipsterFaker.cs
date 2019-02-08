using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
                ? HipsterData.Words.Concat(HipsterData.Supplemental)
                : HipsterData.Words;

            if (!spacesAllowed) wordList = wordList.Where(word => !word.Contains(" "));

            return _fakerContainer.Random.Assortment(wordList, count);
        }

        public string Sentence(int wordCount = 4, bool supplemental = false, int randomWordsToAdd = 6)
        {
            var count = wordCount + (int) _fakerContainer.Number.Between(0, randomWordsToAdd);
            var text = Capitalize(string.Join(" ", Words(count, supplemental)));
            return text.Length > 0 ? $"{text}." : "";
        }

        public IEnumerable<string> Sentences(int sentenceCount = 3, bool supplemental = false)
        {
            return sentenceCount > 0
                ? Enumerable.Range(0, sentenceCount).Select(_ => Sentence(3, supplemental))
                : Enumerable.Empty<string>();
        }

        public string Paragraph(int sentenceCount = 3, bool supplemental = false, int randomSentencesToAdd = 3)
        {
            var count = sentenceCount + (int) _fakerContainer.Number.Between(0, randomSentencesToAdd);
            return string.Join(" ", Sentences(count, supplemental));
        }

        public IEnumerable<string> Paragraphs(int paragraphCount = 3, bool supplemental = false)
        {
            return paragraphCount > 0
                ? Enumerable.Range(0, paragraphCount).Select(_ => Paragraph(3, supplemental))
                : Enumerable.Empty<string>();
        }

        public string ParagraphByChars(int chars = 256, bool supplemental = false)
        {
            var paragraph = "";

            do
            {
                paragraph += $"{Paragraph(3, supplemental)} ";
            } while (paragraph.Length < chars);

            return $"{paragraph.Trim().Substring(0, chars - 1)}.";
        }
        
        private static string Capitalize(string text)
        {
            return Regex.Replace(text, @"^\w", m => m.Value.ToUpperInvariant());
        }
    }
}
        
