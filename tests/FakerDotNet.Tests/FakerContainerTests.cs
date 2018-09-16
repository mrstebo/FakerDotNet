using FakerDotNet.Fakers;
using NUnit.Framework;

namespace FakerDotNet.Tests
{
    [TestFixture]
    [Parallelizable]
    public class FakerContainerTests
    {
        [SetUp]
        public void SetUp()
        {
            _fakerContainer = new FakerContainer();
        }

        private IFakerContainer _fakerContainer;

        [Test]
        public void Name_returns_INameFaker()
        {
            Assert.IsInstanceOf<INameFaker>(_fakerContainer.Name);
        }

        [Test]
        public void Random_returns_IRandomFaker()
        {
            Assert.IsInstanceOf<IRandomFaker>(_fakerContainer.Random);
        }
    }
}
