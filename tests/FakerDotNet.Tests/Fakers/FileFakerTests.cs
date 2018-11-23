using FakeItEasy;
using FakerDotNet.Data;
using FakerDotNet.Fakers;
using NUnit.Framework;

namespace FakerDotNet.Tests.Fakers
{
    [TestFixture]
    [Parallelizable]
    public class FileFakerTests
    {
        [SetUp]
        public void SetUp()
        {
            _fakerContainer = A.Fake<IFakerContainer>();
            _fileFaker = new FileFaker(_fakerContainer);
        }

        private IFakerContainer _fakerContainer;
        private IFileFaker _fileFaker;

        [Test]
        public void Extensions_returns_a_file_extension()
        {
            A.CallTo(() => _fakerContainer.Random.Element(FileData.Extensions))
                .Returns("mp3");

            Assert.AreEqual("mp3", _fileFaker.Extension());
        }

        [Test]
        public void MimeTypes_returns_a_mime_type()
        {
            A.CallTo(() => _fakerContainer.Random.Element(FileData.MimeTypes))
                .Returns("application/pdf");

            Assert.AreEqual("application/pdf", _fileFaker.MimeType());
        }

        [Test]
        public void FileName_returns_a_file_name()
        {
            A.CallTo(() => _fakerContainer.Internet.Slug(null, null))
                .ReturnsNextFromSequence("my-path");
            A.CallTo(() => _fakerContainer.Lorem.Word())
                .Returns("SOMETHING_RANDOM");
            A.CallTo(() => _fakerContainer.Random.Element(FileData.Extensions))
                .Returns("jpg");

            Assert.AreEqual("my-path/something_random.jpg", _fileFaker.FileName());
        }

        [Test]
        public void FileName_returns_a_file_name_with_specified_directory()
        {
            A.CallTo(() => _fakerContainer.Lorem.Word())
                .Returns("SOMETHING_RANDOM");
            A.CallTo(() => _fakerContainer.Random.Element(FileData.Extensions))
                .Returns("jpg");

            Assert.AreEqual("path/to/something_random.jpg", _fileFaker.FileName("path/to"));
        }

        [Test]
        public void FileName_returns_a_file_name_with_specified_name()
        {
            A.CallTo(() => _fakerContainer.Random.Element(FileData.Extensions))
                .Returns("zip");

            Assert.AreEqual("foo/bar/baz.zip", _fileFaker.FileName("foo/bar", "baz"));
        }

        [Test]
        public void FileName_returns_a_file_name_with_specified_extension()
        {
            Assert.AreEqual("foo/bar/baz.doc", _fileFaker.FileName("foo/bar", "baz", "doc"));
        }

        [Test]
        public void FileName_returns_a_file_name_with_specified_directory_separator()
        {
            Assert.AreEqual(@"foo/bar\baz.mp3", _fileFaker.FileName("foo/bar", "baz", "mp3", @"\"));
        }
    }
}
