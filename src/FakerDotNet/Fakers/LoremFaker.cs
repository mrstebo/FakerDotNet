using System.Collections.Generic;
using System.Linq;
using FakerDotNet.Data;

namespace FakerDotNet.Fakers
{
    public interface ILoremFaker
    {
        string Word();
        IEnumerable<string> Words(int num = 3, bool supplemental = false);
        string Multibyte();
        string Character();
        string Characters();
        string Sentence();
        string Sentences();
        string Paragraph();
        string Paragraphs();
        string Question();
        string Questions();
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

        public IEnumerable<string> Words(int num = 3, bool supplemental = false)
        {
            var wordList = supplemental
                ? Data.Words.Concat(Data.Supplemental)
                : Data.Words;
            return _fakerContainer.Random.Assortment(wordList, num);
        }

        public string Multibyte()
        {
            throw new System.NotImplementedException();
        }

        public string Character()
        {
            throw new System.NotImplementedException();
        }

        public string Characters()
        {
            throw new System.NotImplementedException();
        }

        public string Sentence()
        {
            throw new System.NotImplementedException();
        }

        public string Sentences()
        {
            throw new System.NotImplementedException();
        }

        public string Paragraph()
        {
            throw new System.NotImplementedException();
        }

        public string Paragraphs()
        {
            throw new System.NotImplementedException();
        }

        public string Question()
        {
            throw new System.NotImplementedException();
        }

        public string Questions()
        {
            throw new System.NotImplementedException();
        }

        public string ParagraphByChars()
        {
            throw new System.NotImplementedException();
        }
    }
}
