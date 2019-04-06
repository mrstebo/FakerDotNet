using FakeItEasy;
using FakerDotNet.Fakers;
using NUnit.Framework;

namespace FakerDotNet.Tests.Fakers
{
    [TestFixture]
    [Parallelizable]
    public class BankFakerTests
    {
        [SetUp]
        public void SetUp()
        {
            _fakerContainer = A.Fake<IFakerContainer>();
            _bankFaker = new BankFaker(_fakerContainer);
        }

        private IFakerContainer _fakerContainer;
        private IBankFaker _bankFaker;

        [Test]
        public void AccountNumber_returns_an_account_number()
        {
            Assert.AreEqual("6738582379", _bankFaker.AccountNumber());
        }

        [Test]
        public void AccountNumber_with_digits_returns_an_account_number()
        {
            Assert.AreEqual("673858237902", _bankFaker.AccountNumber(13));
        }

        [Test]
        public void Iban_returns_an_iban()
        {
            Assert.AreEqual("GB76DZJM33188515981979", _bankFaker.Iban());
        }

        [Test]
        public void Iban_with_country_code_returns_an_iban()
        {
            Assert.AreEqual("BE6375388567752043", _bankFaker.Iban("be"));
        }

        [Test]
        public void Name_returns_a_name()
        {
            Assert.AreEqual("ABN AMRO CORPORATE FINANCE LIMITED", _bankFaker.Name());
        }

        [Test]
        public void RoutingNumber_a_routing_number()
        {
            Assert.AreEqual("729343831", _bankFaker.RoutingNumber());
        }

        [Test]
        public void RoutingNumberWithFormat_returns_a_formatted_routing_number()
        {
            Assert.AreEqual("22-3833/64805", _bankFaker.RoutingNumberWithFormat());
        }

        [Test]
        public void SwiftBic_returns_a_swift_bic()
        {
            Assert.AreEqual("AAFMGB21", _bankFaker.SwiftBic());
        }
    }
}