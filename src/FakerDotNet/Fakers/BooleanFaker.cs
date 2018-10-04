using FakerDotNet.Wrappers;

namespace FakerDotNet.Fakers
{
    public interface IBooleanFaker
    {
        bool Boolean(double trueRatio = 0.5);
    }
    
    internal class BooleanFaker : IBooleanFaker
    {
        private readonly IRandomWrapper _randomWrapper;

        public BooleanFaker()
            : this(new RandomWrapper())
        {
        }

        internal BooleanFaker(IRandomWrapper randomWrapper)
        {
            _randomWrapper = randomWrapper;
        }
        
        public bool Boolean(double trueRatio = 0.5)
        {
            return _randomWrapper.NextDouble() < trueRatio;
        }
    }
}
