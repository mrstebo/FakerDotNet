using System;
using FakeItEasy;
using FakerDotNet.Data;
using FakerDotNet.Fakers;
using NUnit.Framework;

namespace FakerDotNet.Tests.Fakers
{
    [TestFixture]
    [Parallelizable]
    public class BusinessFakerTests
    {
        [SetUp]
        public void SetUp()
        {
            _fakerContainer = A.Fake<IFakerContainer>();
            _businessFaker = new BusinessFaker(_fakerContainer);
        }

        private IFakerContainer _fakerContainer;
        private IBusinessFaker _businessFaker;

        [Test]
        public void CreditCardNumber_returns_a_credit_card_number()
        {
            A.CallTo(() => _fakerContainer.Random.Element(BusinessData.CreditCardNumbers))
                .Returns("1228-1221-1221-1431");

            Assert.AreEqual("1228-1221-1221-1431", _businessFaker.CreditCardNumber());
        }

        [Test]
        public void CreditCardExpiryDate_returns_a_credit_card_expiry_date()
        {
            var expectedDate = DateTime.UtcNow.AddYears(1);

            A.CallTo(() => _fakerContainer.Date.Forward(365 * 1))
                .Returns(expectedDate);
            A.CallTo(() => _fakerContainer.Number.Between(1, 5))
                .Returns(1);

            Assert.AreEqual(expectedDate, _businessFaker.CreditCardExpiryDate());
        }

        [Test]
        public void CreditCardType_returns_a_credit_card_type()
        {
            A.CallTo(() => _fakerContainer.Random.Element(BusinessData.CreditCardTypes))
                .Returns("visa");

            Assert.AreEqual("visa", _businessFaker.CreditCardType());
        }
    }
}
