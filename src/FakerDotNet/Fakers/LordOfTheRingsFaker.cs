using FakerDotNet.Data;
using FakerDotNet.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace FakerDotNet.Fakers
{
    public interface ILordOfTheRingsFaker
    {
        string Character();
        string Location();
    }

    internal class LordOfTheRingsFaker : ILordOfTheRingsFaker
    {
        private static readonly LordOfTheRingsData data = new LordOfTheRingsData();
        private readonly IFakerContainer _fakerContainer;

        public LordOfTheRingsFaker() : this(new FakerContainer())
        {
        }

        internal LordOfTheRingsFaker(IFakerContainer fakerContainer)
        {
            _fakerContainer = fakerContainer;
        }
        public string Character()
        {
            return _fakerContainer.Random.Element(data.Characters);
        }
        public string Location()
        {
            return _fakerContainer.Random.Element(data.Locations);
        }
    }
}
