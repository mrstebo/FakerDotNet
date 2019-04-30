using FakeItEasy;
using FakerDotNet.FakerUtils.RegexifyParsers;
using NUnit.Framework;

namespace FakerDotNet.Tests.FakerUtils.RegexifyParsers
{
    [TestFixture]
    [Parallelizable]
    public class ParseRangesTests
    {
        [SetUp]
        public void SetUp()
        {
            _fakerContainer = A.Fake<IFakerContainer>();
            _parser = new ParseRanges(_fakerContainer);
        }

        private IFakerContainer _fakerContainer;
        private IRegexifyParser _parser;

        [Test]
        public void Run_returns_copies_of_character_within_specified_range_in_regex()
        {
            const string pattern = @"A{1,2}";

            A.CallTo(() => _fakerContainer.Number.Between(1, 2))
                .Returns(2);

            Assert.AreEqual("AA", _parser.Run(pattern));
        }

        [Test]
        public void Run_returns_copies_of_number_pattern_a_specified_number_of_times()
        {
            const string pattern = @"\d{3}";

            Assert.AreEqual(@"\d\d\d", _parser.Run(pattern));
        }

        [Test]
        public void Run_returns_copies_of_number_pattern_within_specified_range_in_regex()
        {
            const string pattern = @"\d{1,3}";

            A.CallTo(() => _fakerContainer.Number.Between(1, 3))
                .Returns(3);

            Assert.AreEqual(@"\d\d\d", _parser.Run(pattern));
        }

        [Test]
        public void Run_returns_duplicates_of_parenthesis_within_specified_range_in_regex()
        {
            const string pattern = @"(12|34){1,2}";

            A.CallTo(() => _fakerContainer.Number.Between(1, 2))
                .Returns(2);

            Assert.AreEqual(@"(12|34)(12|34)", _parser.Run(pattern));
        }

        [Test]
        public void Run_returns_duplicates_of_square_brackets_within_specified_range_in_regex()
        {
            const string pattern = @"[12]{1,2}";

            A.CallTo(() => _fakerContainer.Number.Between(1, 2))
                .Returns(2);

            Assert.AreEqual(@"[12][12]", _parser.Run(pattern));
        }
    }
}