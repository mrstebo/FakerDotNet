using FakerDotNet.Data;

namespace FakerDotNet.Fakers
{
    public interface ICatFaker
    {
        string Name();
        string Breed();
        string Registry();
    }
    
    internal class CatFaker : ICatFaker
    {
        private readonly IFakerContainer _fakerContainer;

        public CatFaker(IFakerContainer fakerContainer)
        {
            _fakerContainer = fakerContainer;
        }
        
        public string Name()
        {
            return _fakerContainer.Random.Element(CatData.Names);
        }

        public string Breed()
        {
            return _fakerContainer.Random.Element(CatData.Breeds);
        }

        public string Registry()
        {
            return _fakerContainer.Random.Element(CatData.Registries);
        }
    }
}
