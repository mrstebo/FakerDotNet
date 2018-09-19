using FakeItEasy;
using FakerDotNet.Fakers;
using NUnit.Framework;

namespace FakerDotNet.Tests.Fakers
{
    [TestFixture]
    [Parallelizable]
    public class FakeFakerTests
    {
        [SetUp]
        public void SetUp()
        {
            _fakerContainer = A.Fake<IFakerContainer>();
            _fakeFaker = new FakeFaker(_fakerContainer);
        }

        private IFakerContainer _fakerContainer;
        private IFakeFaker _fakeFaker;

        [Test]
        public void F_returns_filled_in_string()
        {
            const string format = "{Name.FirstName} {Name.LastName}";
            
            A.CallTo(() => _fakerContainer.Name.FirstName()).Returns("John");
            A.CallTo(() => _fakerContainer.Name.LastName()).Returns("Smith");
            
            Assert.AreEqual("John Smith", _fakeFaker.F(format));
        }

        [Test]
        public void F_with_not_found_faker_does_not_convert_it()
        {
            const string format = "{Unknown.Test}";
            
            Assert.AreEqual(format, _fakeFaker.F(format));
        }
    }
}