using FakerDotNet.Data;

namespace FakerDotNet.Fakers
{
    public interface IFoodFaker
    {
        string Description();
        string Dish();
        string Fruit();
        string Ingredient();
        string Spice();
        string Sushi();
        string Vegetable();
        string Measurement();
        string MetricMeasurement();
    }
    
    internal class FoodFaker : IFoodFaker
    {
        private readonly IFakerContainer _fakerContainer;

        public FoodFaker(IFakerContainer _fakerContainer)
        {
            this._fakerContainer = _fakerContainer;
        }

        public string Description()
        {
            return _fakerContainer.Random.Element(FoodData.Descriptions);
        }

        public string Dish()
        {
            return _fakerContainer.Random.Element(FoodData.Dishes);
        }

        public string Fruit()
        {
            return _fakerContainer.Random.Element(FoodData.Fruits);
        }

        public string Ingredient()
        {
            return _fakerContainer.Random.Element(FoodData.Ingredients);
        }

        public string Spice()
        {
            return _fakerContainer.Random.Element(FoodData.Spices);
        }

        public string Sushi()
        {
            return _fakerContainer.Random.Element(FoodData.Sushi);
        }

        public string Vegetable()
        {
            return _fakerContainer.Random.Element(FoodData.Vegetables);
        }

        public string Measurement()
        {
            return string.Join(" ",
                _fakerContainer.Random.Element(FoodData.MeasurementSizes),
                _fakerContainer.Random.Element(FoodData.Measurements));
        }

        public string MetricMeasurement()
        {
            return _fakerContainer.Random.Element(FoodData.MetricMeasurements);
        }
    }
}
