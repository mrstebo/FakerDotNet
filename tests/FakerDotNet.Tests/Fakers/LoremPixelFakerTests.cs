using System;
using FakeItEasy;
using FakerDotNet.Fakers;
using NUnit.Framework;

namespace FakerDotNet.Tests.Fakers
{
    [TestFixture]
    [Parallelizable]
    public class LoremPixelFakerTests
    {
        [SetUp]
        public void SetUp()
        {
            _fakerContainer = A.Fake<IFakerContainer>();
            _lorempixelFaker = new LoremPixelFaker(_fakerContainer);
        }

        private IFakerContainer _fakerContainer;
        private ILoremPixelFaker _lorempixelFaker;

        [Test]
        public void Image_returns_an_image_url()
        {
            Assert.AreEqual(
                "https://lorempixel.com/300/300",
                _lorempixelFaker.Image());
        }

        [Test]
        public void Image_returns_an_image_url_with_the_specified_size()
        {
            Assert.AreEqual(
                "https://lorempixel.com/50/60",
                _lorempixelFaker.Image("50x60"));
        }

        [Test]
        public void Image_throws_ArgumentException_when_size_is_not_in_a_valid_format()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                _lorempixelFaker.Image("ABCxDEF"));

            Assert.That(ex.Message.StartsWith("Size should be specified in format 300x300"));
        }

        [Test]
        public void Image_returns_a_gray_image_url_when_is_gray_is_specified()
        {
            Assert.AreEqual(
                "https://lorempixel.com/g/50/60",
                _lorempixelFaker.Image("50x60", true));
        }

        [Test]
        public void Image_returns_an_image_url_with_the_specified_category()
        {
            Assert.AreEqual(
                "https://lorempixel.com/g/50/60/sports",
                _lorempixelFaker.Image("50x60", true, "sports"));
        }

        [Test]
        public void Image_throws_ArgumentException_when_format_is_not_supported()
        {
            var supportedCategories = string.Join(", ", LoremPixelFaker.SupportedCategories);

            var ex = Assert.Throws<ArgumentException>(() =>
                _lorempixelFaker.Image("50x50", false, "bad"));

            Assert.That(ex.Message.StartsWith($"Supported categories are {supportedCategories}"));
        }

        [Test]
        public void Image_returns_an_image_url_with_the_specified_number()
        {
            Assert.AreEqual(
                "https://lorempixel.com/g/50/60/sports/3",
                _lorempixelFaker.Image("50x60", true, "sports", 3));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(11)]
        public void Image_throws_ArgumentException_when_number_is_not_in_valid_range(int number)
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                _lorempixelFaker.Image("50x50", false, "sports", number));

            Assert.That(ex.Message.StartsWith("Number must be between 1 and 10"));
        }

        [Test]
        public void Image_throws_ArgumentException_when_number_is_not_supplied_with_category()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                _lorempixelFaker.Image("50x50", false, null, 3));

            Assert.That(ex.Message.StartsWith("Category required when number is passed"));
        }

        [Test]
        public void Image_returns_an_image_url_with_the_specified_text()
        {
            Assert.AreEqual(
                "https://lorempixel.com/g/50/60/sports/3/Dummy-text",
                _lorempixelFaker.Image("50x60", true, "sports", 3, "Dummy-text"));
        }

        [Test]
        public void Image_returns_an_image_url_with_the_specified_category_and_text()
        {
            Assert.AreEqual(
                "https://lorempixel.com/g/50/60/sports/Dummy-text",
                _lorempixelFaker.Image("50x60", true, "sports", null, "Dummy-text"));
        }

        [Test]
        public void Image_throw_ArgumentException_when_category_and_number_is_not_supplied_with_text()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                _lorempixelFaker.Image("50x50", false, null, null, "Dummy-text"));

            Assert.That(ex.Message.StartsWith("Category and number must be passed when text is passed"));
        }
    }
}
