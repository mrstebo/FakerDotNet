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
        public void Address_returns_IAddressFaker()
        {
            Assert.IsInstanceOf<IAddressFaker>(_fakerContainer.Address);
        }

        [Test]
        public void App_returns_IAppFaker()
        {
            Assert.IsInstanceOf<IAppFaker>(_fakerContainer.App);
        }

        [Test]
        public void Beer_returns_IBeerFaker()
        {
            Assert.IsInstanceOf<IBeerFaker>(_fakerContainer.Beer);
        }

        [Test]
        public void Book_returns_IBookFaker()
        {
            Assert.IsInstanceOf<IBookFaker>(_fakerContainer.Book);
        }

        [Test]
        public void Boolean_returns_IBooleanFaker()
        {
            Assert.IsInstanceOf<IBooleanFaker>(_fakerContainer.Boolean);
        }

        [Test]
        public void Business_returns_IBusinessFaker()
        {
            Assert.IsInstanceOf<IBusinessFaker>(_fakerContainer.Business);
        }

        [Test]
        public void Color_returns_IColorFaker()
        {
            Assert.IsInstanceOf<IColorFaker>(_fakerContainer.Color);
        }

        [Test]
        public void Company_returns_ICompanyFaker()
        {
            Assert.IsInstanceOf<ICompanyFaker>(_fakerContainer.Company);
        }

        [Test]
        public void Date_returns_IDateFaker()
        {
            Assert.IsInstanceOf<IDateFaker>(_fakerContainer.Date);
        }

        [Test]
        public void Fake_returns_IFakeFaker()
        {
            Assert.IsInstanceOf<IFakeFaker>(_fakerContainer.Fake);
        }

        [Test]
        public void Friends_returns_IFriendsFaker()
        {
            Assert.IsInstanceOf<IFriendsFaker>(_fakerContainer.Friends);
        }

        [Test]
        public void Lorem_returns_ILoremFaker()
        {
            Assert.IsInstanceOf<ILoremFaker>(_fakerContainer.Lorem);
        }

        [Test]
        public void Name_returns_INameFaker()
        {
            Assert.IsInstanceOf<INameFaker>(_fakerContainer.Name);
        }

        [Test]
        public void Number_returns_INumberFaker()
        {
            Assert.IsInstanceOf<INumberFaker>(_fakerContainer.Number);
        }

        [Test]
        public void Pokemon_returns_IPokemonFaker()
        {
            Assert.IsInstanceOf<IPokemonFaker>(_fakerContainer.Pokemon);
        }

        [Test]
        public void Random_returns_IRandomFaker()
        {
            Assert.IsInstanceOf<IRandomFaker>(_fakerContainer.Random);
        }

        [Test]
        public void RockBand_returns_IRockBandFaker()
        {
            Assert.IsInstanceOf<IRockBandFaker>(_fakerContainer.RockBand);
        }

        [Test]
        public void Time_returns_ITimeFaker()
        {
            Assert.IsInstanceOf<ITimeFaker>(_fakerContainer.Time);
        }

        [Test]
        public void University_returns_IUniversityFaker()
        {
            Assert.IsInstanceOf<IUniversityFaker>(_fakerContainer.University);
        }

        [Test]
        public void Zelda_returns_IZeldaFaker()
        {
            Assert.IsInstanceOf<IZeldaFaker>(_fakerContainer.Zelda);
        }
    }
}
