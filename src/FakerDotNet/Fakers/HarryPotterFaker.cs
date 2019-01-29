using System;
using FakerDotNet.Data;

namespace FakerDotNet.Fakers
{
    public interface IHarryPotterFaker
    {
        string Character();
        string Location();
        string Quote();
        string Book();
        string House();
        string Spell();
    }

    internal class HarryPotterFaker : IHarryPotterFaker
    {
        private readonly IFakerContainer _fakerContainer;

        public HarryPotterFaker(IFakerContainer fakerContainer)
        {
            _fakerContainer = fakerContainer;
        }

        public string Character()
        {
            return _fakerContainer.Random.Element(HarryPotterData.Characters);
        }

        public string Location()
        {
            return _fakerContainer.Random.Element(HarryPotterData.Locations);
        }

        public string Quote()
        {
            return _fakerContainer.Random.Element(HarryPotterData.Quotes);
        }

        public string Book()
        {
            return _fakerContainer.Random.Element(HarryPotterData.Books);
        }

        public string House()
        {
            return _fakerContainer.Random.Element(HarryPotterData.Houses);
        }

        public string Spell()
        {
            return _fakerContainer.Random.Element(HarryPotterData.Spells);
        }
    }
}
