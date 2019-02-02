using System;
using FakeItEasy;
using FakerDotNet.Fakers;
using NUnit.Framework;

namespace FakerDotNet.Tests.Fakers
{
    [TestFixture]
    [Parallelizable]
    public class AvatarFakerTests
    {
        [SetUp]
        public void SetUp()
        {
            _fakerContainer = A.Fake<IFakerContainer>();
            _avatarFaker = new AvatarFaker(_fakerContainer);
        }

        private IFakerContainer _fakerContainer;
        private IAvatarFaker _avatarFaker;

        [Test]
        public void Image_returns_an_image_url()
        {
            A.CallTo(() => _fakerContainer.Lorem.Words(3, false))
                .Returns(new[] {"sit", "sequi", "quia"});

            Assert.AreEqual("https://robohash.org/sitsequiquia.png?size=300x300&set=set1",
                _avatarFaker.Image());
        }

        [Test]
        public void Image_returns_an_image_url_with_specified_slug()
        {
            Assert.AreEqual("https://robohash.org/my-own-slug.png?size=300x300&set=set1",
                _avatarFaker.Image("my-own-slug"));
        }

        [Test]
        [TestCase("50x50")]
        [TestCase("120x80")]
        public void Image_returns_an_image_url_with_specified_size(string size)
        {
            Assert.AreEqual($"https://robohash.org/my-own-slug.png?size={size}&set=set1",
                _avatarFaker.Image("my-own-slug", size));
        }

        [Test]
        [TestCase("120x321x43")]
        [TestCase("bad-format")]
        [TestCase("A0x20")]
        public void Image_with_invalid_size_throws_ArgumentException(string size)
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                _avatarFaker.Image("my-own-slug", size));

            Assert.That(ex.Message.StartsWith("Size should be specified in the format 300x300"));
        }

        [Test]
        [TestCase("jpg")]
        [TestCase("bmp")]
        public void Image_returns_an_image_url_with_specified_format(string format)
        {
            Assert.AreEqual($"https://robohash.org/my-own-slug.{format}?size=50x50&set=set1",
                _avatarFaker.Image("my-own-slug", "50x50", format));
        }

        [Test]
        [TestCase("mp3")]
        [TestCase("flac")]
        [TestCase("jpeg")]
        public void Image_with_unsupported_format_throws_ArgumentException(string format)
        {
            var formats = string.Join(", ", AvatarFaker.SupportedFormats);

            var ex = Assert.Throws<ArgumentException>(() =>
                _avatarFaker.Image("my-own-slug", "300x300", format));

            Assert.That(ex.Message.StartsWith($"Supported formats are {formats}"));
        }

        [Test]
        public void Image_returns_an_image_url_with_specified_set()
        {
            Assert.AreEqual("https://robohash.org/my-own-slug.bmp?size=50x50&set=set2",
                _avatarFaker.Image("my-own-slug", "50x50", "bmp", "set2"));
        }

        [Test]
        public void Image_returns_an_image_url_with_specified_bgset()
        {
            Assert.AreEqual("https://robohash.org/my-own-slug.bmp?size=50x50&set=set1&bgset=bg1",
                _avatarFaker.Image("my-own-slug", "50x50", "bmp", "set1", "bg1"));
        }
    }
}
