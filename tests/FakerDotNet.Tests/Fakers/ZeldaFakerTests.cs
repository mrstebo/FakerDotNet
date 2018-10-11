using FakeItEasy;
using FakerDotNet.Data;
using FakerDotNet.Fakers;
using NUnit.Framework;
using System.Collections.Generic;

namespace FakerDotNet.Tests.Fakers
{
    [TestFixture]
    [Parallelizable]
    public class ZeldaFakerTests
    {
        private IFakerContainer _fakerContainer;
        private ZeldaFaker _zeldaFaker;
        private static readonly ZeldaData Data = new ZeldaData();

        [SetUp]
        public void SetUp()
        {
            _fakerContainer = A.Fake<IFakerContainer>();
            _zeldaFaker = new ZeldaFaker(_fakerContainer);
        }

        [Test]
        public void Game_returns_a_game()
        {
            string gameTitle = "Ocarina of Time";
            A.CallTo(() => _fakerContainer.Random.Element(A<IEnumerable<string>>.That.IsSameSequenceAs(Data.Games)))
                .Returns(gameTitle);

            Assert.AreEqual(gameTitle, _zeldaFaker.Game());
        }

        [Test]
        public void Character_returns_a_character()
        {
            string character = "Guru-Guru";
            A.CallTo(() => _fakerContainer.Random.Element(A<IEnumerable<string>>.That.IsSameSequenceAs(Data.Characters)))
                .Returns(character);

            Assert.AreEqual(character, _zeldaFaker.Character());
        }

        [Test]
        public void Location_returns_a_location()
        {
            string location = "Tarrey Town";
            A.CallTo(() => _fakerContainer.Random.Element(A<IEnumerable<string>>.That.IsSameSequenceAs(Data.Locations)))
                .Returns(location);

            Assert.AreEqual(location, _zeldaFaker.Location());
        }

        [Test]
        public void Item_returns_an_item()
        {
            string item = "Master Sword";
            A.CallTo(() => _fakerContainer.Random.Element(A<IEnumerable<string>>.That.IsSameSequenceAs(Data.Items)))
                .Returns(item);

            Assert.AreEqual(item, _zeldaFaker.Item());
        }
    }
}
