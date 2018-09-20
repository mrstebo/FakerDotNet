using System.Linq;
using FakerDotNet.Fakers;
using NUnit.Framework;

namespace FakerDotNet.Tests.Fakers
{
    [TestFixture]
    [Parallelizable]
    public class RandomFakerTests
    {
        [SetUp]
        public void SetUp()
        {
            _randomFaker = new RandomFaker();
        }

        private IRandomFaker _randomFaker;

        [Test]
        public void Element_returns_one_of_the_elements()
        {
            var collection = new[] {1, 2, 3, 4, 5};

            Assert.Contains(_randomFaker.Element(collection), collection);
        }

        [Test]
        public void Element_with_empty_collection_returns_default_for_type()
        {
            Assert.AreEqual(0, _randomFaker.Element(Enumerable.Empty<int>()));
            Assert.AreEqual(0, _randomFaker.Element(Enumerable.Empty<long>()));
            Assert.AreEqual(null, _randomFaker.Element(Enumerable.Empty<string>()));
            Assert.AreEqual(null, _randomFaker.Element(Enumerable.Empty<object>()));
        }

        [Test]
        public void Element_with_string_returns_a_single_character()
        {
            const string word = "Typewriter";

            Assert.Contains(_randomFaker.Element(word), word.ToCharArray());
        }
    }
}