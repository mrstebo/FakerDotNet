using FakerDotNet.Fakers;
using NUnit.Framework;

namespace FakerDotNet.Tests
{
    [TestFixture]
    [Parallelizable]
    public class FakerTests
    {
        [Test]
        public void Address_returns_IAddressFaker()
        {
            Assert.IsInstanceOf<IAddressFaker>(Faker.Address);
        }

        [Test]
        public void App_returns_IAppFaker()
        {
            Assert.IsInstanceOf<IAppFaker>(Faker.App);
        }
        
        [Test]
        public void Book_returns_IBookFaker()
        {
            Assert.IsInstanceOf<IBookFaker>(Faker.Book);
        }
        
        [Test]
        public void Boolean_returns_IBooleanFaker()
        {
            Assert.IsInstanceOf<IBooleanFaker>(Faker.Boolean);
        }
        
        [Test]
        public void Date_returns_IDateFaker()
        {
            Assert.IsInstanceOf<IDateFaker>(Faker.Date);
        }

        [Test]
        public void Fake_returns_IFakeFaker()
        {
            Assert.IsInstanceOf<IFakeFaker>(Faker.Fake);
        }

        [Test]
        public void Friends_returns_IFriendsFaker()
        {
            Assert.IsInstanceOf<IFriendsFaker>(Faker.Friends);
        }

        [Test]
        public void Name_returns_INameFaker()
        {
            Assert.IsInstanceOf<INameFaker>(Faker.Name);
        }

        [Test]
        public void Number_returns_INumberFaker()
        {
            Assert.IsInstanceOf<INumberFaker>(Faker.Number);
        }

        [Test]
        public void Random_returns_IRandomFaker()
        {
            Assert.IsInstanceOf<IRandomFaker>(Faker.Random);
        }
        
        [Test]
        public void Time_returns_ITimeFaker()
        {
            Assert.IsInstanceOf<ITimeFaker>(Faker.Time);
        }

        [Test]
        public void Zelda_returns_IZeldaFaker()
        {
            Assert.IsInstanceOf<IZeldaFaker>(Faker.Zelda);
        }
    }
}
