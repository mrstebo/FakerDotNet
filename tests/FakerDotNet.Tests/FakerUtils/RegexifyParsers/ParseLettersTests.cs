using FakeItEasy;
using FakerDotNet.FakerUtils.RegexifyParsers;
using NUnit.Framework;

namespace FakerDotNet.Tests.FakerUtils.RegexifyParsers
{
    [TestFixture]
    [Parallelizable]
    public class ParseLettersTests
    {
        [SetUp]
        public void SetUp()
        {
            _fakerContainer = A.Fake<IFakerContainer>();
            _parser = new ParseLetters(_fakerContainer);
        }

        private IFakerContainer _fakerContainer;
        private IRegexifyParser _parser;

        [Test]
        public void Run_only_parses_letter_regex()
        {
            const string pattern = @"ABC \w\w\w-\w";

            A.CallTo(() => _fakerContainer.Lorem.Character())
                .ReturnsNextFromSequence("f", "e", "d", "a");

            Assert.AreEqual(@"ABC fed-a", _parser.Run(pattern));
        }

        [Test]
        public void Run_returns_a_letter_when_pattern_contains_letter_regex()
        {
            const string pattern = @"\w";

            A.CallTo(() => _fakerContainer.Lorem.Character())
                .Returns("x");

            Assert.AreEqual(@"x", _parser.Run(pattern));
        }

        [Test]
        public void Run_returns_multiple_letters_for_all_letter_regex()
        {
            const string pattern = @"\w\w \w \w\w\w";

            A.CallTo(() => _fakerContainer.Lorem.Character())
                .ReturnsNextFromSequence("j", "s", "x", "b", "e", "f");

            Assert.AreEqual(@"js x bef", _parser.Run(pattern));
        }
    }
}