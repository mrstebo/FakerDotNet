using FakeItEasy;
using FakerDotNet.Data;
using FakerDotNet.Fakers;
using NUnit.Framework;
using System.Collections.Generic;

namespace FakerDotNet.Tests.Fakers
{
    [TestFixture]
    [SetCulture("en-GB")]
    [Parallelizable]
    public class BeerFakerTests
    {
        [SetUp]
        public void SetUp()
        {
            _fakerContainer = A.Fake<IFakerContainer>();
            _beerFaker = new BeerFaker(_fakerContainer);
        }

        private static readonly BeerData Data = new BeerData();

        private IFakerContainer _fakerContainer;
        private IBeerFaker _beerFaker;

        [Test]
        public void Brand_returns_a_brand()
        {
            A.CallTo(() => _fakerContainer.Random.Element(
                    A<IEnumerable<string>>.That.IsSameSequenceAs(Data.Brand)))
                .Returns("Pabst Blue Ribbon");

            Assert.AreEqual("Pabst Blue Ribbon", _beerFaker.Brand());
        }

        [Test]
        public void Name_returns_a_name()
        {
            A.CallTo(() => _fakerContainer.Random.Element(
                    A<IEnumerable<string>>.That.IsSameSequenceAs(Data.Name)))
                .Returns("La Fin Du Monde");

            Assert.AreEqual("La Fin Du Monde", _beerFaker.Name());
        }

        [Test]
        public void Style_returns_a_style()
        {
            A.CallTo(() => _fakerContainer.Random.Element(
                    A<IEnumerable<string>>.That.IsSameSequenceAs(Data.Style)))
                .Returns("Belgian Strong Ale");

            Assert.AreEqual("Belgian Strong Ale", _beerFaker.Style());
        }

        [Test]
        public void Hop_returns_a_hop()
        {
            A.CallTo(() => _fakerContainer.Random.Element(
                    A<IEnumerable<string>>.That.IsSameSequenceAs(Data.Hop)))
                .Returns("Cashmere");

            Assert.AreEqual("Cashmere", _beerFaker.Hop());
        }

        [Test]
        public void Yeast_returns_a_yeast()
        {
            A.CallTo(() => _fakerContainer.Random.Element(
                    A<IEnumerable<string>>.That.IsSameSequenceAs(Data.Yeast)))
                .Returns("1469 - West Yorkshire Ale");

            Assert.AreEqual("1469 - West Yorkshire Ale", _beerFaker.Yeast());
        }

        [Test]
        public void Malts_returns_a_malt()
        {
            A.CallTo(() => _fakerContainer.Random.Element(
                    A<IEnumerable<string>>.That.IsSameSequenceAs(Data.Malts)))
                .Returns("Victory");

            Assert.AreEqual("Victory", _beerFaker.Malts());
        }

        [Test]
        public void Ibu_is_valid()
        {
            A.CallTo(() => _fakerContainer.Number.Between(10, 100)).Returns(15.43D);

            Assert.AreEqual("15 IBU", _beerFaker.Ibu());
        }

        [Test]
        public void Alcohol_is_valid()
        {
            A.CallTo(() => _fakerContainer.Number.Between(2, 10)).Returns(8.73D);

            Assert.AreEqual("8.7%", _beerFaker.Alcohol());
        }

        [Test]
        public void Blg_is_valid()
        {
            A.CallTo(() => _fakerContainer.Number.Between(5, 20)).Returns(18.79D);

            Assert.AreEqual("18.8�Blg", _beerFaker.Blg());
        }
    }
}