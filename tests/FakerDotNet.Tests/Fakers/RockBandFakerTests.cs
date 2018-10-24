using FakeItEasy;
using FakerDotNet.Data;
using FakerDotNet.Fakers;
using NUnit.Framework;

namespace FakerDotNet.Tests.Fakers
{
    [TestFixture]
    [Parallelizable]
    public class RockBandFakerTests
    {
        [SetUp]
        public void SetUp()
        {
            _fakerContainer = A.Fake<IFakerContainer>();
            _rockBandFaker = new RockBandFaker(_fakerContainer);
        }

        private IFakerContainer _fakerContainer;
        private IRockBandFaker _rockBandFaker;

        [Test]
        public void Name_returns_a_name()
        {
            A.CallTo(() => _fakerContainer.Random.Element(RockBandData.Name))
                .Returns("Led Zeppelin");

            Assert.AreEqual("Led Zeppelin", _rockBandFaker.Name());
        }
    }
}
