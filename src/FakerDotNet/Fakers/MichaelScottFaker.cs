using FakerDotNet.Data;

namespace FakerDotNet.Fakers
{
    public interface IMichaelScottFaker
    {
        string Quote();
    }
    
    internal class MichaelScottFaker : IMichaelScottFaker
    {
        private readonly IFakerContainer _fakerContainer;

        public MichaelScottFaker(IFakerContainer fakerContainer)
        {
            _fakerContainer = fakerContainer;
        }

        public string Quote()
        {
            return _fakerContainer.Random.Element(MichaelScottData.Quotes);
        }
    }
}
