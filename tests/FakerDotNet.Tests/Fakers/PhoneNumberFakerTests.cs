using FakeItEasy;
using FakerDotNet.Data;
using FakerDotNet.Fakers;
using NUnit.Framework;

namespace FakerDotNet.Tests.Fakers
{
    [TestFixture]
    [Parallelizable]
    public class PhoneNumberFakerTests
    {
        [SetUp]
        public void SetUp()
        {
            _fakerContainer = A.Fake<IFakerContainer>();
            _phoneNumberFaker = new PhoneNumberFaker(_fakerContainer);
        }

        private IFakerContainer _fakerContainer;
        private IPhoneNumberFaker _phoneNumberFaker;

        [Test]
        public void PhoneNumber_returns_a_phone_number()
        {
            A.CallTo(() => _fakerContainer.Random.Element(PhoneNumberData.PhoneNumberFormats))
                .Returns("###.###.####");
            A.CallTo(() => _fakerContainer.Number.Digit())
                .ReturnsNextFromSequence("3", "9", "7", "6", "9", "3", "1", "3", "0", "9");

            Assert.AreEqual("397.693.1309", _phoneNumberFaker.PhoneNumber());
        }

        [Test]
        public void CellPhone_returns_a_cell_phone_number()
        {
            A.CallTo(() => _fakerContainer.Random.Element(PhoneNumberData.CellPhoneFormats))
                .Returns("(###)###-####");
            A.CallTo(() => _fakerContainer.Number.Digit())
                .ReturnsNextFromSequence("1", "8", "6", "2", "8", "5", "7", "9", "2", "5");

            Assert.AreEqual("(186)285-7925", _phoneNumberFaker.CellPhone());
        }

        [Test]
        public void CountryCode_returns_a_country_code()
        {
            A.CallTo(() => _fakerContainer.Random.Element(PhoneNumberData.CountryCodes))
                .Returns("44");

            Assert.AreEqual("+44", _phoneNumberFaker.CountryCode());
        }

        [Test]
        public void AreaCode_returns_an_area_code()
        {
            A.CallTo(() => _fakerContainer.Random.Element(PhoneNumberData.AreaCodes))
                .Returns("201");

            Assert.AreEqual("201", _phoneNumberFaker.AreaCode());
        }

        [Test]
        public void ExchangeCode_returns_an_exchange_code()
        {
            A.CallTo(() => _fakerContainer.Random.Element(PhoneNumberData.ExchangeCodes))
                .Returns("208");

            Assert.AreEqual("208", _phoneNumberFaker.ExchangeCode());
        }

        [Test]
        public void SubscriberNumber_returns_a_subscriber_number()
        {
            A.CallTo(() => _fakerContainer.Number.Number(4))
                .Returns("3873");

            Assert.AreEqual("3873", _phoneNumberFaker.SubscriberNumber());
        }

        [Test]
        public void SubscriberNumber_returns_a_subscriber_number_with_the_specified_length()
        {
            A.CallTo(() => _fakerContainer.Number.Number(2))
                .Returns("39");

            Assert.AreEqual("39", _phoneNumberFaker.SubscriberNumber(2));
        }

        [Test]
        public void Extension_returns_a_phone_extension()
        {
            A.CallTo(() => _fakerContainer.Number.Number(4))
                .Returns("3764");

            Assert.AreEqual("3764", _phoneNumberFaker.Extension());
        }

        [Test]
        public void Extension_returns_a_phone_extension_with_the_specified_length()
        {
            A.CallTo(() => _fakerContainer.Number.Number(2))
                .Returns("36");

            Assert.AreEqual("36", _phoneNumberFaker.Extension(2));
        }
    }
}
