using FakeItEasy;
using FakerDotNet.Data;
using FakerDotNet.Fakers;
using NUnit.Framework;

namespace FakerDotNet.Tests.Fakers
{
    [TestFixture]
    [Parallelizable]
    public class GameOfThronesFakerTests
    {
        [SetUp]
        public void SetUp()
        {
            _fakerContainer = A.Fake<IFakerContainer>();
            _gameOfThronesFaker = new GameOfThronesFaker(_fakerContainer);
        }

        private IFakerContainer _fakerContainer;
        private GameOfThronesFaker _gameOfThronesFaker;

        [Test]
        public void Character_returns_a_character()
        {
            A.CallTo(() => _fakerContainer.Random.Element(GameOfThronesData.Characters))
                .Returns("Addam Velaryon");

            Assert.AreEqual("Addam Velaryon", _gameOfThronesFaker.Character());
        }

        [Test]
        public void House_returns_a_house()
        {
            A.CallTo(() => _fakerContainer.Random.Element(GameOfThronesData.Houses))
                .Returns("Breakstone");

            Assert.AreEqual("Breakstone", _gameOfThronesFaker.House());
        }

        [Test]
        public void City_returns_a_city()
        {
            A.CallTo(() => _fakerContainer.Random.Element(GameOfThronesData.Cities))
                .Returns("Meereen");

            Assert.AreEqual("Meereen", _gameOfThronesFaker.City());
        }

        [Test]
        public void Quote_returns_a_quote()
        {
            A.CallTo(() => _fakerContainer.Random.Element(GameOfThronesData.Quotes))
                .Returns("Once you’ve accepted your flaws, no one can use them against you.");

            Assert.AreEqual("Once you’ve accepted your flaws, no one can use them against you.", _gameOfThronesFaker.Quote());
        }

        [Test]
        public void Dragon_returns_a_dragon()
        {
            A.CallTo(() => _fakerContainer.Random.Element(GameOfThronesData.Dragons))
                .Returns("Caraxes");

            Assert.AreEqual("Caraxes", _gameOfThronesFaker.Dragon());
        }
    }
}
