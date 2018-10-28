using FakerDotNet.Algorithms;
using NUnit.Framework;

namespace FakerDotNet.Tests.Algorithms
{
    [TestFixture]
    [Parallelizable]
    public class VinCheckSumTests
    {
        [Test]
        [TestCase("ACCAABCE0JABCEDDE", "X")]
        [TestCase("KM8JU3AG0FU003762", "4")]
        public void GetCheckSumTest(string vin, string checkSum)
        {
            Assert.AreEqual(checkSum, VinCheckSum.GetChecksum(vin));
        }
    }
}
