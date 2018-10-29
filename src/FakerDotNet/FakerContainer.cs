using FakerDotNet.Fakers;

namespace FakerDotNet
{
    internal interface IFakerContainer
    {
        IAddressFaker Address { get; }
        IAppFaker App { get; }
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
        ILoremFaker Lorem { get; }
        INameFaker Name { get; }
        INumberFaker Number { get; }
        IPokemonFaker Pokemon { get; }
        IRandomFaker Random { get; }        
        IRockBandFaker RockBand { get; }
        ISuperheroFaker Superhero { get; }
        ITeamFaker Team { get; }
        ITimeFaker Time { get; }
        ITwinPeaksFaker TwinPeaks { get; }
        IUniversityFaker University { get; }
        IZeldaFaker Zelda { get; }
    }

    internal class FakerContainer : IFakerContainer
    {
        public FakerContainer()
        {
            Address = new AddressFaker(this);
            App = new AppFaker(this);
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
            Lorem = new LoremFaker(this);
            Name = new NameFaker(this);
            Number = new NumberFaker();
            Pokemon = new PokemonFaker(this);
            Random = new RandomFaker();            
            RockBand = new RockBandFaker(this);
            Superhero = new SuperheroFaker(this);
            Team = new TeamFaker(this);
            Time = new TimeFaker();
            TwinPeaks = new TwinPeaksFaker(this);
            University = new UniversityFaker(this);
            Zelda = new ZeldaFaker(this);
        }

        public IAddressFaker Address { get; }
        public IAppFaker App { get; }
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
        public ILoremFaker Lorem { get; }
        public INameFaker Name { get; }
        public INumberFaker Number { get; }
        public IPokemonFaker Pokemon { get; }
        public IRandomFaker Random { get; }
        public IRockBandFaker RockBand { get; }
        public ISuperheroFaker Superhero { get; }
        public ITeamFaker Team { get; }
        public ITimeFaker Time { get; }
        public ITwinPeaksFaker TwinPeaks { get; }
        public IUniversityFaker University { get; }
        public IZeldaFaker Zelda { get; }
    }
}
