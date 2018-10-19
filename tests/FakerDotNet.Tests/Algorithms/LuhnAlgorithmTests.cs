using FakerDotNet.Algorithms;
using NUnit.Framework;

namespace FakerDotNet.Tests.Algorithms
{
    [TestFixture]
    [Parallelizable]
    public class LuhnAlgorithmTests
    {
        [Test]
        [TestCase(796257802, 2)]
        [TestCase(7992739871, 3)]
        public void GetCheckValue_returns_check_value_for_number(long number, int expected)
        {
            Assert.AreEqual(expected, LuhnAlgorithm.GetCheckValue(number));
        }
    }
}
