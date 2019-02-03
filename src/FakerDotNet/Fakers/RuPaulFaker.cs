using FakerDotNet.Data;

namespace FakerDotNet.Fakers
{
    public interface IRuPaulFaker
    {
        string Quote();
        string Queen();
    }
    
    internal class RuPaulFaker : IRuPaulFaker
    {
        private readonly IFakerContainer _fakerContainer;

        public RuPaulFaker(IFakerContainer fakerContainer)
        {
            _fakerContainer = fakerContainer;
        }

        public string Quote()
        {
            return _fakerContainer.Random.Element(RuPaulData.Quotes);
        }

        public string Queen()
        {
            return _fakerContainer.Random.Element(RuPaulData.Queens);
        }
    }
}
