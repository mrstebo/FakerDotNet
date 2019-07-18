using FakeItEasy;
using FakerDotNet.Fakers.Blockchain;
using NUnit.Framework;

namespace FakerDotNet.Tests.Fakers.Blockchain
{
    [TestFixture]
    [Parallelizable]
    public class BitcoinFakerTests
    {
        [SetUp]
        public void SetUp()
        {
            _fakerContainer = A.Fake<IFakerContainer>();
            _bitcoinFaker = new BitcoinFaker(_fakerContainer);
        }

        private IFakerContainer _fakerContainer;
        private IBitcoinFaker _bitcoinFaker;

        [Test]
        public void Address_returns_an_address()
        {
            Assert.AreEqual("1HUoGjmgChmnxxYhz87YytV4gVjfPaExmh", _bitcoinFaker.Address());
        }

        [Test]
        public void TestnetAddress_returns_a_testnet_address()
        {
            Assert.AreEqual("msHGunDvoEwmVFXvd2Bub1SNw5RP1YHJaf", _bitcoinFaker.TestnetAddress());
        }
    }
}
