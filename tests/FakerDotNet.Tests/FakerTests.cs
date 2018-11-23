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
        public void Avatar_returns_IAvatarFaker()
        {
            Assert.IsInstanceOf<IAvatarFaker>(Faker.Avatar);
        }

        [Test]
        public void Beer_returns_IBeerFaker()
        {
            Assert.IsInstanceOf<IBeerFaker>(Faker.Beer);
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
        public void Business_returns_IBusinessFaker()
        {
            Assert.IsInstanceOf<IBusinessFaker>(Faker.Business);
        }

        [Test]
        public void Color_returns_IColorFaker()
        {
            Assert.IsInstanceOf<IColorFaker>(Faker.Color);
        }

        [Test]
        public void Company_returns_ICompanyFaker()
        {
            Assert.IsInstanceOf<ICompanyFaker>(Faker.Company);
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
        public void File_returns_IFileFaker()
        {
            Assert.IsInstanceOf<IFileFaker>(Faker.File);
        }

        [Test]
        public void Friends_returns_IFriendsFaker()
        {
            Assert.IsInstanceOf<IFriendsFaker>(Faker.Friends);
        }

        [Test]
        public void GameOfThrones_returns_IGameOfThronesFaker()
        {
            Assert.IsInstanceOf<IGameOfThronesFaker>(Faker.GameOfThrones);
        }

        [Test]
        public void Internet_returns_IInternetFaker()
        {
            Assert.IsInstanceOf<IInternetFaker>(Faker.Internet);
        }

        [Test]
        public void Lorem_returns_ILoremFaker()
        {
            Assert.IsInstanceOf<ILoremFaker>(Faker.Lorem);
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
        public void Pokemon_returns_IPokemonFaker()
        {
            Assert.IsInstanceOf<IPokemonFaker>(Faker.Pokemon);
        }

        [Test]
        public void Random_returns_IRandomFaker()
        {
            Assert.IsInstanceOf<IRandomFaker>(Faker.Random);
        }

        [Test]
        public void RickAndMorty_returns_IRickAndMortyFaker()
        {
            Assert.IsInstanceOf<IRickAndMortyFaker>(Faker.RickAndMorty);
        }

        [Test]
        public void RockBand_returns_IRockBandFaker()
        {
            Assert.IsInstanceOf<IRockBandFaker>(Faker.RockBand);
        }
        
        [Test]
        public void Superhero_returns_ISuperheroFaker()
        {
            Assert.IsInstanceOf<ISuperheroFaker>(Faker.Superhero);
        }

        [Test]
        public void Team_returns_ITeamFaker()
        {
            Assert.IsInstanceOf<ITeamFaker>(Faker.Team);
        }
        [Test]
        public void SlackEmoji_returns_ISlackEmoji()
        {
            Assert.IsInstanceOf<ISlackEmojiFaker>(Faker.SlackEmoji);
        }

        [Test]
        public void Time_returns_ITimeFaker()
        {
            Assert.IsInstanceOf<ITimeFaker>(Faker.Time);
        }

        [Test]
        public void TwinPeaks_returns_ITwinPeaksFaker()
        {
            Assert.IsInstanceOf<ITwinPeaksFaker>(Faker.TwinPeaks);
        }

        [Test]
        public void University_returns_IUniversityFaker()
        {
            Assert.IsInstanceOf<IUniversityFaker>(Faker.University);
        }

        [Test]
        public void Vehicle_returns_IVehicleFaker()
        {
            Assert.IsInstanceOf<IVehicleFaker>(Faker.Vehicle);
        }

        [Test]
        public void Zelda_returns_IZeldaFaker()
        {
            Assert.IsInstanceOf<IZeldaFaker>(Faker.Zelda);
        }
    }
}
