using FakerDotNet.Fakers;

namespace FakerDotNet
{
    internal interface IFakerContainer
    {
        IAppFaker App { get; }
        IBookFaker Book { get; }
        IFakeFaker Fake { get; }
        INameFaker Name { get; }
        INumberFaker Number { get; }
        IRandomFaker Random { get; }
    }

    internal class FakerContainer : IFakerContainer
    {
        public FakerContainer()
        {
            App = new AppFaker(this);
            Book = new BookFaker(this);
            Fake = new FakeFaker(this);
            Name = new NameFaker(this);
            Number = new NumberFaker();
            Random = new RandomFaker();
        }

        public IAppFaker App { get; }
        public IBookFaker Book { get; }
        public IFakeFaker Fake { get; }
        public INameFaker Name { get; }
        public INumberFaker Number { get; }
        public IRandomFaker Random { get; }
    }
}
