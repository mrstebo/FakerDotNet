using FakerDotNet.Data;

namespace FakerDotNet.Fakers
{
    public interface ILordOfTheRingsFaker
    {
        string Character();
        string Location();
    }

    internal class LordOfTheRingsFaker : ILordOfTheRingsFaker
    {
        private readonly IFakerContainer _fakerContainer;

        public LordOfTheRingsFaker(IFakerContainer fakerContainer)
        {
            _fakerContainer = fakerContainer;
        }

        public string Character()
        {
            return _fakerContainer.Random.Element(LordOfTheRingsData.Characters);
        }

        public string Location()
        {
            return _fakerContainer.Random.Element(LordOfTheRingsData.Locations);
        }
    }
}
