using FakeItEasy;
using FakerDotNet.Data;
using FakerDotNet.Fakers;
using NUnit.Framework;

namespace FakerDotNet.Tests.Fakers
{
    [TestFixture]
    [Parallelizable]
    public class LordOfTheRingsFakerTests
    {
        [SetUp]
        public void SetUp()
        {
            _fakerContainer = A.Fake<IFakerContainer>();
            _lordOfTheRingsFaker = new LordOfTheRingsFaker(_fakerContainer);
        }

        private IFakerContainer _fakerContainer;
        private ILordOfTheRingsFaker _lordOfTheRingsFaker;

        [Test]
        public void Character_Returns_a_Character()
        {
            A.CallTo(() => _fakerContainer.Random.Element(LordOfTheRingsData.Characters))
                .Returns("Legolas");

            Assert.AreEqual("Legolas", _lordOfTheRingsFaker.Character());
        }

        [Test]
        public void Location_Returns_a_Location()
        {
            A.CallTo(() => _fakerContainer.Random.Element(LordOfTheRingsData.Locations))
                .Returns("Helm's Deep");

            Assert.AreEqual("Helm's Deep", _lordOfTheRingsFaker.Location());
        }
    }
}
