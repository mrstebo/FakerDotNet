using FakerDotNet.Data;

namespace FakerDotNet.Fakers
{
    public interface IMatzFaker
    {
        string Quote();
    }
    
    internal class MatzFaker : IMatzFaker
    {
        private readonly IFakerContainer _fakerContainer;

        public MatzFaker(IFakerContainer fakerContainer)
        {
            _fakerContainer = fakerContainer;
        }

        public string Quote()
        {
            return _fakerContainer.Random.Element(MatzData.Quotes);
        }
    }
}
