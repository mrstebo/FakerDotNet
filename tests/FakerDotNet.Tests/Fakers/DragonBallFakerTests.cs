using FakeItEasy;
using FakerDotNet.Data;
using FakerDotNet.Fakers;
using NUnit.Framework;

namespace FakerDotNet.Tests.Fakers
{
    [TestFixture]
    [Parallelizable]
    public class DragonBallFakerTests
    {
        [SetUp]
        public void SetUp()
        {
            _fakerContainer = A.Fake<IFakerContainer>();
            _dragonBallFaker = new DragonBallFaker(_fakerContainer);
        }

        private IFakerContainer _fakerContainer;
        private IDragonBallFaker _dragonBallFaker;

        [Test]
        public void Character_returns_a_character()
        {
            A.CallTo(() => _fakerContainer.Random.Element(DragonBallData.Characters))
                .Returns("Kid Trunks");

            Assert.AreEqual("Kid Trunks", _dragonBallFaker.Character());
        }
    }
}
