using System.Collections.Generic;
using FakeItEasy;
using FakerDotNet.FakerUtils.RegexifyParsers;
using NUnit.Framework;

namespace FakerDotNet.Tests.FakerUtils.RegexifyParsers
{
    [TestFixture]
    [Parallelizable]
    public class ReplaceOneOfLettersWithLetterTests
    {
        [SetUp]
        public void SetUp()
        {
            _fakerContainer = A.Fake<IFakerContainer>();
            _parser = new ReplaceOneOfLettersWithLetter(_fakerContainer);
        }

        private IFakerContainer _fakerContainer;
        private IRegexifyParser _parser;

        [Test]
        public void Run_returns_item_from_between_square_brackets()
        {
            const string pattern = @"[ABC]";

            A.CallTo(() => _fakerContainer.Random.Element(
                    A<IEnumerable<string>>.That.IsSameSequenceAs("A", "B", "C")))
                .Returns("B");

            Assert.AreEqual(@"B", _parser.Run(pattern));
        }
    }
}