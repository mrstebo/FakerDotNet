using FakeItEasy;
using FakerDotNet.Fakers;
using NUnit.Framework;

namespace FakerDotNet.Tests.Fakers
{
    [TestFixture]
    [Parallelizable]
    public class FillmurrayFakerTests
    {
        [SetUp]
        public void SetUp()
        {
            _fillmurrayFaker = new FillmurrayFaker();
        }

        private IFillmurrayFaker _fillmurrayFaker;

        [Test]
        public void Image_returns_an_image_url()
        {
            Assert.AreEqual(
                "https://fillmurray.com/200/200",
                _fillmurrayFaker.Image());
        }

        [Test]
        public void Image_returns_an_image_url_for_a_grayscale_image_when_specified()
        {
            Assert.AreEqual(
                "https://fillmurray.com/g/200/200",
                _fillmurrayFaker.Image(true));
        }

        [Test]
        public void Image_returns_an_image_url_with_the_specified_width()
        {
            Assert.AreEqual(
                "https://fillmurray.com/300/200",
                _fillmurrayFaker.Image(false, 300));
        }
        
        [Test]
        public void Image_returns_an_image_url_with_the_specified_height()
        {
            Assert.AreEqual(
                "https://fillmurray.com/200/400",
                _fillmurrayFaker.Image(false, 200, 400));
        }
    }
}
