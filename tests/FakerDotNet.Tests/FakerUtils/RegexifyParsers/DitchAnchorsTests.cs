using FakerDotNet.FakerUtils.RegexifyParsers;
using NUnit.Framework;

namespace FakerDotNet.Tests.FakerUtils.RegexifyParsers
{
    [TestFixture]
    [Parallelizable]
    public class DitchAnchorsTests
    {
        [SetUp]
        public void SetUp()
        {
            _parser = new DitchAnchors();
        }

        private IRegexifyParser _parser;

        [Test]
        public void Run_removes_both_start_and_end_anchors()
        {
            const string pattern = @"^hello$";

            Assert.AreEqual(@"hello", _parser.Run(pattern));
        }

        [Test]
        public void Run_removes_end_anchor()
        {
            const string pattern = @"hello$";

            Assert.AreEqual(@"hello", _parser.Run(pattern));
        }

        [Test]
        public void Run_removes_start_anchor()
        {
            const string pattern = @"^hello";

            Assert.AreEqual(@"hello", _parser.Run(pattern));
        }
    }
}