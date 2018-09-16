using FakerDotNet.Fakers;

namespace FakerDotNet
{
    internal interface IFakerContainer
    {
        INameFaker Name { get; }
        IRandomFaker Random { get; }
    }
    
    internal class FakerContainer : IFakerContainer
    {
        public INameFaker Name { get; }
        public IRandomFaker Random { get; }

        public FakerContainer()
        {
            Name = new NameFaker(this);
            Random = new RandomFaker();
        }
    }
}
