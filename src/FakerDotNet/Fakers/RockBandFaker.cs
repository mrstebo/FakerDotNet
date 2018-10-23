using FakerDotNet.Data;

namespace FakerDotNet.Fakers
{
    public interface IRockBandFaker
    {
        string Name();
    }

    internal class RockBandFaker : IRockBandFaker
    {
        private readonly IFakerContainer _fakerContainer;

        public RockBandFaker(IFakerContainer fakerContainer)
        {
            _fakerContainer = fakerContainer;
        }

        public string Name()
        {
            return _fakerContainer.Random.Element(RockBandData.Name);
        }
    }
}
