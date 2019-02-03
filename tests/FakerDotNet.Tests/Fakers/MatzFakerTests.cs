using FakeItEasy;
using FakerDotNet.Data;
using FakerDotNet.Fakers;
using NUnit.Framework;

namespace FakerDotNet.Tests.Fakers
{
    [TestFixture]
    [Parallelizable]
    public class MatzFakerTests
    {
        [SetUp]
        public void SetUp()
        {
            _fakerContainer = A.Fake<IFakerContainer>();
            _matzFaker = new MatzFaker(_fakerContainer);
        }

        private IFakerContainer _fakerContainer;
        private IMatzFaker _matzFaker;

        [Test]
        public void Quote_returns_a_quote()
        {
            const string quote =
                "You want to enjoy life, don't you? If you get your job done quickly and your job is fun, that's good isn't it? That's the purpose of life, partly. Your life is better.";
            
            A.CallTo(() => _fakerContainer.Random.Element(MatzData.Quotes))
                .Returns(quote);

            Assert.AreEqual(quote, _matzFaker.Quote());
        }
    }
}
