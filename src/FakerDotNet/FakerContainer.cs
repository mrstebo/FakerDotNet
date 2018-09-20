using FakerDotNet.Fakers;

namespace FakerDotNet
{
    internal interface IFakerContainer
    {
        IFakeFaker Fake { get; }
        INameFaker Name { get; }
        IRandomFaker Random { get; }
    }
    
    internal class FakerContainer : IFakerContainer
    {
        public IFakeFaker Fake { get; }
        public INameFaker Name { get; }
        public IRandomFaker Random { get; }

        public FakerContainer()
        {
            Fake = new FakeFaker(this);
            Name = new NameFaker(this);
            Random = new RandomFaker();
        }
    }
}
