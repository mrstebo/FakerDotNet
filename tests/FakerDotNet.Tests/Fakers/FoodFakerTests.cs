using FakeItEasy;
using FakerDotNet.Data;
using FakerDotNet.Fakers;
using NUnit.Framework;

namespace FakerDotNet.Tests.Fakers
{
    [TestFixture]
    [Parallelizable]
    public class FoodFakerTests
    {
        [SetUp]
        public void SetUp()
        {
            _fakerContainer = A.Fake<IFakerContainer>();
            _foodFaker = new FoodFaker(_fakerContainer);
        }

        private IFakerContainer _fakerContainer;
        private IFoodFaker _foodFaker;

        [Test]
        public void Description_returns_a_description()
        {
            A.CallTo(() => _fakerContainer.Random.Element(FoodData.Descriptions))
                .Returns(
                    "Three eggs with cilantro, tomatoes, onions, avocados and melted Emmental cheese. With a side of roasted potatoes, and your choice of toast or croissant.");

            Assert.AreEqual(
                "Three eggs with cilantro, tomatoes, onions, avocados and melted Emmental cheese. With a side of roasted potatoes, and your choice of toast or croissant.",
                _foodFaker.Description());
        }

        [Test]
        public void Dish_returns_a_dish()
        {
            A.CallTo(() => _fakerContainer.Random.Element(FoodData.Dishes))
                .Returns("Caesar Salad");

            Assert.AreEqual("Caesar Salad", _foodFaker.Dish());
        }

        [Test]
        public void Fruit_returns_a_fruit()
        {
            A.CallTo(() => _fakerContainer.Random.Element(FoodData.Fruits))
                .Returns("Peaches");

            Assert.AreEqual("Peaches", _foodFaker.Fruit());
        }

        [Test]
        public void Ingredient_returns_an_ingredient()
        {
            A.CallTo(() => _fakerContainer.Random.Element(FoodData.Ingredients))
                .Returns("Adzuki Beans");

            Assert.AreEqual("Adzuki Beans", _foodFaker.Ingredient());
        }

        [Test]
        public void Spice_returns_a_spice()
        {
            A.CallTo(() => _fakerContainer.Random.Element(FoodData.Spices))
                .Returns("Caraway Seed");

            Assert.AreEqual("Caraway Seed", _foodFaker.Spice());
        }

        [Test]
        public void Sushi_returns_a_sushi()
        {
            A.CallTo(() => _fakerContainer.Random.Element(FoodData.Sushi))
                .Returns("Caesar Salad");

            Assert.AreEqual("Caesar Salad", _foodFaker.Sushi());
        }

        [Test]
        public void Vegetable_returns_a_vegetable()
        {
            A.CallTo(() => _fakerContainer.Random.Element(FoodData.Vegetables))
                .Returns("Sea bream");

            Assert.AreEqual("Sea bream", _foodFaker.Vegetable());
        }

        [Test]
        public void Measurement_returns_a_measurement()
        {
            A.CallTo(() => _fakerContainer.Random.Element(FoodData.MeasurementSizes))
                .Returns("1/4");
            A.CallTo(() => _fakerContainer.Random.Element(FoodData.Measurements))
                .Returns("tablespoon");

            Assert.AreEqual("1/4 tablespoon", _foodFaker.Measurement());
        }

        [Test]
        public void MetricMeasurement_returns_a_metric_measurement()
        {
            A.CallTo(() => _fakerContainer.Random.Element(FoodData.MetricMeasurements))
                .Returns("centiliter");

            Assert.AreEqual("centiliter", _foodFaker.MetricMeasurement());
        }
    }
}
