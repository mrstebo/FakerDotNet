using FakeItEasy;
using FakerDotNet.Data;
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
            A.CallTo(() => _fakerContainer.Number.Digit())
                .ReturnsNextFromSequence("6", "7", "3", "8", "5", "8", "2", "3", "7", "9");

            Assert.AreEqual("6738582379", _bankFaker.AccountNumber());
        }

        [Test]
        public void AccountNumber_with_digits_returns_an_account_number()
        {
            A.CallTo(() => _fakerContainer.Number.Digit())
                .ReturnsNextFromSequence("6", "7", "3", "8", "5", "8", "2", "3", "7", "9", "0", "2");

            Assert.AreEqual("673858237902", _bankFaker.AccountNumber(13));
        }

        [Test]
        public void Iban_returns_an_iban()
        {
            var ibanDetails = BankData.IbanDetails["gb"];

            A.CallTo(() => _fakerContainer.Regexify.Parse(ibanDetails.pattern))
                .Returns("DZJM33188515981979");

            Assert.AreEqual("GB19DZJM33188515981979", _bankFaker.Iban());
        }

        [Test]
        public void Iban_with_country_code_returns_an_iban()
        {
            var ibanDetails = BankData.IbanDetails["be"];

            A.CallTo(() => _fakerContainer.Regexify.Parse(ibanDetails.pattern))
                .Returns("75388567752043");

            Assert.AreEqual("BE8975388567752043", _bankFaker.Iban("be"));
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
