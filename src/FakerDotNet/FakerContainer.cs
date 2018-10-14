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
        INameFaker Name { get; }
        INumberFaker Number { get; }
        IRandomFaker Random { get; }
        ITimeFaker Time { get; }
        IFriendsFaker Friends { get; }
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
            Name = new NameFaker(this);
            Number = new NumberFaker();
            Random = new RandomFaker();
            Time = new TimeFaker();
            Friends = new FriendsFaker(this);
            Zelda = new ZeldaFaker(this);
        }

        public IAddressFaker Address { get; }
        public IAppFaker App { get; }
        public IBookFaker Book { get; }
        public IBooleanFaker Boolean { get; }
        public IDateFaker Date { get; }
        public IFakeFaker Fake { get; }
        public INameFaker Name { get; }
        public INumberFaker Number { get; }
        public IRandomFaker Random { get; }
        public ITimeFaker Time { get; }
        public IFriendsFaker Friends { get; }
        public IZeldaFaker Zelda { get; }
    }
}
