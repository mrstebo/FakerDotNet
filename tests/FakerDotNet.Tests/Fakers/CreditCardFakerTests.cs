using System;
using FakeItEasy;
using FakerDotNet.Data;
using FakerDotNet.Fakers;
using NUnit.Framework;


namespace FakerDotNet.Tests.Fakers
{
    [TestFixture]
    [Parallelizable]
    public class CreditCardFakerTests
    {
        private IFakerContainer _fakerContainer;
        private ICreditCardFaker _creditCardFaker;
        [SetUp]
        public void SetUp()
        {
            _fakerContainer = A.Fake<IFakerContainer>();
            _creditCardFaker = new CreditCardFaker(_fakerContainer);
        }

        [Test]
        public void Number_returns_a_credit_card_number()
        {
            A.CallTo(() => _fakerContainer.Number.Between(1, 12))
                .Returns(2);
            A.CallTo(() => _fakerContainer.Random.Element(CreditCardData.CountryISOCodes))
                .Returns("004");
            A.CallTo(() => _fakerContainer.Number.Between(1, 9))
                .Returns(2);
            A.CallTo(() => _fakerContainer.Number.Between(100000000, 999999999))
                .Returns(555555555);
            
            Assert.AreEqual("2004-2255-5555-5552", _creditCardFaker.Number());
        }

        [Test]
        public void CreditCardNumber_returns_a_credit_card_number()
        {
            A.CallTo(() => _fakerContainer.Random.Element(CreditCardData.CreditCardBrands))
                .Returns("visa");
            
            Assert.AreEqual("visa", _creditCardFaker.Brand());
        }

        [Test]
        public void ExpiryDate_returns_an_expirydate()
        {
            A.CallTo(() => _fakerContainer.Number.Between(1, 12))
                .Returns(2);
            A.CallTo(() => _fakerContainer.Number.Between(1, 99))
                .Returns(22);
           
            Assert.AreEqual("02/22", _creditCardFaker.ExpiryDate());
        }

        [Test]
        public void CVV_returns_a_cvv()
        {
            A.CallTo(() => _fakerContainer.Number.Between(100, 999))
                .Returns(123);
           
            Assert.AreEqual("123", _creditCardFaker.CVV());
        }
    }
}
