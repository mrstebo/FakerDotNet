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
        private static readonly ZeldaData Data = new ZeldaData();
        private readonly IFakerContainer _fakerContainer;

        public ZeldaFaker(IFakerContainer faker)
        {
            this._fakerContainer = faker;
        }

        public string Character()
        {
            return _fakerContainer.Random.Element(Data.Characters);
        }

        public string Game()
        {
            return _fakerContainer.Random.Element(Data.Games);
        }

        public string Item()
        {
            return _fakerContainer.Random.Element(Data.Items);
        }

        public string Location()
        {
            return _fakerContainer.Random.Element(Data.Locations);
        }
    }
}
