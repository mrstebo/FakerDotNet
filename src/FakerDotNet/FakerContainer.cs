using FakerDotNet.Fakers;

namespace FakerDotNet
{
    internal interface IFakerContainer
    {
        IAppFaker App { get; }
        IFakeFaker Fake { get; }
        INameFaker Name { get; }
        IRandomFaker Random { get; }
    }

    internal class FakerContainer : IFakerContainer
    {
        public IAppFaker App { get; }
        public IFakeFaker Fake { get; }
        public INameFaker Name { get; }
        public IRandomFaker Random { get; }

        public FakerContainer()
        {
            App = new AppFaker(this);
            Fake = new FakeFaker(this);
            Name = new NameFaker(this);
            Random = new RandomFaker();
        }
    }
}
