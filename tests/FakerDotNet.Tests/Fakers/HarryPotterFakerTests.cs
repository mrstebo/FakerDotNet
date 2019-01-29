using FakeItEasy;
using FakerDotNet.Data;
using FakerDotNet.Fakers;
using NUnit.Framework;

namespace FakerDotNet.Tests.Fakers
{
    [TestFixture]
    [Parallelizable]
    public class HarryPotterFakerTests
    {
        [SetUp]
        public void SetUp()
        {
            _fakerContainer = A.Fake<IFakerContainer>();
            _harrypotterFaker = new HarryPotterFaker(_fakerContainer);
        }

        private IFakerContainer _fakerContainer;
        private IHarryPotterFaker _harrypotterFaker;

        [Test]
        public void Character_returns_a_character()
        {
            A.CallTo(() => _fakerContainer.Random.Element(HarryPotterData.Characters))
                .Returns("Harry Potter");

            Assert.AreEqual("Harry Potter", _harrypotterFaker.Character());
        }

        [Test]
        public void Location_returns_a_location()
        {
            A.CallTo(() => _fakerContainer.Random.Element(HarryPotterData.Locations))
                .Returns("Hogwarts");

            Assert.AreEqual("Hogwarts", _harrypotterFaker.Location());
        }

        [Test]
        public void Quote_returns_a_quote()
        {
            A.CallTo(() => _fakerContainer.Random.Element(HarryPotterData.Quotes))
                .Returns("I solemnly swear that I am up to no good.");

            Assert.AreEqual("I solemnly swear that I am up to no good.", _harrypotterFaker.Quote());
        }

        [Test]
        public void Book_returns_a_book()
        {
            A.CallTo(() => _fakerContainer.Random.Element(HarryPotterData.Books))
                .Returns("Harry Potter and the Chamber of Secrets");

            Assert.AreEqual("Harry Potter and the Chamber of Secrets", _harrypotterFaker.Book());
        }

        [Test]
        public void House_returns_a_house()
        {
            A.CallTo(() => _fakerContainer.Random.Element(HarryPotterData.Houses))
                .Returns("Gryffindor");

            Assert.AreEqual("Gryffindor", _harrypotterFaker.House());
        }

        [Test]
        public void Spell_returns_a_spell()
        {
            A.CallTo(() => _fakerContainer.Random.Element(HarryPotterData.Spells))
                .Returns("Reparo");

            Assert.AreEqual("Reparo", _harrypotterFaker.Spell());
        }
    }
}
