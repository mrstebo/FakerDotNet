using FakeItEasy;
using FakerDotNet.Data;
using FakerDotNet.Fakers;
using NUnit.Framework;

namespace FakerDotNet.Tests.Fakers
{
    [TestFixture]
    [Parallelizable]
    public class RuPaulFakerTests
    {
        [SetUp]
        public void SetUp()
        {
            _fakerContainer = A.Fake<IFakerContainer>();
            _ruPaulFaker = new RuPaulFaker(_fakerContainer);
        }

        private IFakerContainer _fakerContainer;
        private IRuPaulFaker _ruPaulFaker;

        [Test]
        public void Quote_returns_a_quote()
        {
            A.CallTo(() => _fakerContainer.Random.Element(RuPaulData.Quotes))
                .Returns("That's Funny, Tell Another One");

            Assert.AreEqual("That's Funny, Tell Another One", _ruPaulFaker.Quote());
        }

        [Test]
        public void Queen_returns_a_queen()
        {
            A.CallTo(() => _fakerContainer.Random.Element(RuPaulData.Queens))
                .Returns("Latrice Royale");

            Assert.AreEqual("Latrice Royale", _ruPaulFaker.Queen());
        }
    }
}
