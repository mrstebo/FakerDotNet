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
        public void Ancient_returns_IAncientFaker()
        {
            Assert.IsInstanceOf<IAncientFaker>(_fakerContainer.Ancient);
        }

        [Test]
        public void App_returns_IAppFaker()
        {
            Assert.IsInstanceOf<IAppFaker>(_fakerContainer.App);
        }

        [Test]
        public void Avatar_returns_IAvatarFaker()
        {
            Assert.IsInstanceOf<IAvatarFaker>(_fakerContainer.Avatar);
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
        public void Cat_returns_ICatFaker()
        {
            Assert.IsInstanceOf<ICatFaker>(_fakerContainer.Cat);
        }

        [Test]
        public void ChuckNorris_returns_IChuckNorrisFaker()
        {
            Assert.IsInstanceOf<IChuckNorrisFaker>(_fakerContainer.ChuckNorris);
        }

        [Test]
        public void Coffee_returns_ICoffeeFaker()
        {
            Assert.IsInstanceOf<ICoffeeFaker>(_fakerContainer.Coffee);
        }

        [Test]
        public void Color_returns_IColorFaker()
        {
            Assert.IsInstanceOf<IColorFaker>(_fakerContainer.Color);
        }

        [Test]
        public void Commerce_returns_ICommerceFaker()
        {
            Assert.IsInstanceOf<ICommerceFaker>(_fakerContainer.Commerce);
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
        public void DragonBall_returns_IDragonBallFaker()
        {
            Assert.IsInstanceOf<IDragonBallFaker>(_fakerContainer.DragonBall);
        }

        [Test]
        public void Educator_returns_IEducatorFaker()
        {
            Assert.IsInstanceOf<IEducatorFaker>(_fakerContainer.Educator);
        }

        [Test]
        public void Fake_returns_IFakeFaker()
        {
            Assert.IsInstanceOf<IFakeFaker>(_fakerContainer.Fake);
        }

        [Test]
        public void File_returns_IFileFaker()
        {
            Assert.IsInstanceOf<IFileFaker>(_fakerContainer.File);
        }

        [Test]
        public void Fillmurray_returns_IFillmurrayFaker()
        {
            Assert.IsInstanceOf<IFillmurrayFaker>(_fakerContainer.Fillmurray);
        }

        [Test]
        public void Food_returns_IFoodFaker()
        {
            Assert.IsInstanceOf<IFoodFaker>(_fakerContainer.Food);
        }

        [Test]
        public void Friends_returns_IFriendsFaker()
        {
            Assert.IsInstanceOf<IFriendsFaker>(_fakerContainer.Friends);
        }

        [Test]
        public void GameOfThrones_returns_IGameOfThronesFaker()
        {
            Assert.IsInstanceOf<IGameOfThronesFaker>(_fakerContainer.GameOfThrones);
        }

        [Test]
        public void Hacker_returns_IHackerFaker()
        {
            Assert.IsInstanceOf<IHackerFaker>(_fakerContainer.Hacker);
        }

        [Test]
        public void HarryPotter_returns_IHarryPotterFaker()
        {
            Assert.IsInstanceOf<IHarryPotterFaker>(_fakerContainer.HarryPotter);
        }

        [Test]
        public void Internet_returns_IInternetFaker()
        {
            Assert.IsInstanceOf<IInternetFaker>(_fakerContainer.Internet);
        }

        [Test]
        public void LordOfTheRings_returns_ILordOfTheRingsFaker()
        {
            Assert.IsInstanceOf<ILordOfTheRingsFaker>(_fakerContainer.LordOfTheRings);
        }

        [Test]
        public void Lorem_returns_ILoremFaker()
        {
            Assert.IsInstanceOf<ILoremFaker>(_fakerContainer.Lorem);
        }

        [Test]
        public void Matz_returns_IMatzFaker()
        {
            Assert.IsInstanceOf<IMatzFaker>(_fakerContainer.Matz);
        }

        [Test]
        public void Music_returns_IMusicFaker()
        {
            Assert.IsInstanceOf<IMusicFaker>(_fakerContainer.Music);
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
        public void PhoneNumber_returns_IPhoneNumberFaker()
        {
            Assert.IsInstanceOf<IPhoneNumberFaker>(_fakerContainer.PhoneNumber);
        }

        [Test]
        public void Placeholdit_returns_IPlaceholditFaker()
        {
            Assert.IsInstanceOf<IPlaceholditFaker>(_fakerContainer.Placeholdit);
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
        public void RickAndMorty_returns_IRickAndMortyFaker()
        {
            Assert.IsInstanceOf<IRickAndMortyFaker>(_fakerContainer.RickAndMorty);
        }

        [Test]
        public void RockBand_returns_IRockBandFaker()
        {
            Assert.IsInstanceOf<IRockBandFaker>(_fakerContainer.RockBand);
        }

        [Test]
        public void SlackEmoji_returns_ISlackEmoji()
        {
            Assert.IsInstanceOf<ISlackEmojiFaker>(_fakerContainer.SlackEmoji);
        }

        [Test]
        public void Space_returns_ISpaceFaker()
        {
            Assert.IsInstanceOf<ISpaceFaker>(_fakerContainer.Space);
        }

        [Test]
        public void StarWars_returns_IStarWarsFaker()
        {
            Assert.IsInstanceOf<IStarWarsFaker>(_fakerContainer.StarWars);
        }

        [Test]
        public void Superhero_returns_ISuperheroFaker()
        {
            Assert.IsInstanceOf<ISuperheroFaker>(_fakerContainer.Superhero);
        }

        [Test]
        public void Team_returns_ITeamFaker()
        {
            Assert.IsInstanceOf<ITeamFaker>(_fakerContainer.Team);
        }

        [Test]
        public void Time_returns_ITimeFaker()
        {
            Assert.IsInstanceOf<ITimeFaker>(_fakerContainer.Time);
        }

        [Test]
        public void TwinPeaks_returns_ITwinPeaksFaker()
        {
            Assert.IsInstanceOf<ITwinPeaksFaker>(_fakerContainer.TwinPeaks);
        }

        [Test]
        public void University_returns_IUniversityFaker()
        {
            Assert.IsInstanceOf<IUniversityFaker>(_fakerContainer.University);
        }

        [Test]
        public void Vehicle_returns_IVehicleFaker()
        {
            Assert.IsInstanceOf<IVehicleFaker>(_fakerContainer.Vehicle);
        }

        [Test]
        public void Zelda_returns_IZeldaFaker()
        {
            Assert.IsInstanceOf<IZeldaFaker>(_fakerContainer.Zelda);
        }
    }
}
