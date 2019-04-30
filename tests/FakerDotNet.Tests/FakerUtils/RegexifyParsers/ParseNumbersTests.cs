using FakeItEasy;
using FakerDotNet.FakerUtils.RegexifyParsers;
using NUnit.Framework;

namespace FakerDotNet.Tests.FakerUtils.RegexifyParsers
{
    [TestFixture]
    [Parallelizable]
    public class ParseNumbersTests
    {
        [SetUp]
        public void SetUp()
        {
            _fakerContainer = A.Fake<IFakerContainer>();
            _parser = new ParseNumbers(_fakerContainer);
        }

        private IFakerContainer _fakerContainer;
        private IRegexifyParser _parser;

        [Test]
        public void Run_only_parses_number_regex()
        {
            const string pattern = @"John Smith is \d\d years old";

            A.CallTo(() => _fakerContainer.Number.Digit())
                .ReturnsNextFromSequence("5", "4");

            Assert.AreEqual(@"John Smith is 54 years old", _parser.Run(pattern));
        }

        [Test]
        public void Run_returns_a_number_when_pattern_contains_number_regex()
        {
            const string pattern = @"\d";

            A.CallTo(() => _fakerContainer.Number.Digit())
                .Returns("2");

            Assert.AreEqual(@"2", _parser.Run(pattern));
        }

        [Test]
        public void Run_returns_multiple_numbers_for_all_number_regex()
        {
            const string pattern = @"\d\d \d \d\d\d";

            A.CallTo(() => _fakerContainer.Number.Digit())
                .ReturnsNextFromSequence("2", "4", "1", "3", "2", "6");

            Assert.AreEqual(@"24 1 326", _parser.Run(pattern));
        }
    }
}