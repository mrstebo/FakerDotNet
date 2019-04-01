using FakerDotNet.Fakers;

namespace FakerDotNet
{
    internal interface IFakerContainer
    {
        IAddressFaker Address { get; }
        IAncientFaker Ancient { get; }
        IAppFaker App { get; }
        IAvatarFaker Avatar { get; }
        IBankFaker Bank { get; }
        IBeerFaker Beer { get; }
        IBookFaker Book { get; }
        IBooleanFaker Boolean { get; }
        IBusinessFaker Business { get; }
        ICatFaker Cat { get; }
        IChuckNorrisFaker ChuckNorris { get; }
        ICoffeeFaker Coffee { get; }
        IColorFaker Color { get; }
        ICommerceFaker Commerce { get; }
        ICompanyFaker Company { get; }
        ICompassFaker Compass { get; }
        IDateFaker Date { get; }
        IDemographicFaker Demographic { get; }
        IDragonBallFaker DragonBall { get; }
        IEducatorFaker Educator { get; }
        IFakeFaker Fake { get; }
        IFileFaker File { get; }
        IFillmurrayFaker Fillmurray { get; }
        IFoodFaker Food { get; }
        IFriendsFaker Friends { get; }
        IGameOfThronesFaker GameOfThrones { get; }
        IHackerFaker Hacker { get; }
        IHarryPotterFaker HarryPotter { get; }
        IHipsterFaker Hipster { get; }
        IInternetFaker Internet { get; }
        ILordOfTheRingsFaker LordOfTheRings { get; }
        ILoremFaker Lorem { get; }
        ILoremFlickrFaker LoremFlickr { get; }
        ILoremPixelFaker LoremPixel { get; }
        IMatzFaker Matz { get; }
        IMichaelScottFaker MichaelScott { get; }
        IMusicFaker Music { get; }
        INameFaker Name { get; }
        INumberFaker Number { get; }
        IPhoneNumberFaker PhoneNumber { get; }
        IPlaceholditFaker Placeholdit { get; }
        IPokemonFaker Pokemon { get; }
        IRandomFaker Random { get; }
        IRickAndMortyFaker RickAndMorty { get; }
        IRockBandFaker RockBand { get; }
        IRuPaulFaker RuPaul { get; }
        ISlackEmojiFaker SlackEmoji { get; }
        ISpaceFaker Space { get; }
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
            Bank = new BankFaker(this);
            Beer = new BeerFaker(this);
            Book = new BookFaker(this);
            Boolean = new BooleanFaker();
            Business = new BusinessFaker(this);
            Cat = new CatFaker(this);
            ChuckNorris = new ChuckNorrisFaker(this);
            Coffee = new CoffeeFaker(this);
            Color = new ColorFaker(this);
            Commerce = new CommerceFaker(this);
            Company = new CompanyFaker(this);
            Compass = new CompassFaker(this);
            Date = new DateFaker();
            Demographic = new DemographicFaker(this);
            DragonBall = new DragonBallFaker(this);
            Educator = new EducatorFaker(this);
            Fake = new FakeFaker(this);
            File = new FileFaker(this);
            Fillmurray = new FillmurrayFaker();
            Food = new FoodFaker(this);
            Friends = new FriendsFaker(this);
            GameOfThrones = new GameOfThronesFaker(this);
            Hacker = new HackerFaker(this);
            HarryPotter = new HarryPotterFaker(this);
            Hipster = new HipsterFaker(this);
            Internet = new InternetFaker(this);
            LordOfTheRings = new LordOfTheRingsFaker(this);
            Lorem = new LoremFaker(this);
            LoremFlickr = new LoremFlickrFaker(this);
            LoremPixel = new LoremPixelFaker(this);
            Matz = new MatzFaker(this);
            MichaelScott = new MichaelScottFaker(this);
            Music = new MusicFaker(this);
            Name = new NameFaker(this);
            Number = new NumberFaker();
            PhoneNumber = new PhoneNumberFaker(this);
            Placeholdit = new PlaceholditFaker(this);
            Pokemon = new PokemonFaker(this);
            Random = new RandomFaker();
            RickAndMorty = new RickAndMortyFaker(this);
            RockBand = new RockBandFaker(this);
            RuPaul = new RuPaulFaker(this);
            SlackEmoji = new SlackEmojiFaker(this);
            Space = new SpaceFaker(this);
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
        public IBankFaker Bank { get; }
        public IBeerFaker Beer { get; }
        public IBookFaker Book { get; }
        public IBooleanFaker Boolean { get; }
        public IBusinessFaker Business { get; }
        public ICatFaker Cat { get; }
        public IChuckNorrisFaker ChuckNorris { get; }
        public ICoffeeFaker Coffee { get; }
        public IColorFaker Color { get; }
        public ICommerceFaker Commerce { get; }
        public ICompanyFaker Company { get; }
        public ICompassFaker Compass { get; }
        public IDateFaker Date { get; }
        public IDemographicFaker Demographic { get; }
        public IDragonBallFaker DragonBall { get; }
        public IEducatorFaker Educator { get; }
        public IFakeFaker Fake { get; }
        public IFileFaker File { get; }
        public IFillmurrayFaker Fillmurray { get; }
        public IFoodFaker Food { get; }
        public IFriendsFaker Friends { get; }
        public IGameOfThronesFaker GameOfThrones { get; }
        public IHackerFaker Hacker { get; }
        public IHarryPotterFaker HarryPotter { get; }
        public IHipsterFaker Hipster { get; }
        public IInternetFaker Internet { get; }
        public ILordOfTheRingsFaker LordOfTheRings { get; }
        public ILoremFaker Lorem { get; }
        public ILoremFlickrFaker LoremFlickr { get; }
        public ILoremPixelFaker LoremPixel { get; }
        public IMatzFaker Matz { get; }
        public IMichaelScottFaker MichaelScott { get; }
        public IMusicFaker Music { get; }
        public INameFaker Name { get; }
        public INumberFaker Number { get; }
        public IPhoneNumberFaker PhoneNumber { get; }
        public IPlaceholditFaker Placeholdit { get; }
        public IPokemonFaker Pokemon { get; }
        public IRandomFaker Random { get; }
        public IRickAndMortyFaker RickAndMorty { get; }
        public IRockBandFaker RockBand { get; }
        public IRuPaulFaker RuPaul { get; }
        public ISlackEmojiFaker SlackEmoji { get; }
        public ISpaceFaker Space { get; }
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
