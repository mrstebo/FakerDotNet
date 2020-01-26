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
            Assert.IsNotNull( _creditCardFaker.Number());
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

            Assert.IsNotNull(_creditCardFaker.ExpiryDate());
        }

        [Test]
        public void CVV_returns_a_cvv()
        {
            Assert.IsNotNull(_creditCardFaker.CVV());
        }
    }
}
