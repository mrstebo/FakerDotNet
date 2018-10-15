using System.Collections.Generic;
using System.Linq;
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
        string Sentence();
        IEnumerable<string> Sentences();
        string Paragraph();
        IEnumerable<string> Paragraphs();
        string Question();
        IEnumerable<string> Questions();
        string ParagraphByChars();
    }
    
    internal class LoremFaker : ILoremFaker
    {
        private static readonly LoremData Data = new LoremData();
        
        private readonly IFakerContainer _fakerContainer;

        public LoremFaker(IFakerContainer fakerContainer)
        {
            _fakerContainer = fakerContainer;
        }

        public string Word()
        {
            return _fakerContainer.Random.Element(Data.Words);
        }

        public IEnumerable<string> Words(int count = 3, bool supplemental = false)
        {
            var wordList = supplemental
                ? Data.Words.Concat(Data.Supplemental)
                : Data.Words;
            return _fakerContainer.Random.Assortment(wordList, count);
        }

        public string Multibyte()
        {
            throw new System.NotImplementedException();
        }

        public string Character()
        {
            return _fakerContainer.Random.Element(Data.Characters);
        }

        public string Characters(int count = 255)
        {
            return count > 0
                ? string.Join("", Enumerable.Range(0, count).Select(_ => Character()))
                : "";
        }

        public string Sentence()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<string> Sentences()
        {
            throw new System.NotImplementedException();
        }

        public string Paragraph()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<string> Paragraphs()
        {
            throw new System.NotImplementedException();
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
    }
}
