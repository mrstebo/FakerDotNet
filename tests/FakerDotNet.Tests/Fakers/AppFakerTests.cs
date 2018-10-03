using System.Collections.Generic;
using System.Linq;
using FakeItEasy;
using FakerDotNet.Data;
using FakerDotNet.Fakers;
using NUnit.Framework;

namespace FakerDotNet.Tests.Fakers
{
    [TestFixture]
    [Parallelizable]
    public class AppFakerTests
    {
        [SetUp]
        public void SetUp()
        {
            _fakerContainer = A.Fake<IFakerContainer>();
            _appFaker = new AppFaker(_fakerContainer);
        }

        private static readonly AppData Data = new AppData();

        private IFakerContainer _fakerContainer;
        private IAppFaker _appFaker;

        [Test]
        public void Author_returns_a_full_name()
        {
            A.CallTo(() => _fakerContainer.Name.FirstName()).Returns("John");
            A.CallTo(() => _fakerContainer.Name.LastName()).Returns("Smith");

            Assert.AreEqual("John Smith", _appFaker.Author());
        }

        [Test]
        public void Name_returns_a_name()
        {
            A.CallTo(() => _fakerContainer.Random.Element(
                    A<IEnumerable<string>>.That.IsSameSequenceAs(Data.Names)))
                .Returns("My App");

            Assert.AreEqual("My App", _appFaker.Name());
        }

        [Test]
        public void Version_returns_a_formatted_version()
        {
            var numbers = Enumerable.Range(0, 9);

            A.CallTo(() => _fakerContainer.Random.Element(
                    A<IEnumerable<string>>.That.IsSameSequenceAs(Data.Versions)))
                .Returns("0.#.#");
            A.CallTo(() => _fakerContainer.Random.Element(
                    A<IEnumerable<int>>.That.IsSameSequenceAs(numbers)))
                .ReturnsNextFromSequence(1, 2);

            Assert.AreEqual("0.1.2", _appFaker.Version());
        }
    }
}
