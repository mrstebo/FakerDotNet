using System.Text.RegularExpressions;
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
            _fakerContainer = new FakerContainer();
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

            Assert.That(Regex.IsMatch(_regexify.Parse(pattern), pattern));
        }
    }
}
