using FakeItEasy;
using FakerDotNet.Fakers;
using NUnit.Framework;

namespace FakerDotNet.Tests.Fakers
{
    [TestFixture]
    [Parallelizable]
    public class LoremFlickrFakerTests
    {
        [SetUp]
        public void SetUp()
        {
            _fakerContainer = A.Fake<IFakerContainer>();
            _loremflickrFaker = new LoremFlickrFaker(_fakerContainer);
        }

        private IFakerContainer _fakerContainer;
        private ILoremFlickrFaker _loremflickrFaker;

        [Test]
        public void Image_returns_an_image_url()
        {
            Assert.AreEqual(
                "https://loremflickr.com/300/300",
                _loremflickrFaker.Image());
        }

        [Test]
        public void Image_returns_an_image_url_with_the_specified_size()
        {
            Assert.AreEqual(
                "https://loremflickr.com/50/60",
                _loremflickrFaker.Image("50x60"));
        }

        [Test]
        public void Image_returns_an_image_url_with_the_specified_search_term()
        {
            Assert.AreEqual(
                "https://loremflickr.com/50/60/sports",
                _loremflickrFaker.Image("50x60", new[] {"sports"}));
        }

        [Test]
        public void Image_returns_an_image_url_with_the_specified_search_terms()
        {
            Assert.AreEqual(
                "https://loremflickr.com/50/60/sports,fitness",
                _loremflickrFaker.Image("50x60", new[] {"sports", "fitness"}));
        }

        [Test]
        public void Image_returns_an_image_url_that_specifies_it_should_match_all_search_terms()
        {
            Assert.AreEqual(
                "https://loremflickr.com/50/60/sports,fitness/all",
                _loremflickrFaker.Image("50x60", new[] {"sports", "fitness"}, true));
        }

        [Test]
        public void GrayscaleImage_returns_a_grayscale_image_url()
        {
            Assert.AreEqual(
                "https://loremflickr.com/g/300/300",
                _loremflickrFaker.GrayscaleImage());
        }

        [Test]
        public void GrayscaleImage_returns_a_grayscale_image_url_with_the_specified_size()
        {
            Assert.AreEqual(
                "https://loremflickr.com/g/50/60",
                _loremflickrFaker.GrayscaleImage("50x60"));
        }

        [Test]
        public void GrayscaleImage_returns_a_grayscale_image_url_with_the_specified_search_term()
        {
            Assert.AreEqual(
                "https://loremflickr.com/g/50/60/sports",
                _loremflickrFaker.GrayscaleImage("50x60", new[] {"sports"}));
        }

        [Test]
        public void GrayscaleImage_returns_a_grayscale_image_url_with_the_specified_search_terms()
        {
            Assert.AreEqual(
                "https://loremflickr.com/g/50/60/sports,fitness",
                _loremflickrFaker.GrayscaleImage("50x60", new[] {"sports", "fitness"}));
        }

        [Test]
        public void GrayscaleImage_returns_a_grayscale_image_url_that_specifies_it_should_match_all_search_terms()
        {
            Assert.AreEqual(
                "https://loremflickr.com/g/50/60/sports,fitness/all",
                _loremflickrFaker.GrayscaleImage("50x60", new[] {"sports", "fitness"}, true));
        }

        [Test]
        public void PixelatedImage_returns_a_pixelated_image_url()
        {
            Assert.AreEqual(
                "https://loremflickr.com/p/300/300",
                _loremflickrFaker.PixelatedImage());
        }

        [Test]
        public void PixelatedImage_returns_a_pixelated_image_url_with_the_specified_size()
        {
            Assert.AreEqual(
                "https://loremflickr.com/p/50/60",
                _loremflickrFaker.PixelatedImage("50x60"));
        }

        [Test]
        public void PixelatedImage_returns_a_pixelated_image_url_with_the_specified_search_term()
        {
            Assert.AreEqual(
                "https://loremflickr.com/p/50/60/sports",
                _loremflickrFaker.PixelatedImage("50x60", new[] {"sports"}));
        }

        [Test]
        public void PixelatedImage_returns_a_pixelated_image_url_with_the_specified_search_terms()
        {
            Assert.AreEqual(
                "https://loremflickr.com/p/50/60/sports,fitness",
                _loremflickrFaker.PixelatedImage("50x60", new[] {"sports", "fitness"}));
        }

        [Test]
        public void PixelatedImage_returns_a_pixelated_image_url_that_specifies_it_should_match_all_search_terms()
        {
            Assert.AreEqual(
                "https://loremflickr.com/p/50/60/sports,fitness/all",
                _loremflickrFaker.PixelatedImage("50x60", new[] {"sports", "fitness"}, true));
        }

        [Test]
        public void ColorizedImage_returns_a_colorized_image_url()
        {
            Assert.AreEqual(
                "https://loremflickr.com/red/300/300",
                _loremflickrFaker.ColorizedImage());
        }

        [Test]
        public void ColorizedImage_returns_a_colorized_image_url_with_the_specified_size()
        {
            Assert.AreEqual(
                "https://loremflickr.com/red/50/60",
                _loremflickrFaker.ColorizedImage("50x60"));
        }

        [Test]
        public void ColorizedImage_returns_a_colorized_image_url_with_the_specified_color()
        {
            Assert.AreEqual(
                "https://loremflickr.com/red/50/60",
                _loremflickrFaker.ColorizedImage("50x60", "red"));
        }

        [Test]
        public void ColorizedImage_returns_a_colorized_image_url_with_the_specified_search_term()
        {
            Assert.AreEqual(
                "https://loremflickr.com/red/50/60/sports",
                _loremflickrFaker.ColorizedImage("50x60", "red", new[] {"sports"}));
        }

        [Test]
        public void ColorizedImage_returns_a_colorized_image_url_with_the_specified_search_terms()
        {
            Assert.AreEqual(
                "https://loremflickr.com/red/50/60/sports,fitness",
                _loremflickrFaker.ColorizedImage("50x60", "red", new[] {"sports", "fitness"}));
        }

        [Test]
        public void ColorizedImage_returns_a_colorized_image_url_that_specifies_it_should_match_all_search_terms()
        {
            Assert.AreEqual(
                "https://loremflickr.com/red/50/60/sports,fitness/all",
                _loremflickrFaker.ColorizedImage("50x60", "red", new[] {"sports", "fitness"}, true));
        }
    }
}
