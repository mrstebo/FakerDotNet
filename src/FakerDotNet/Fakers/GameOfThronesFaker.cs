using FakerDotNet.Data;

namespace FakerDotNet.Fakers
{
    public interface IGameOfThronesFaker
    {
        string Character();
        string House();
        string City();
        string Quote();
        string Dragon();
    }

    internal class GameOfThronesFaker : IGameOfThronesFaker
    {
        private readonly IFakerContainer _fakerContainer;

        public GameOfThronesFaker(IFakerContainer faker)
        {
            _fakerContainer = faker;
        }

        public string Character()
        {
            return _fakerContainer.Random.Element(GameOfThronesData.Characters);
        }

        public string House()
        {
            return _fakerContainer.Random.Element(GameOfThronesData.Houses);
        }

        public string City()
        {
            return _fakerContainer.Random.Element(GameOfThronesData.Cities);
        }

        public string Quote()
        {
            return _fakerContainer.Random.Element(GameOfThronesData.Quotes);
        }

        public string Dragon()
        {
            return _fakerContainer.Random.Element(GameOfThronesData.Dragons);
        }
    }
}
