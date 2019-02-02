using System.Text.RegularExpressions;
using FakerDotNet.Data;

namespace FakerDotNet.Fakers
{
    public interface IPhoneNumberFaker
    {
        string PhoneNumber();
        string CellPhone();
        string CountryCode();
        string AreaCode();
        string ExchangeCode();
        string SubscriberNumber(int length = 4);
        string Extension(int length = 4);
    }

    internal class PhoneNumberFaker : IPhoneNumberFaker
    {
        private readonly IFakerContainer _fakerContainer;

        public PhoneNumberFaker(IFakerContainer fakerContainer)
        {
            _fakerContainer = fakerContainer;
        }

        public string PhoneNumber()
        {
            return Parse(_fakerContainer.Random.Element(PhoneNumberData.PhoneNumberFormats));
        }

        public string CellPhone()
        {
            return Parse(_fakerContainer.Random.Element(PhoneNumberData.CellPhoneFormats));
        }

        public string CountryCode()
        {
            return $"+{_fakerContainer.Random.Element(PhoneNumberData.CountryCodes)}";
        }

        public string AreaCode()
        {
            return _fakerContainer.Random.Element(PhoneNumberData.AreaCodes);
        }

        public string ExchangeCode()
        {
            return _fakerContainer.Random.Element(PhoneNumberData.ExchangeCodes);
        }

        public string SubscriberNumber(int length = 4)
        {
            return _fakerContainer.Number.Number(length);
        }

        public string Extension(int length = 4)
        {
            return SubscriberNumber(length);
        }

        private string Parse(string text)
        {
            return Regex.Replace(text, "#", m => _fakerContainer.Number.Digit());
        }
    }
}
