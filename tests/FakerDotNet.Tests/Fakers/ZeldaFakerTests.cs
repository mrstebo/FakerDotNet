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
        [SetUp]
        public void SetUp()
        {
            _fakerContainer = A.Fake<IFakerContainer>();
            _zeldaFaker = new ZeldaFaker(_fakerContainer);
        }

        private IFakerContainer _fakerContainer;
        private ZeldaFaker _zeldaFaker;

        [Test]
        public void Game_returns_a_game()
        {
            A.CallTo(() => _fakerContainer.Random.Element(ZeldaData.Games))
                .Returns("Ocarina of Time");

            Assert.AreEqual("Ocarina of Time", _zeldaFaker.Game());
        }

        [Test]
        public void Character_returns_a_character()
        {
            A.CallTo(() => _fakerContainer.Random.Element(ZeldaData.Characters))
                .Returns("Guru-Guru");

            Assert.AreEqual("Guru-Guru", _zeldaFaker.Character());
        }

        [Test]
        public void Location_returns_a_location()
        {
            A.CallTo(() => _fakerContainer.Random.Element(ZeldaData.Locations))
                .Returns("Tarrey Town");

            Assert.AreEqual("Tarrey Town", _zeldaFaker.Location());
        }

        [Test]
        public void Item_returns_an_item()
        {
            A.CallTo(() => _fakerContainer.Random.Element(ZeldaData.Items))
                .Returns("Master Sword");

            Assert.AreEqual("Master Sword", _zeldaFaker.Item());
        }
    }
}
