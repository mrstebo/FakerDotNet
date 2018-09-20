using FakerDotNet.Fakers;

namespace FakerDotNet
{
    internal interface IFakerContainer
    {
        IAppFaker App { get; }
        INameFaker Name { get; }
        IRandomFaker Random { get; }
    }
    
    internal class FakerContainer : IFakerContainer
    {
        public IAppFaker App { get; }
        public INameFaker Name { get; }
        public IRandomFaker Random { get; }

        public FakerContainer()
        {
            App = new AppFaker(this);
            Name = new NameFaker(this);
            Random = new RandomFaker();
        }
    }
}
