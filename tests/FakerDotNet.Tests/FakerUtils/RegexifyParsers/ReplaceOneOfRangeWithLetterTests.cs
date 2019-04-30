using System.Collections.Generic;
using FakeItEasy;
using FakerDotNet.FakerUtils.RegexifyParsers;
using NUnit.Framework;

namespace FakerDotNet.Tests.FakerUtils.RegexifyParsers
{
    [TestFixture]
    [Parallelizable]
    public class ReplaceOneOfRangeWithLetterTests
    {
        [SetUp]
        public void SetUp()
        {
            _fakerContainer = A.Fake<IFakerContainer>();
            _parser = new ReplaceOneOfRangeWithLetter(_fakerContainer);
        }

        private IFakerContainer _fakerContainer;
        private IRegexifyParser _parser;

        [Test]
        public void Run_returns_a_character_from_the_range_between_square_brackets()
        {
            const string pattern = @"[A-F]";

            A.CallTo(() => _fakerContainer.Random.Element(
                    A<IEnumerable<string>>.That.IsSameSequenceAs("A", "B", "C", "D", "E", "F")))
                .Returns("E");

            Assert.AreEqual(@"[E]", _parser.Run(pattern));
        }

        [Test]
        public void Run_returns_characters_from_multiple_ranges_between_square_brackets()
        {
            const string pattern = @"[A-FK-P0-9]";

            A.CallTo(() => _fakerContainer.Random.Element(
                    A<IEnumerable<string>>.That.IsSameSequenceAs("A", "B", "C", "D", "E", "F")))
                .Returns("C");
            A.CallTo(() => _fakerContainer.Random.Element(
                    A<IEnumerable<string>>.That.IsSameSequenceAs("K", "L", "M", "N", "O", "P")))
                .Returns("M");
            A.CallTo(() => _fakerContainer.Random.Element(
                    A<IEnumerable<string>>.That.IsSameSequenceAs("0", "1", "2", "3", "4", "5", "6", "7", "8", "9")))
                .Returns("4");

            Assert.AreEqual(@"[CM4]", _parser.Run(pattern));
        }
    }
}