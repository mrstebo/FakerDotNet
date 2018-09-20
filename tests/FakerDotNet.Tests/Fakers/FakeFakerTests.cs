using System;
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
        public void F_handles_duplicate_placeholders()
        {
            const string format = "{Name.FirstName} {Name.FirstName}";

            A.CallTo(() => _fakerContainer.Name.FirstName()).ReturnsNextFromSequence("Test1", "Test2");

            Assert.AreEqual("Test1 Test2", _fakeFaker.F(format));
        }

        [Test]
        public void F_with_invalid_faker_throws_FormatException()
        {
            const string format = "{Unknown.Test}";

            var ex = Assert.Throws<FormatException>(() => _fakeFaker.F(format));

            Assert.AreEqual("Invalid module: Unknown", ex.Message);
        }

        [Test]
        public void F_with_invalid_method_throws_FormatException()
        {
            const string format = "{Name.BadMethod}";

            var ex = Assert.Throws<FormatException>(() => _fakeFaker.F(format));

            Assert.AreEqual("Invalid method: Name.BadMethod", ex.Message);
        }
    }
}
