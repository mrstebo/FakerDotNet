using FakerDotNet.Data;

namespace FakerDotNet.Fakers
{
    public interface IZeldaFaker
    {
        string Game();
        string Character();
        string Location();
        string Item();
    }

    internal class ZeldaFaker : IZeldaFaker
    {
        private readonly IFakerContainer _fakerContainer;

        public ZeldaFaker(IFakerContainer faker)
        {
            this._fakerContainer = faker;
        }

        public string Character()
        {
            return _fakerContainer.Random.Element(ZeldaData.Characters);
        }

        public string Game()
        {
            return _fakerContainer.Random.Element(ZeldaData.Games);
        }

        public string Item()
        {
            return _fakerContainer.Random.Element(ZeldaData.Items);
        }

        public string Location()
        {
            return _fakerContainer.Random.Element(ZeldaData.Locations);
        }
    }
}
