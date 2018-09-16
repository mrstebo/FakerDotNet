using FakerDotNet.Fakers;
using NUnit.Framework;

namespace FakerDotNet.Tests
{
    [TestFixture]
    [Parallelizable]
    public class FakerTests
    {
        [SetUp]
        public void SetUp()
        {
            _faker = new Faker();
        }

        private IFaker _faker;

        [Test]
        public void Name_returns_INameFaker()
        {
            Assert.IsInstanceOf<INameFaker>(_faker.Name);
        }

        [Test]
        public void Random_returns_IRandomFaker()
        {
            Assert.IsInstanceOf<IRandomFaker>(_faker.Random);
        }
    }
}
