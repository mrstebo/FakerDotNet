using FakerDotNet.Extensions;
using NUnit.Framework;

namespace FakerDotNet.Tests.Extensions
{
    [TestFixture]
    [Parallelizable]
    public class StringCharactersExtensionTests
    {
        [Test]
        public void Characters_returns_each_character_from_string()
        {
            const string text = "test";
            
            var expected = new[] {"t", "e", "s", "t"};

            CollectionAssert.AreEqual(expected, text.Characters());
        }

        [Test]
        public void Characters_returns_empty_array_for_null_string()
        {
            const string text = null;

            var expected = new string[] { };

            CollectionAssert.AreEqual(expected, text.Characters());
        }

        [Test]
        public void Characters_returns_empty_array_for_empty_string()
        {
            const string text = "";

            var expected = new string[] { };

            CollectionAssert.AreEqual(expected, text.Characters());
        }
    }
}