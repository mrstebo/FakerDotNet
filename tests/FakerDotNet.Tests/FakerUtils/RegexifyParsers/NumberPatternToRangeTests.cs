using FakerDotNet.FakerUtils.RegexifyParsers;
using NUnit.Framework;

namespace FakerDotNet.Tests.FakerUtils.RegexifyParsers
{
    [TestFixture]
    [Parallelizable]
    public class NumberPatternToRangeTests
    {
        [SetUp]
        public void SetUp()
        {
            _parser = new NumberPatternToRange();
        }

        private IRegexifyParser _parser;

        [Test]
        public void Run_turns_numbers_surrounded_by_curly_braces_into_number_range()
        {
            const string pattern = @"{2}";

            Assert.AreEqual(@"{2,2}", _parser.Run(pattern));
        }

        [Test]
        public void Run_turns_question_mark_into_number_range()
        {
            const string pattern = @"?";

            Assert.AreEqual(@"{0,1}", _parser.Run(pattern));
        }
    }
}