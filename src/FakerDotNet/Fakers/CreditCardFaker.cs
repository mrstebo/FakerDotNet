using FakerDotNet.Data;

namespace FakerDotNet.Fakers
{
    public interface ICreditCardFaker
    {
        string Number();

        string ExpiryDate();

        string Brand();

        int CVV();
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
            int month = (int)_fakerContainer.Number.Between(1, 12);
            int year = (int)_fakerContainer.Number.Between(1, 99);
            return month.ToString().PadLeft(2, '0') + "/" + year.ToString().PadLeft(2, '0');
        }

        public string Number()
        {
            int mii = (int)_fakerContainer.Number.Between(1, 12);
            string countryISO = _fakerContainer.Random.Element(CreditCardData.CountryISOCodes);
            string bin = mii.ToString() + countryISO;
            while (bin.Length < 6)
                bin += _fakerContainer.Number.Between(1, 9);
            string accountNumber = _fakerContainer.Number.Between(1000000, 9999999).ToString();
            var checkSum = _fakerContainer.Number.Between(1, 9);
            return bin + accountNumber + checkSum;
        }

        public int CVV()
        {
            return (int)_fakerContainer.Number.Between(100, 999);
        }
    }
}