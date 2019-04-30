using System.Collections.Generic;
using FakeItEasy;
using FakerDotNet.FakerUtils.RegexifyParsers;
using NUnit.Framework;

namespace FakerDotNet.Tests.FakerUtils.RegexifyParsers
{
    [TestFixture]
    [Parallelizable]
    public class ReplaceOneOfWordsWithWordTests
    {
        [SetUp]
        public void SetUp()
        {
            _fakerContainer = A.Fake<IFakerContainer>();
            _parser = new ReplaceOneOfWordsWithWord(_fakerContainer);
        }

        private IFakerContainer _fakerContainer;
        private IRegexifyParser _parser;

        [Test]
        public void Run_returns_a_word_from_the_words_between_the_parenthesis()
        {
            const string pattern = @"(this|that)";

            A.CallTo(() => _fakerContainer.Random.Element(
                    A<IEnumerable<string>>.That.IsSameSequenceAs("this", "that")))
                .Returns("that");

            Assert.AreEqual(@"that", _parser.Run(pattern));
        }
    }
}