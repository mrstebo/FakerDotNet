using System;
using FakeItEasy;
using FakerDotNet.Data;
using FakerDotNet.Fakers;
using NUnit.Framework;

namespace FakerDotNet.Tests.Fakers
{
    [TestFixture]
    [Parallelizable]
    public class StarWarsFakerTests
    {
        [SetUp]
        public void SetUp()
        {
            _fakerContainer = A.Fake<IFakerContainer>();
            _starwarsFaker = new StarWarsFaker(_fakerContainer);
        }

        private IFakerContainer _fakerContainer;
        private IStarWarsFaker _starwarsFaker;

        [Test]
        public void CallSquadron_returns_returns_a_call_squadron()
        {
            A.CallTo(() => _fakerContainer.Random.Element(StarWarsData.CallSquadrons))
                .Returns("Green");

            Assert.AreEqual("Green", _starwarsFaker.CallSquadron());
        }

        [Test]
        public void CallSign_returns_a_call_sign()
        {
            A.CallTo(() => _fakerContainer.Random.Element(StarWarsData.CallSquadrons))
                .Returns("Grey");
            A.CallTo(() => _fakerContainer.Random.Element(StarWarsData.CallNumbers))
                .Returns("#");
            A.CallTo(() => _fakerContainer.Number.NonZeroDigit())
                .Returns("5");

            Assert.AreEqual("Grey 5", _starwarsFaker.CallSign());
        }

        [Test]
        public void CallNumber_returns_a_call_number()
        {
            A.CallTo(() => _fakerContainer.Random.Element(StarWarsData.CallNumbers))
                .Returns("Leader");

            Assert.AreEqual("Leader", _starwarsFaker.CallNumber());
        }

        [Test]
        public void CallNumber_returns_a_numerified_call_number()
        {
            A.CallTo(() => _fakerContainer.Random.Element(StarWarsData.CallNumbers))
                .Returns("#");
            A.CallTo(() => _fakerContainer.Number.NonZeroDigit())
                .Returns("6");

            Assert.AreEqual("6", _starwarsFaker.CallNumber());
        }

        [Test]
        public void Character_returns_a_character()
        {
            A.CallTo(() => _fakerContainer.Random.Element(StarWarsData.Characters))
                .Returns("Anakin Skywalker");

            Assert.AreEqual("Anakin Skywalker", _starwarsFaker.Character());
        }

        [Test]
        public void Droid_returns_a_droid()
        {
            A.CallTo(() => _fakerContainer.Random.Element(StarWarsData.Droids))
                .Returns("C-3PO");

            Assert.AreEqual("C-3PO", _starwarsFaker.Droid());
        }

        [Test]
        public void Planet_returns_a_planet()
        {
            A.CallTo(() => _fakerContainer.Random.Element(StarWarsData.Planets))
                .Returns("Tatooine");

            Assert.AreEqual("Tatooine", _starwarsFaker.Planet());
        }

        [Test]
        public void Quote_returns_a_quote()
        {
            A.CallTo(() => _fakerContainer.Random.Element(StarWarsData.Characters))
                .Returns("Leia Organa");
            A.CallTo(() => _fakerContainer.Random.Element(StarWarsData.QuotesForCharacters["leia_organa"]))
                .Returns("Aren’t you a little short for a Stormtrooper?");

            Assert.AreEqual("Aren’t you a little short for a Stormtrooper?", _starwarsFaker.Quote());
        }

        [Test]
        public void Quote_with_character_name_returns_a_quote()
        {
            A.CallTo(() => _fakerContainer.Random.Element(StarWarsData.QuotesForCharacters["leia_organa"]))
                .Returns("Aren’t you a little short for a Stormtrooper?");

            Assert.AreEqual("Aren’t you a little short for a Stormtrooper?", _starwarsFaker.Quote("leia_organa"));
        }

        [Test]
        public void Quote_with_unrecognised_character_name_throws_ArgumentException()
        {
            var keys = string.Join(", ", StarWarsData.QuotesForCharacters.Keys);
            
            var ex = Assert.Throws<ArgumentException>(() => _starwarsFaker.Quote("bad"));
            
            Assert.That(ex.Message.StartsWith($"Character for quotes can be left blank or {keys}"));
        }

        [Test]
        public void Specie_returns_a_specie()
        {
            A.CallTo(() => _fakerContainer.Random.Element(StarWarsData.Species))
                .Returns("Gungan");

            Assert.AreEqual("Gungan", _starwarsFaker.Specie());
        }

        [Test]
        public void Vehicle_returns_a_vehicle()
        {
            A.CallTo(() => _fakerContainer.Random.Element(StarWarsData.Vehicles))
                .Returns("Sandcrawler");

            Assert.AreEqual("Sandcrawler", _starwarsFaker.Vehicle());
        }

        [Test]
        public void WookieeSentence_returns_a_wookiee_sentence()
        {
            A.CallTo(() => _fakerContainer.Number.Between(0, 10))
                .Returns(8);
            A.CallTo(() => _fakerContainer.Random.Element(StarWarsData.WookieWords))
                .ReturnsNextFromSequence("yrroonn", "ru", "ooma", "roo", "ahuma", "ur", "roooarrgh", "hnn-rowr");
            A.CallTo(() => _fakerContainer.Random.Element(StarWarsData.SentenceEndings))
                .Returns(".");

            Assert.AreEqual("Yrroonn ru ooma roo ahuma ur roooarrgh hnn-rowr.", _starwarsFaker.WookieeSentence());
        }
    }
}
