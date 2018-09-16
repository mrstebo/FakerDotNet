using NUnit.Framework;

namespace FakerDotNet.Tests
{
    [TestFixture]
    [Parallelizable]
    public class FakerFactoryTests
    {
        [Test]
        public void Create_returns_IFaker()
        {
            Assert.IsInstanceOf<IFaker>(FakerFactory.Create());
        }
    }
}