using System;
using FakeItEasy;
using FakerDotNet.Fakers;
using NUnit.Framework;

namespace FakerDotNet.Tests.Fakers
{
    [TestFixture]
    [Parallelizable]
    public class PlaceholditFakerTests
    {
        [SetUp]
        public void SetUp()
        {
            _fakerContainer = A.Fake<IFakerContainer>();
            _placeholditFaker = new PlaceholditFaker(_fakerContainer);
        }

        private IFakerContainer _fakerContainer;
        private IPlaceholditFaker _placeholditFaker;

        [Test]
        public void Image_returns_an_image_url()
        {
            Assert.AreEqual(
                "https://placehold.it/300x300.png",
                _placeholditFaker.Image());
        }

        [Test]
        public void Image_returns_an_image_url_with_the_specified_size()
        {
            Assert.AreEqual(
                "https://placehold.it/50x50.png",
                _placeholditFaker.Image("50x50"));
        }

        [Test]
        public void Image_throws_ArgumentException_when_size_is_not_in_a_valid_format()
        {
            var ex = Assert.Throws<ArgumentException>(() => 
                _placeholditFaker.Image("ABCxDEF"));

            Assert.That(ex.Message.StartsWith("Size should be specified in format 300x300"));
        }

        [Test]
        public void Image_returns_an_image_url_with_the_specified_format()
        {
            Assert.AreEqual(
                "https://placehold.it/50x50.png",
                _placeholditFaker.Image("50x50", "png"));
            Assert.AreEqual(
                "https://placehold.it/50x50.jpg",
                _placeholditFaker.Image("50x50", "jpg"));
            Assert.AreEqual(
                "https://placehold.it/50x50.gif",
                _placeholditFaker.Image("50x50", "gif"));
            Assert.AreEqual(
                "https://placehold.it/50x50.jpeg",
                _placeholditFaker.Image("50x50", "jpeg"));
        }

        [Test]
        public void Image_throws_ArgumentException_when_format_is_not_supported()
        {
            var supportedFormats = string.Join(", ", PlaceholditFaker.SupportedFormats);
            
            var ex = Assert.Throws<ArgumentException>(() =>
                _placeholditFaker.Image("50x50", "bmp"));
            
            Assert.That(ex.Message.StartsWith($"Supported formats are {supportedFormats}"));
        }

        [Test]
        public void Image_returns_an_image_url_with_the_specified_background_color()
        {
            Assert.AreEqual(
                "https://placehold.it/50x50.gif/ffffff",
                _placeholditFaker.Image("50x50", "gif", "ffffff"));
        }

        [Test]
        public void Image_returns_an_image_url_with_a_random_background_color()
        {
            A.CallTo(() => _fakerContainer.Color.HexColor())
                .Returns("#39eba7");
            
            Assert.AreEqual(
                "https://placehold.it/50x50.jpeg/39eba7",
                _placeholditFaker.Image("50x50", "jpeg", RandomColor.Value));
        }

        [Test]
        public void Image_throws_ArgumentException_when_background_color_contains_hash()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                _placeholditFaker.Image("50x50", "gif", "#000"));

            Assert.That(ex.Message.StartsWith("backgroundColor must be a hex value without '#'"));
        }

        [Test]
        public void Image_returns_an_image_url_with_the_specified_text_color()
        {
            Assert.AreEqual(
                "https://placehold.it/50x50.jpeg/ffffff/000",
                _placeholditFaker.Image("50x50", "jpeg", "ffffff", "000"));
        }

        [Test]
        public void Image_returns_an_image_url_with_a_random_text_color()
        {
            A.CallTo(() => _fakerContainer.Color.HexColor())
                .ReturnsNextFromSequence("#d39e44", "#888ba7");
            
            Assert.AreEqual(
                "https://placehold.it/50x50.jpeg/d39e44/888ba7",
                _placeholditFaker.Image("50x50", "jpeg", RandomColor.Value, RandomColor.Value));
        }

        [Test]
        public void Image_throws_ArgumentException_when_text_color_contains_hash()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                _placeholditFaker.Image("50x50", "gif", "ffffff", "#000"));

            Assert.That(ex.Message.StartsWith("textColor must be a hex value without '#'"));
        }

        [Test]
        public void Image_returns_an_image_url_with_the_specified_text()
        {
            Assert.AreEqual(
                "https://placehold.it/50x50.jpg/ffffff/000?text=Some Custom Text",
                _placeholditFaker.Image("50x50", "jpg", "ffffff", "000", "Some Custom Text"));
        }
    }
}
