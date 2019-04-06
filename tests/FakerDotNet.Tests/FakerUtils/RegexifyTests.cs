using FakeItEasy;
using FakerDotNet.FakerUtils;
using NUnit.Framework;

namespace FakerDotNet.Tests.FakerUtils
{
    [TestFixture]
    [Parallelizable]
    public class RegexifyTests
    {
        [SetUp]
        public void SetUp()
        {
            _fakerContainer = A.Fake<IFakerContainer>();
            _regexify = new Regexify(_fakerContainer);
        }

        private IFakerContainer _fakerContainer;
        private IRegexify _regexify;
        
        [Test]
        public void Parse_returns_empty_string_when_pattern_is_null()
        {
            const string pattern = null;

            Assert.AreEqual("", _regexify.Parse(pattern));
        }
        
        [Test]
        public void Parse_returns_empty_string_when_pattern_is_an_empty_string()
        {
            const string pattern = "";

            Assert.AreEqual("", _regexify.Parse(pattern));
        }

        [Test]
        public void Parse_returns_a_string_from_a_pattern()
        {
            const string pattern =
                @"^[A-PR-UWYZ0-9][A-HK-Y0-9][AEHMNPRTVXY0-9]?[ABEHMNPRVWXY0-9]? {1,2}[0-9][ABD-HJLN-UW-Z]{2}$";
            
            Assert.AreEqual("U3V  3TP", _regexify.Parse(pattern));
        }

        [Test]
        [TestCase(@"^hello")]
        [TestCase(@"hello$")]
        [TestCase(@"^hello$")]
        public void Parse_removes_anchors(string pattern)
        {
            Assert.AreEqual("hello", _regexify.Parse(pattern));
        }

        [Test]
        public void Parse_turns_question_mark_into_number_range()
        {
            const string pattern = "?";
            
            Assert.AreEqual("{0,1}", _regexify.Parse(pattern));
        }

        [Test]
        public void Parse_returns_a_number_when_pattern_contains_number_regex()
        {
            const string pattern = @"(\d+)";
            
            Assert.AreEqual("2", _regexify.Parse(pattern));
        }

        [Test]
        public void Parse_parses_range_patterns()
        {
            const string pattern = "[12]{1,2}";

            A.CallTo(() => _fakerContainer.Number.Between(1, 2))
                .Returns(2);
            
            Assert.AreEqual("[12][12]", _regexify.Parse(pattern));
        }
    }
}
