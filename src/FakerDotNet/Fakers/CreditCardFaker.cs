using FakerDotNet.Data;

namespace FakerDotNet.Fakers
{
    public interface ICreditCardFaker
    {
        string Number();

        string ExpiryDate();

        string Brand();

        string CVV();
    }

    internal class CreditCardFaker : ICreditCardFaker
    {
        private readonly IFakerContainer _fakerContainer;

        public CreditCardFaker(IFakerContainer fakerContainer)
        {
            _fakerContainer = fakerContainer;
        }

        public string Brand()
        {
            return _fakerContainer.Random.Element(CreditCardData.CreditCardBrands);
        }

        public string ExpiryDate()
        {
            var month = _fakerContainer.Number.Between(1, 12);
            var year = _fakerContainer.Number.Between(1, 99);
            
            return month.ToString().PadLeft(2, '0') + "/" + year.ToString().PadLeft(2, '0');
        }

        public string Number()
        {
            var cardNumber = "";
            var mii = _fakerContainer.Number.Between(1, 12);
            var countryISO = _fakerContainer.Random.Element(CreditCardData.CountryISOCodes);
            var bin = mii.ToString() + countryISO;            
            var accountNumber = _fakerContainer.Number.Between(100000000, 999999999)
                .ToString();
            var checkSum = _fakerContainer.Number.Between(1, 9);
            while (bin.Length < 6)
                bin += _fakerContainer.Number.Between(1, 9);
            var rawNumber = bin + accountNumber + checkSum;         
            for(int i=0;i<rawNumber.Length;i++)
            {
                if ((i+1) % 4 == 0 && i != 0 && i != rawNumber.Length-1)
                    cardNumber += rawNumber[i] + "-";
                else
                    cardNumber += rawNumber[i];
            }          
            
            return cardNumber;
        }

        public string CVV()
        {
            return _fakerContainer.Number.Between(100, 999).ToString();
        }
    }
}