using FakeItEasy;
using FakerDotNet.Data;
using FakerDotNet.Fakers;
using NUnit.Framework;

namespace FakerDotNet.Tests.Fakers
{
    [TestFixture]
    [Parallelizable]
    public class HackerFakerTests
    {
        [SetUp]
        public void SetUp()
        {
            _fakerContainer = A.Fake<IFakerContainer>();
            _hackerFaker = new HackerFaker(_fakerContainer);
            
            A.CallTo(() => _fakerContainer.Fake).Returns(new FakeFaker(_fakerContainer));
        }

        private IFakerContainer _fakerContainer;
        private IHackerFaker _hackerFaker;

        [Test]
        public void SaySomethingSmart_returns_something_smart()
        {
            A.CallTo(() => _fakerContainer.Random.Element(HackerData.Phrases))
                .Returns("Try to {Verb} the {Abbreviation} {Noun}, maybe it will {Verb} the {Adjective} {Noun}!");
            A.CallTo(() => _fakerContainer.Hacker.Verb())
                .ReturnsNextFromSequence("compress", "program");
            A.CallTo(() => _fakerContainer.Hacker.Abbreviation())
                .Returns("SQL");
            A.CallTo(() => _fakerContainer.Hacker.Noun())
                .ReturnsNextFromSequence("interface", "hard drive");
            A.CallTo(() => _fakerContainer.Hacker.Adjective())
                .Returns("back-end");
            
            Assert.AreEqual(
                "Try to compress the SQL interface, maybe it will program the back-end hard drive!",
                _hackerFaker.SaySomethingSmart());
        }
        
        [Test]
        public void Abbreviation_returns_an_abbreviation()
        {
            A.CallTo(() => _fakerContainer.Random.Element(HackerData.Abbreviations))
                .Returns("RAM");
            
            Assert.AreEqual("RAM", _hackerFaker.Abbreviation());
        }

        [Test]
        public void Adjective_returns_an_adjective()
        {
            A.CallTo(() => _fakerContainer.Random.Element(HackerData.Adjectives))
                .Returns("open-source");
            
            Assert.AreEqual("open-source", _hackerFaker.Adjective());
        }

        [Test]
        public void Noun_returns_a_noun()
        {
            A.CallTo(() => _fakerContainer.Random.Element(HackerData.Nouns))
                .Returns("bandwidth");
            
            Assert.AreEqual("bandwidth", _hackerFaker.Noun());
        }

        [Test]
        public void Verb_returns_a_verb()
        {
            A.CallTo(() => _fakerContainer.Random.Element(HackerData.Verbs))
                .Returns("bypass");
            
            Assert.AreEqual("bypass", _hackerFaker.Verb());
        }

        [Test]
        public void Ingverb_returns_an_ing_ending_verb()
        {
            A.CallTo(() => _fakerContainer.Random.Element(HackerData.Ingverbs))
                .Returns("synthesizing");
            
            Assert.AreEqual("synthesizing", _hackerFaker.Ingverb());
        }
    }
}
