using FakerDotNet.Data;

namespace FakerDotNet.Fakers
{
    public interface IAncientFaker
    {
        string God();
        string Primordial();
        string Titan();
        string Hero();
    }

    internal class AncientFaker : IAncientFaker
    {
        private readonly IFakerContainer _fakerContainer;

        public AncientFaker(IFakerContainer fakerContainer)
        {
            _fakerContainer = fakerContainer;
        }

        public string God()
        {
            return _fakerContainer.Random.Element(AncientData.Gods);
        }

        public string Primordial()
        {
            return _fakerContainer.Random.Element(AncientData.Primordials);
        }

        public string Titan()
        {
            return _fakerContainer.Random.Element(AncientData.Titans);
        }

        public string Hero()
        {
            return _fakerContainer.Random.Element(AncientData.Heroes);
        }
    }
}
