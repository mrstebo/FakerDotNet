using FakerDotNet.Fakers;

namespace FakerDotNet
{
    public interface IFaker
    {
        INameFaker Name { get; }
        IRandomFaker Random { get; }
    }
    
    internal class Faker : IFaker
    {
        public INameFaker Name { get; }
        public IRandomFaker Random { get; }

        public Faker()
        {
            Name = new NameFaker(this);
            Random = new RandomFaker();
        }
    }
}
