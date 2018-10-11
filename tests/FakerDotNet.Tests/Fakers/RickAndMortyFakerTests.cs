using System.Collections.Generic;
using FakeItEasy;
using FakerDotNet.Data;
using FakerDotNet.Fakers;
using NUnit.Framework;

namespace FakerDotNet.Tests.Fakers
{
    [TestFixture]
    [Parallelizable]
    public class RickAndMortyFakerTests
    {
        [SetUp]
        public void SetUp()
        {
            _fakerContainer = A.Fake<IFakerContainer>();
            _rickAndMortyFaker = new RickAndMortyFaker(_fakerContainer);
        }

        private IFakerContainer _fakerContainer;
        private IRickAndMortyFaker _rickAndMortyFaker;

        [Test]
        public void Character_returns_a_character()
        {
            A.CallTo(() => _fakerContainer.Random.Element(RickAndMortyData.Characters))
                .Returns("Rick Sanchez");

            Assert.AreEqual("Rick Sanchez", _rickAndMortyFaker.Character());
        }

        [Test]
        public void Location_returns_a_location()
        {
            A.CallTo(() => _fakerContainer.Random.Element(RickAndMortyData.Locations))
                .Returns("Dimension C-132");

            Assert.AreEqual("Dimension C-132", _rickAndMortyFaker.Location());
        }

        [Test]
        public void Quote_returns_a_quote()
        {
            A.CallTo(() => _fakerContainer.Random.Element(RickAndMortyData.Quotes))
                .Returns("Ohh yea, you gotta get schwifty.");

            Assert.AreEqual("Ohh yea, you gotta get schwifty.", _rickAndMortyFaker.Quote());
        }
    }
}
