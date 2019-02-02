using FakeItEasy;
using FakerDotNet.Data;
using FakerDotNet.Fakers;
using NUnit.Framework;

namespace FakerDotNet.Tests.Fakers
{
    [TestFixture]
    [Parallelizable]
    public class CatFakerTests
    {
        [SetUp]
        public void SetUp()
        {
            _fakerContainer = A.Fake<IFakerContainer>();
            _catFaker = new CatFaker(_fakerContainer);
        }

        private IFakerContainer _fakerContainer;
        private ICatFaker _catFaker;

        [Test]
        public void Name_returns_a_name()
        {
            A.CallTo(() => _fakerContainer.Random.Element(CatData.Names))
                .Returns("Shadow");

            Assert.AreEqual("Shadow", _catFaker.Name());
        }
        
        [Test]
        public void Breed_returns_a_breed()
        {
            A.CallTo(() => _fakerContainer.Random.Element(CatData.Breeds))
                .Returns("British Semipi-longhair");

            Assert.AreEqual("British Semipi-longhair", _catFaker.Breed());
        }
        
        [Test]
        public void Registry_returns_a_registry()
        {
            A.CallTo(() => _fakerContainer.Random.Element(CatData.Registries))
                .Returns("American Cat Fanciers Association");

            Assert.AreEqual("American Cat Fanciers Association", _catFaker.Registry());
        }
    }
}
