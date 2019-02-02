using FakerDotNet.Data;

namespace FakerDotNet.Fakers
{
    public interface IChuckNorrisFaker
    {
        string Fact();
    }

    internal class ChuckNorrisFaker : IChuckNorrisFaker
    {
        private readonly IFakerContainer _fakerContainer;

        public ChuckNorrisFaker(IFakerContainer _fakerContainer)
        {
            this._fakerContainer = _fakerContainer;
        }
        
        public string Fact()
        {
            return _fakerContainer.Random.Element(ChuckNorrisData.Facts);
        }
    }
}
