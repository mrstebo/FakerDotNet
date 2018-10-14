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
            var ibuNum = _fakerContainer.Number.Between(10, 100);
            return $"{Math.Round(ibuNum)} IBU";
        }

        public string Alcohol()
        {
            var alcoholNum = _fakerContainer.Number.Between(2, 10);
            return $"{Math.Round(alcoholNum, 1)}%";
        }

        public string Blg()
        {
            var blgNum = _fakerContainer.Number.Between(5, 20);
            return $"{Math.Round(blgNum, 1)}°Blg";

        }
    }
}
