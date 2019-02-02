using FakeItEasy;
using FakerDotNet.Data;
using FakerDotNet.Fakers;
using NUnit.Framework;

namespace FakerDotNet.Tests.Fakers
{
    [TestFixture]
    [Parallelizable]
    public class AncientFakerTests
    {
        [SetUp]
        public void SetUp()
        {
            _fakerContainer = A.Fake<IFakerContainer>();
            _ancientFaker = new AncientFaker(_fakerContainer);
        }

        private IFakerContainer _fakerContainer;
        private IAncientFaker _ancientFaker;

        [Test]
        public void God_returns_a_god()
        {
            A.CallTo(() => _fakerContainer.Random.Element(AncientData.Gods))
                .Returns("Zeus");

            Assert.AreEqual("Zeus", _ancientFaker.God());
        }

        [Test]
        public void Primordial_returns_a_primordial()
        {
            A.CallTo(() => _fakerContainer.Random.Element(AncientData.Primordials))
                .Returns("Gaia");

            Assert.AreEqual("Gaia", _ancientFaker.Primordial());
        }

        [Test]
        public void Titan_returns_a_titan()
        {
            A.CallTo(() => _fakerContainer.Random.Element(AncientData.Titans))
                .Returns("Atlas");

            Assert.AreEqual("Atlas", _ancientFaker.Titan());
        }

        [Test]
        public void Hero_returns_a_hero()
        {
            A.CallTo(() => _fakerContainer.Random.Element(AncientData.Heroes))
                .Returns("Achilles");

            Assert.AreEqual("Achilles", _ancientFaker.Hero());
        }
    }
}
