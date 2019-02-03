using FakeItEasy;
using FakerDotNet.Data;
using FakerDotNet.Fakers;
using NUnit.Framework;

namespace FakerDotNet.Tests.Fakers
{
    [TestFixture]
    [Parallelizable]
    public class CommerceFakerTests
    {
        [SetUp]
        public void SetUp()
        {
            _fakerContainer = A.Fake<IFakerContainer>();
            _commerceFaker = new CommerceFaker(_fakerContainer);
        }

        private IFakerContainer _fakerContainer;
        private ICommerceFaker _commerceFaker;

        [Test]
        public void Color_returns_a_color()
        {
            A.CallTo(() => _fakerContainer.Color.ColorName())
                .Returns("lavender");

            Assert.AreEqual("lavender", _commerceFaker.Color());
        }

        [Test]
        public void Department_returns_a_department()
        {
            A.CallTo(() => _fakerContainer.Number.Between(1, 3))
                .Returns(3);
            A.CallTo(() => _fakerContainer.Random.Assortment(CommerceData.Departments, 3))
                .Returns(new[] {"Grocery", "Health", "Beauty"});

            Assert.AreEqual("Grocery, Health & Beauty", _commerceFaker.Department());
        }

        [Test]
        public void Department_returns_a_department_with_a_maximum_specified_number_of_categories()
        {
            A.CallTo(() => _fakerContainer.Number.Between(1, 5))
                .Returns(4);
            A.CallTo(() => _fakerContainer.Random.Assortment(CommerceData.Departments, 4))
                .Returns(new[] {"Grocery", "Books", "Health", "Beauty"});

            Assert.AreEqual("Grocery, Books, Health & Beauty & Tools", _commerceFaker.Department(5));
        }

        [Test]
        public void Department_returns_a_department_with_a_fixed_number_of_categories()
        {
            A.CallTo(() => _fakerContainer.Random.Assortment(CommerceData.Departments, 2))
                .Returns(new[] {"Books", "Tools"});

            Assert.AreEqual("Books & Tools", _commerceFaker.Department(2, true));
        }

        [Test]
        public void Material_returns_a_material()
        {
            A.CallTo(() => _fakerContainer.Random.Element(CommerceData.Materials))
                .Returns("Steel");

            Assert.AreEqual("Steel", _commerceFaker.Material());
        }

        [Test]
        public void ProductName_returns_a_product_name()
        {
            A.CallTo(() => _fakerContainer.Random.Element(CommerceData.ProductAdjectives))
                .Returns("Practical");
            A.CallTo(() => _fakerContainer.Random.Element(CommerceData.Materials))
                .Returns("Granite");
            A.CallTo(() => _fakerContainer.Random.Element(CommerceData.ProductNames))
                .Returns("Shirt");

            Assert.AreEqual("Practical Granite Shirt", _commerceFaker.ProductName());
        }

        [Test]
        public void Price_returns_a_price()
        {
            A.CallTo(() => _fakerContainer.Number.Between(0, 100))
                .Returns(44.602312);

            Assert.AreEqual("44.6", _commerceFaker.Price());
        }

        [Test]
        public void Price_returns_a_price_in_the_specified_range()
        {
            A.CallTo(() => _fakerContainer.Number.Between(0, 10))
                .Returns(2.18324);

            Assert.AreEqual("2.18", _commerceFaker.Price(new Range<double>(0, 10)));
        }

        [Test]
        public void PromotionCode_returns_a_promotion_code()
        {
            A.CallTo(() => _fakerContainer.Random.Element(CommerceData.PromotionCodeAdjectives))
                .Returns("Amazing");
            A.CallTo(() => _fakerContainer.Random.Element(CommerceData.PromotionCodeNouns))
                .Returns("Deal");
            A.CallTo(() => _fakerContainer.Number.Number(6))
                .Returns("829102");

            Assert.AreEqual("AmazingDeal829102", _commerceFaker.PromotionCode());
        }

        [Test]
        public void PromotionCode_returns_a_promotion_code_with_the_specified_number_of_digits()
        {
            A.CallTo(() => _fakerContainer.Random.Element(CommerceData.PromotionCodeAdjectives))
                .Returns("Amazing");
            A.CallTo(() => _fakerContainer.Random.Element(CommerceData.PromotionCodeNouns))
                .Returns("Deal");
            A.CallTo(() => _fakerContainer.Number.Number(2))
                .Returns("57");

            Assert.AreEqual("AmazingDeal57", _commerceFaker.PromotionCode(2));
        }
    }
}
