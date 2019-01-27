using System.Text.RegularExpressions;
using FakerDotNet.Data;

namespace FakerDotNet.Fakers
{
    public interface IHackerFaker
    {
        string SaySomethingSmart();
        string Abbreviation();
        string Adjective();
        string Noun();
        string Verb();
        string Ingverb();
    }
    
    internal class HackerFaker : IHackerFaker
    {
        private readonly IFakerContainer _fakerContainer;

        public HackerFaker(IFakerContainer fakerContainer)
        {
            _fakerContainer = fakerContainer;
        }

        public string SaySomethingSmart()
        {
            return Parse(_fakerContainer.Random.Element(HackerData.Phrases));
        }

        public string Abbreviation()
        {
            return _fakerContainer.Random.Element(HackerData.Abbreviations);
        }

        public string Adjective()
        {
            return _fakerContainer.Random.Element(HackerData.Adjectives);
        }

        public string Noun()
        {
            return _fakerContainer.Random.Element(HackerData.Nouns);
        }

        public string Verb()
        {
            return _fakerContainer.Random.Element(HackerData.Verbs);
        }

        public string Ingverb()
        {
            return _fakerContainer.Random.Element(HackerData.Ingverbs);
        }
        
        private string Parse(string format)
        {
            var text = Regex.Replace(format, @"\{(\w+)\}", @"{Hacker.$1}");

            return _fakerContainer.Fake.F(text);
        }
    }
}
