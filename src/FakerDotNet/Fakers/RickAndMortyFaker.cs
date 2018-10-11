using FakerDotNet.Data;

namespace FakerDotNet.Fakers
{
    public interface IRickAndMortyFaker
    {
        string Character();
        string Location();
        string Quote();
    }

    internal class RickAndMortyFaker : IRickAndMortyFaker
    {
        private readonly IFakerContainer _fakerContainer;

        public RickAndMortyFaker(IFakerContainer fakerContainer)
        {
            _fakerContainer = fakerContainer;
        }

        public string Character()
        {
            return _fakerContainer.Random.Element(RickAndMortyData.Characters);
        }

        public string Location()
        {
            return _fakerContainer.Random.Element(RickAndMortyData.Locations);
        }

        public string Quote()
        {
            return _fakerContainer.Random.Element(RickAndMortyData.Quotes);
        }
    }
}
