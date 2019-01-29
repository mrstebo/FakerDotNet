using FakerDotNet.Fakers;

namespace FakerDotNet
{
    internal interface IFakerContainer
    {
        IAddressFaker Address { get; }
        IAncientFaker Ancient { get; }
        IAppFaker App { get; }
        IAvatarFaker Avatar { get; }
        IBeerFaker Beer { get; }
        IBookFaker Book { get; }
        IBooleanFaker Boolean { get; }
        IBusinessFaker Business { get; }
        ICatFaker Cat { get; }
        IChuckNorrisFaker ChuckNorris { get; }
        ICoffeeFaker Coffee { get; }
        IColorFaker Color { get; }
        ICompanyFaker Company { get; }
        IDateFaker Date { get; }
        IFakeFaker Fake { get; }
        IFileFaker File { get; }
        IFoodFaker Food { get; }
        IFriendsFaker Friends { get; }
        IGameOfThronesFaker GameOfThrones { get; }
        IHackerFaker Hacker { get; }
        IHarryPotterFaker HarryPotter { get; }
        IInternetFaker Internet { get; }
        ILoremFaker Lorem { get; }
        IMusicFaker Music { get; }
        INameFaker Name { get; }
        INumberFaker Number { get; }
        IPhoneNumberFaker PhoneNumber { get; }
        IPokemonFaker Pokemon { get; }
        IRandomFaker Random { get; }
        IRickAndMortyFaker RickAndMorty { get; }
        IRockBandFaker RockBand { get; }
        ISlackEmojiFaker SlackEmoji { get; }
        IStarWarsFaker StarWars { get; }
        ISuperheroFaker Superhero { get; }
        ITeamFaker Team { get; }
        ITimeFaker Time { get; }
        ITwinPeaksFaker TwinPeaks { get; }
        IUniversityFaker University { get; }
        IVehicleFaker Vehicle { get; }
        IZeldaFaker Zelda { get; }
    }

    internal class FakerContainer : IFakerContainer
    {
        public FakerContainer()
        {
            Address = new AddressFaker(this);
            Ancient = new AncientFaker(this);
            App = new AppFaker(this);
            Avatar = new AvatarFaker(this);
            Beer = new BeerFaker(this);
            Book = new BookFaker(this);
            Boolean = new BooleanFaker();
            Business = new BusinessFaker(this);
            Cat = new CatFaker(this);
            ChuckNorris = new ChuckNorrisFaker(this);
            Coffee = new CoffeeFaker(this);
            Color = new ColorFaker(this);
            Company = new CompanyFaker(this);
            Date = new DateFaker();
            Fake = new FakeFaker(this);
            File = new FileFaker(this);
            Food = new FoodFaker(this);
            Friends = new FriendsFaker(this);
            GameOfThrones = new GameOfThronesFaker(this);
            Hacker = new HackerFaker(this);
            HarryPotter = new HarryPotterFaker(this);
            Internet = new InternetFaker(this);
            Lorem = new LoremFaker(this);
            Music = new MusicFaker(this);
            Name = new NameFaker(this);
            Number = new NumberFaker();
            PhoneNumber = new PhoneNumberFaker(this);
            Pokemon = new PokemonFaker(this);
            Random = new RandomFaker();
            RickAndMorty = new RickAndMortyFaker(this);
            RockBand = new RockBandFaker(this);
            SlackEmoji = new SlackEmojiFaker(this);
            StarWars = new StarWarsFaker(this);
            Superhero = new SuperheroFaker(this);
            Team = new TeamFaker(this);
            Time = new TimeFaker();
            TwinPeaks = new TwinPeaksFaker(this);
            University = new UniversityFaker(this);
            Vehicle = new VehicleFaker(this);
            Zelda = new ZeldaFaker(this);
        }

        public IAddressFaker Address { get; }
        public IAncientFaker Ancient { get; }
        public IAppFaker App { get; }
        public IAvatarFaker Avatar { get; }
        public IBeerFaker Beer { get; }
        public IBookFaker Book { get; }
        public IBooleanFaker Boolean { get; }
        public IBusinessFaker Business { get; }
        public ICatFaker Cat { get; }
        public IChuckNorrisFaker ChuckNorris { get; }
        public ICoffeeFaker Coffee { get; }
        public IColorFaker Color { get; }
        public ICompanyFaker Company { get; }
        public IDateFaker Date { get; }
        public IFakeFaker Fake { get; }
        public IFileFaker File { get; }
        public IFoodFaker Food { get; }
        public IFriendsFaker Friends { get; }
        public IGameOfThronesFaker GameOfThrones { get; }
        public IHackerFaker Hacker { get; }
        public IHarryPotterFaker HarryPotter { get; }
        public IInternetFaker Internet { get; }
        public ILoremFaker Lorem { get; }
        public IMusicFaker Music { get; }
        public INameFaker Name { get; }
        public INumberFaker Number { get; }
        public IPhoneNumberFaker PhoneNumber { get; }
        public IPokemonFaker Pokemon { get; }
        public IRandomFaker Random { get; }
        public IRickAndMortyFaker RickAndMorty { get; }
        public IRockBandFaker RockBand { get; }
        public ISlackEmojiFaker SlackEmoji { get; }
        public IStarWarsFaker StarWars { get; }
        public ISuperheroFaker Superhero { get; }
        public ITeamFaker Team { get; }
        public ITimeFaker Time { get; }
        public ITwinPeaksFaker TwinPeaks { get; }
        public IUniversityFaker University { get; }
        public IVehicleFaker Vehicle { get; }
        public IZeldaFaker Zelda { get; }
    }
}
