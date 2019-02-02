using FakerDotNet.Data;

namespace FakerDotNet.Fakers
{
    public interface IPokemonFaker
    {
        string Name();
        string Location();
        string Move();
    }
    
    internal class PokemonFaker : IPokemonFaker
    {
        private readonly IFakerContainer _fakerContainer;

        public PokemonFaker(IFakerContainer fakerContainer)
        {
            _fakerContainer = fakerContainer;
        }

        public string Name()
        {
            return _fakerContainer.Random.Element(PokemonData.Names);
        }

        public string Location()
        {
            return _fakerContainer.Random.Element(PokemonData.Locations);
        }

        public string Move()
        {
            return _fakerContainer.Random.Element(PokemonData.Moves);
        }
    }
}
