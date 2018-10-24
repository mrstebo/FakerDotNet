using FakerDotNet.Data;

namespace FakerDotNet.Fakers
{
    public interface ITwinPeaksFaker
    {
        string Character();
        string Location();
        string Quote();
    }

    internal class TwinPeaksFaker : ITwinPeaksFaker
    {
        private readonly IFakerContainer _fakerContainer;

        public TwinPeaksFaker(IFakerContainer faker)
        {
            _fakerContainer = faker;
        }

        public string Character()
        {
            return _fakerContainer.Random.Element(TwinPeaksData.Characters);
        }

        public string Location()
        {
            return _fakerContainer.Random.Element(TwinPeaksData.Locations);
        }

        public string Quote()
        {
            return _fakerContainer.Random.Element(TwinPeaksData.Quotes);
        }
    }
}
