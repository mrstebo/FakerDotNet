using FakerDotNet.Fakers;

namespace FakerDotNet
{
    internal interface IFakerContainer
    {
        IAddressFaker Address { get; }
        IAppFaker App { get; }
        IBookFaker Book { get; }
        IBooleanFaker Boolean { get; }
        IDateFaker Date { get; }
        IFakeFaker Fake { get; }
        IFriendsFaker Friends { get; }
        ILoremFaker Lorem { get; }
        INameFaker Name { get; }
        INumberFaker Number { get; }
        IPokemonFaker Pokemon { get; }
        IRandomFaker Random { get; }
        ITimeFaker Time { get; }
        IZeldaFaker Zelda { get; }
    }

    internal class FakerContainer : IFakerContainer
    {
        public FakerContainer()
        {
            Address = new AddressFaker(this);
            App = new AppFaker(this);
            Book = new BookFaker(this);
            Boolean = new BooleanFaker();
            Date = new DateFaker();
            Fake = new FakeFaker(this);
            Friends = new FriendsFaker(this);
            Lorem = new LoremFaker(this);
            Name = new NameFaker(this);
            Number = new NumberFaker();
            Pokemon = new PokemonFaker(this);
            Random = new RandomFaker();
            Time = new TimeFaker();
            Zelda = new ZeldaFaker(this);
        }

        public IAddressFaker Address { get; }
        public IAppFaker App { get; }
        public IBookFaker Book { get; }
        public IBooleanFaker Boolean { get; }
        public IDateFaker Date { get; }
        public IFakeFaker Fake { get; }
        public IFriendsFaker Friends { get; }
        public ILoremFaker Lorem { get; }
        public INameFaker Name { get; }
        public INumberFaker Number { get; }
        public IPokemonFaker Pokemon { get; }
        public IRandomFaker Random { get; }
        public ITimeFaker Time { get; }
        public IZeldaFaker Zelda { get; }
    }
}
