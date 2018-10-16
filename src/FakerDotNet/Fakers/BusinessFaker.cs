using System;
using FakerDotNet.Data;

namespace FakerDotNet.Fakers
{
    public interface IBusinessFaker
    {
        string CreditCardNumber();
        DateTime CreditCardExpiryDate();
        string CreditCardType();
    }

    internal class BusinessFaker : IBusinessFaker
    {
        private readonly IFakerContainer _fakerContainer;

        public BusinessFaker(IFakerContainer fakerContainer)
        {
            _fakerContainer = fakerContainer;
        }

        public string CreditCardNumber()
        {
            return _fakerContainer.Random.Element(BusinessData.CreditCardNumbers);
        }

        public DateTime CreditCardExpiryDate()
        {
            return _fakerContainer.Date.Forward(365 * (int) _fakerContainer.Number.Between(1, 5));
        }

        public string CreditCardType()
        {
            return _fakerContainer.Random.Element(BusinessData.CreditCardTypes);
        }
    }
}
