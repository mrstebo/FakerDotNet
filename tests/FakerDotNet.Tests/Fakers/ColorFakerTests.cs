using FakeItEasy;
using FakerDotNet.Data;
using FakerDotNet.Fakers;
using NUnit.Framework;

namespace FakerDotNet.Tests.Fakers
{
    [TestFixture]
    [Parallelizable]
    public class ColorFakerTests
    {
        [SetUp]
        public void SetUp()
        {
            _fakerContainer = A.Fake<IFakerContainer>();
            _colorFaker = new ColorFaker(_fakerContainer);
        }

        private IFakerContainer _fakerContainer;
        private IColorFaker _colorFaker;

        [Test]
        public void HexColor_returns_a_hex_color_string()
        {
            A.CallTo(() => _fakerContainer.Number.Between(0, 0xffffff))
                .Returns(3254149);
            
            Assert.AreEqual("#31a785", _colorFaker.HexColor());
        }

        [Test]
        public void ColorName_returns_a_color_name()
        {
            A.CallTo(() => _fakerContainer.Random.Element(ColorData.Names))
                .Returns("yellow");
            
            Assert.AreEqual("yellow", _colorFaker.ColorName());
        }

        [Test]
        public void RgbColor_returns_a_rgb_color()
        {
            A.CallTo(() => _fakerContainer.Number.Between(0, 255))
                .ReturnsNextFromSequence(54, 233, 67);
            
            CollectionAssert.AreEqual(new byte[] {54, 233, 67}, _colorFaker.RgbColor());
        }

        [Test]
        public void HslColor_returns_a_hsl_color()
        {
            A.CallTo(() => _fakerContainer.Number.Between(0, 255))
                .ReturnsNextFromSequence(69.87, 0.66, 0.3);
            
            CollectionAssert.AreEqual(new[] {69.87, 0.66, 0.3}, _colorFaker.HslColor());
        }

        [Test]
        public void HslaColor_returns_a_hsla_color()
        {
            A.CallTo(() => _fakerContainer.Number.Between(0, 255))
                .ReturnsNextFromSequence(154.77, 0.36, 0.9);
            A.CallTo(() => _fakerContainer.Number.Between(0, 1))
                .Returns(0.26170574657729073);
            
            CollectionAssert.AreEqual(new[] {154.77, 0.36, 0.9, 0.26170574657729073}, _colorFaker.HslaColor());
        }
    }
}
