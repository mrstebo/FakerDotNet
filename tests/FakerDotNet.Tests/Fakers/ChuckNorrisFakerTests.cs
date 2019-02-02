using FakeItEasy;
using FakerDotNet.Data;
using FakerDotNet.Fakers;
using NUnit.Framework;

namespace FakerDotNet.Tests.Fakers
{
    [TestFixture]
    [Parallelizable]
    public class ChuckNorrisFakerTests
    {
        [SetUp]
        public void SetUp()
        {
            _fakerContainer = A.Fake<IFakerContainer>();
            _chuckNorrisFaker = new ChuckNorrisFaker(_fakerContainer);
        }

        private IFakerContainer _fakerContainer;
        private IChuckNorrisFaker _chuckNorrisFaker;

        [Test]
        public void Fact_returns_a_fact()
        {
            A.CallTo(() => _fakerContainer.Random.Element(ChuckNorrisData.Facts))
                .Returns("Chuck Norris can solve the Towers of Hanoi in one move.");

            Assert.AreEqual("Chuck Norris can solve the Towers of Hanoi in one move.", _chuckNorrisFaker.Fact());
        }
    }
}
