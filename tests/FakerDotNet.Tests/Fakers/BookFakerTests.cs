using System.Collections.Generic;
using FakeItEasy;
using FakerDotNet.Data;
using FakerDotNet.Fakers;
using NUnit.Framework;

namespace FakerDotNet.Tests.Fakers
{
    [TestFixture]
    [Parallelizable]
    public class BookFakerTests
    {
        [SetUp]
        public void SetUp()
        {
            _fakerContainer = A.Fake<IFakerContainer>();
            _bookFaker = new BookFaker(_fakerContainer);
        }

        private IFakerContainer _fakerContainer;
        private IBookFaker _bookFaker;

        [Test]
        public void Title_returns_a_title()
        {
            A.CallTo(() => _fakerContainer.Random.Element(BookData.Titles))
                .Returns("The Odd Sister");

            Assert.AreEqual("The Odd Sister", _bookFaker.Title());
        }

        [Test]
        public void Author_returns_an_author()
        {
            A.CallTo(() => _fakerContainer.Name.FirstName()).Returns("Alysha");
            A.CallTo(() => _fakerContainer.Name.LastName()).Returns("Olsen");

            Assert.AreEqual("Alysha Olsen", _bookFaker.Author());
        }

        [Test]
        public void Publisher_returns_a_publisher()
        {
            A.CallTo(() => _fakerContainer.Random.Element(BookData.Publishers))
                .Returns("Opus Reader");

            Assert.AreEqual("Opus Reader", _bookFaker.Publisher());
        }

        [Test]
        public void Genre_returns_a_genre()
        {
            A.CallTo(() => _fakerContainer.Random.Element(BookData.Genres))
                .Returns("Mystery");

            Assert.AreEqual("Mystery", _bookFaker.Genre());
        }
    }
}
