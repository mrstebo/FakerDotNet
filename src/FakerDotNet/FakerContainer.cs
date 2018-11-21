using FakerDotNet.Fakers;

namespace FakerDotNet
{
    internal interface IFakerContainer
    {
        IAddressFaker Address { get; }
        IAppFaker App { get; }
        IAvatarFaker Avatar { get; }
        IBeerFaker Beer { get; }
        IBookFaker Book { get; }
        IBooleanFaker Boolean { get; }
        IBusinessFaker Business { get; }
        IColorFaker Color { get; }
        ICompanyFaker Company { get; }
        IDateFaker Date { get; }
        IFakeFaker Fake { get; }
        IFriendsFaker Friends { get; }
        IGameOfThronesFaker GameOfThrones { get; }
        IInternetFaker Internet { get; }
        ILoremFaker Lorem { get; }
        INameFaker Name { get; }
        INumberFaker Number { get; }
        IPokemonFaker Pokemon { get; }
        IRandomFaker Random { get; }
        IRickAndMortyFaker RickAndMorty { get; }
        IRockBandFaker RockBand { get; }
        ISlackEmojiFaker SlackEmoji { get; }
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
            App = new AppFaker(this);
            Avatar = new AvatarFaker(this);
            Beer = new BeerFaker(this);
            Book = new BookFaker(this);
            Boolean = new BooleanFaker();
            Business = new BusinessFaker(this);
            Color = new ColorFaker(this);
            Company = new CompanyFaker(this);
            Date = new DateFaker();
            Fake = new FakeFaker(this);
            Friends = new FriendsFaker(this);
            GameOfThrones = new GameOfThronesFaker(this);
            Internet = new InternetFaker(this);
            Lorem = new LoremFaker(this);
            Name = new NameFaker(this);
            Number = new NumberFaker();
            Pokemon = new PokemonFaker(this);
            Random = new RandomFaker();
            RickAndMorty = new RickAndMortyFaker(this);
            RockBand = new RockBandFaker(this);
            SlackEmoji = new SlackEmojiFaker(this);
            Superhero = new SuperheroFaker(this);
            Team = new TeamFaker(this);
            Time = new TimeFaker();
            TwinPeaks = new TwinPeaksFaker(this);
            University = new UniversityFaker(this);
            Vehicle = new VehicleFaker(this);
            Zelda = new ZeldaFaker(this);
        }

        public IAddressFaker Address { get; }
        public IAppFaker App { get; }
        public IAvatarFaker Avatar { get; }
        public IBeerFaker Beer { get; }
        public IBookFaker Book { get; }
        public IBooleanFaker Boolean { get; }
        public IBusinessFaker Business { get; }
        public IColorFaker Color { get; }
        public ICompanyFaker Company { get; }
        public IDateFaker Date { get; }
        public IFakeFaker Fake { get; }
        public IFriendsFaker Friends { get; }
        public IGameOfThronesFaker GameOfThrones { get; }
        public IInternetFaker Internet { get; }
        public ILoremFaker Lorem { get; }
        public INameFaker Name { get; }
        public INumberFaker Number { get; }
        public IPokemonFaker Pokemon { get; }
        public IRandomFaker Random { get; }
        public IRickAndMortyFaker RickAndMorty { get; }
        public IRockBandFaker RockBand { get; }
        public ISlackEmojiFaker SlackEmoji { get; }
        public ISuperheroFaker Superhero { get; }
        public ITeamFaker Team { get; }
        public ITimeFaker Time { get; }
        public ITwinPeaksFaker TwinPeaks { get; }
        public IUniversityFaker University { get; }
        public IVehicleFaker Vehicle { get; }
        public IZeldaFaker Zelda { get; }
    }
}
