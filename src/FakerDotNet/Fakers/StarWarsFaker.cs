using System;
using System.Linq;
using System.Text.RegularExpressions;
using FakerDotNet.Data;

namespace FakerDotNet.Fakers
{
    public interface IStarWarsFaker
    {
        string CallSquadron();
        string CallSign();
        string CallNumber();
        string Character();
        string Droid();
        string Planet();
        string Quote(string character = "");
        string Specie();
        string Vehicle();
        string WookieeSentence();
    }

    internal class StarWarsFaker : IStarWarsFaker
    {
        private readonly IFakerContainer _fakerContainer;

        public StarWarsFaker(IFakerContainer fakerContainer)
        {
            _fakerContainer = fakerContainer;
        }

        public string CallSquadron()
        {
            return _fakerContainer.Random.Element(StarWarsData.CallSquadrons);
        }

        public string CallSign()
        {
            return $"{CallSquadron()} {CallNumber()}";
        }

        public string CallNumber()
        {
            var callNumber = _fakerContainer.Random.Element(StarWarsData.CallNumbers);

            return Numerify(callNumber);
        }

        public string Character()
        {
            return _fakerContainer.Random.Element(StarWarsData.Characters);
        }

        public string Droid()
        {
            return _fakerContainer.Random.Element(StarWarsData.Droids);
        }

        public string Planet()
        {
            return _fakerContainer.Random.Element(StarWarsData.Planets);
        }

        public string Quote(string character = "")
        {
            var key = (string.IsNullOrEmpty(character) ? Character() : character)
                .ToLowerInvariant()
                .Replace(" ", "_");

            if (!StarWarsData.QuotesForCharacters.ContainsKey(key))
            {
                var keys = string.Join(", ", StarWarsData.QuotesForCharacters.Keys);
                throw new ArgumentException($"Character for quotes can be left blank or {keys}");
            }

            var quotes = StarWarsData.QuotesForCharacters[key];

            return _fakerContainer.Random.Element(quotes);
        }

        public string Specie()
        {
            return _fakerContainer.Random.Element(StarWarsData.Species);
        }

        public string Vehicle()
        {
            return _fakerContainer.Random.Element(StarWarsData.Vehicles);
        }

        public string WookieeSentence()
        {
            var numberOfWords = (int) _fakerContainer.Number.Between(0, 10);
            var words = Enumerable.Range(0, numberOfWords)
                .Select(_ => _fakerContainer.Random.Element(StarWarsData.WookieWords))
                .ToArray();
            var ending = _fakerContainer.Random.Element(StarWarsData.SentenceEndings);
            var sentence = string.Join(" ", words) + ending;

            return Capitalize(sentence);
        }

        private string Numerify(string text)
        {
            return Regex.Replace(text, "#", m => _fakerContainer.Number.NonZeroDigit());
        }

        private static string Capitalize(string text)
        {
            return Regex.Replace(text, "^(.)", m => m.Value.ToUpperInvariant());
        }
    }
}
