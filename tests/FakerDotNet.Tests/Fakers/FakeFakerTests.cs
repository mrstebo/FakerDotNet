using System;
using FakeItEasy;
using FakerDotNet.Fakers;
using FakerDotNet.Wrappers;
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
            _stackTraceWrapper = A.Fake<IStackTraceWrapper>();
            _fakeFaker = new FakeFaker(_fakerContainer, _stackTraceWrapper);
        }

        private IFakerContainer _fakerContainer;
        private IStackTraceWrapper _stackTraceWrapper;
        private IFakeFaker _fakeFaker;

        [Test]
        public void F_handles_duplicate_placeholders()
        {
            const string format = "{Name.FirstName} {Name.FirstName}";

            A.CallTo(() => _fakerContainer.Name.FirstName()).ReturnsNextFromSequence("Test1", "Test2");

            Assert.AreEqual("Test1 Test2", _fakeFaker.F(format));
        }

        [Test]
        public void F_returns_filled_in_string()
        {
            const string format = "{Name.FirstName} {Name.LastName}";

            A.CallTo(() => _fakerContainer.Name.FirstName()).Returns("John");
            A.CallTo(() => _fakerContainer.Name.LastName()).Returns("Smith");

            Assert.AreEqual("John Smith", _fakeFaker.F(format));
        }

        [Test]
        public void F_is_not_case_sensitive()
        {
            const string format = "{Name.firstName} {name.lastname}";

            A.CallTo(() => _fakerContainer.Name.FirstName()).Returns("John");
            A.CallTo(() => _fakerContainer.Name.LastName()).Returns("Smith");

            Assert.AreEqual("John Smith", _fakeFaker.F(format));
        }

        [Test]
        public void F_with_empty_string_returns_back_the_empty_string()
        {
            const string format = "";

            Assert.AreEqual(format, _fakeFaker.F(format));
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

        [Test]
        public void F_with_null_returns_an_empty_string()
        {
            Assert.AreEqual(string.Empty, _fakeFaker.F(null));
        }

        [Test]
        public void F_with_only_method_name_calls_method_from_callee_module()
        {
            const string format = "{FirstName}";

            A.CallTo(() => _stackTraceWrapper.GetClassAtFrame(2))
                .Returns("Name");
            A.CallTo(() => _fakerContainer.Name.FirstName())
                .Returns("John");

            Assert.AreEqual("John", _fakeFaker.F(format));
        }

        [Test]
        public void F_with_only_method_name_throws_when_module_not_found()
        {
            const string format = "{FirstName}";

            A.CallTo(() => _stackTraceWrapper.GetClassAtFrame(2))
                .Returns("NonExistentFaker");

            var ex = Assert.Throws<FormatException>(() => _fakeFaker.F(format));

            Assert.AreEqual("Invalid module: NonExistent", ex.Message);
        }
        
        [Test]
        public void F_with_only_method_name_throws_when_method_not_found_in_module()
        {
            const string format = "{BadMethod}";

            A.CallTo(() => _stackTraceWrapper.GetClassAtFrame(2))
                .Returns("Name");

            var ex = Assert.Throws<FormatException>(() => _fakeFaker.F(format));

            Assert.AreEqual("Invalid method: Name.BadMethod", ex.Message);
        }
    }
}
