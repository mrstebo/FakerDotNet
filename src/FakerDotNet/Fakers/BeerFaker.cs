using FakerDotNet.Data;
using System;

namespace FakerDotNet.Fakers
{
    public interface IBeerFaker
    {
        string Brand();
        string Name();
        string Style();
        string Hop();
        string Yeast();
        string Malts();
        string Ibu();
        string Alcohol();
        string Blg();
    }

    internal class BeerFaker : IBeerFaker
    {
        private static readonly BeerData Data = new BeerData();

        private readonly IFakerContainer _fakerContainer;
        private static readonly NumberFaker NumberFaker = new NumberFaker();

        public BeerFaker(IFakerContainer fakerContainer)
        {
            _fakerContainer = fakerContainer;
        }

        public string Brand()
        {
            return _fakerContainer.Random.Element(Data.Brand);
        }

        public string Name()
        {
            return _fakerContainer.Random.Element(Data.Name);
        }

        public string Style()
        {
            return _fakerContainer.Random.Element(Data.Style);
        }

        public string Hop()
        {
            return _fakerContainer.Random.Element(Data.Hop);
        }

        public string Yeast()
        {
            return _fakerContainer.Random.Element(Data.Yeast);
        }

        public string Malts()
        {
            return _fakerContainer.Random.Element(Data.Malts);
        }

        public string Ibu()
        {
            var tmp = _fakerContainer.Number.Between(10, 100); // always returns 0. why?
            var tmp2 = NumberFaker.Between(10, 100);
            return $"{Math.Round(tmp2)} IBU";
        }

        public string Alcohol()
        {
            var tmp = _fakerContainer.Number.Between(2, 10); // always returns 0. why?
            var tmp2 = NumberFaker.Between(2, 10);
            return $"{Math.Round(tmp2, 1)}%";
        }

        public string Blg()
        {
            var tmp = _fakerContainer.Number.Between(5, 20); // always returns 0. why?
            var tmp2 = NumberFaker.Between(5, 20);
            return $"{Math.Round(tmp2, 1)}°Blg";

        }
    }
}
