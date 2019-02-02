using FakerDotNet.Data;

namespace FakerDotNet.Fakers
{
    public interface ICoffeeFaker
    {
        string BlendName();
        string Origin();
        string Variety();
        string Notes();
        string Intensifier();
    }
    
    internal class CoffeeFaker : ICoffeeFaker
    {
        private readonly IFakerContainer _fakerContainer;

        public CoffeeFaker(IFakerContainer fakerContainer)
        {
            _fakerContainer = fakerContainer;
        }

        public string BlendName()
        {
            return string.Join(" ",
                _fakerContainer.Random.Element(CoffeeData.BlendNamePrefixes),
                _fakerContainer.Random.Element(CoffeeData.BlendNameSuffixes));
        }

        public string Origin()
        {
            var country = _fakerContainer.Random.Element(CoffeeData.CountriesWithRegions.Keys);
            var region = _fakerContainer.Random.Element(CoffeeData.CountriesWithRegions[country]);
            return $"{region}, {country}";
        }

        public string Variety()
        {
            return _fakerContainer.Random.Element(CoffeeData.Varieties);
        }

        public string Notes()
        {
            return string.Join(", ",
                _fakerContainer.Random.Element(CoffeeData.Intensifiers),
                _fakerContainer.Random.Element(CoffeeData.Bodies),
                string.Join(", ", _fakerContainer.Random.Assortment(CoffeeData.Descriptors, 3)));
        }

        public string Intensifier()
        {
            return _fakerContainer.Random.Element(CoffeeData.Intensifiers);
        }
    }
}
