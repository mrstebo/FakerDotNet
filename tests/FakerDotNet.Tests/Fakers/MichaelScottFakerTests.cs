using FakeItEasy;
using FakerDotNet.Data;
using FakerDotNet.Fakers;
using NUnit.Framework;

namespace FakerDotNet.Tests.Fakers
{
    [TestFixture]
    [Parallelizable]
    public class MichaelScottFakerTests
    {
        [SetUp]
        public void SetUp()
        {
            _fakerContainer = A.Fake<IFakerContainer>();
            _michaelScottFaker = new MichaelScottFaker(_fakerContainer);
        }

        private IFakerContainer _fakerContainer;
        private IMichaelScottFaker _michaelScottFaker;

        [Test]
        public void Quote_returns_a_quote()
        {
            A.CallTo(() => _fakerContainer.Random.Element(MichaelScottData.Quotes))
                .Returns("I am Beyoncé, always.");

            Assert.AreEqual("I am Beyoncé, always.", _michaelScottFaker.Quote());
        }
    }
}
