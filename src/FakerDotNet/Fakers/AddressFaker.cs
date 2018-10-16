using System.Text.RegularExpressions;
using FakerDotNet.Data;

namespace FakerDotNet.Fakers
{
    public interface IAddressFaker
    {
        string City();
        string StreetName();
        string StreetAddress();
        string SecondaryAddress();
        string BuildingNumber();
        string Community();
        string ZipCode(string stateAbbreviation = null);
        string Zip(string stateAbbreviation = null);
        string Postcode(string stateAbbreviation = null);
        string TimeZone();
        string StreetSuffix();
        string CitySuffix();
        string CityPrefix();
        string State();
        string StateAbbr();
        string Country();
        string CountryCode();
        string CountryCodeLong();
        string Latitude();
        string Longitude();
        string FullAddress();
    }

    internal class AddressFaker : IAddressFaker
    {
        private readonly IFakerContainer _fakerContainer;

        public AddressFaker(IFakerContainer fakerContainer)
        {
            _fakerContainer = fakerContainer;
        }

        public string City()
        {
            return Parse(_fakerContainer.Random.Element(AddressData.Cities));
        }

        public string StreetName()
        {
            return Parse(_fakerContainer.Random.Element(AddressData.StreetNames));
        }

        public string StreetAddress()
        {
            return Parse(_fakerContainer.Random.Element(AddressData.StreetAddresses));
        }

        public string SecondaryAddress()
        {
            return Parse(_fakerContainer.Random.Element(AddressData.SecondaryAddressPrefixes));
        }

        public string BuildingNumber()
        {
            return Parse(_fakerContainer.Random.Element(AddressData.BuildingNumbers));
        }

        public string Community()
        {
            return string.Join(" ",
                _fakerContainer.Random.Element(AddressData.CommunityPrefixes),
                _fakerContainer.Random.Element(AddressData.CommunitySuffixes));
        }

        public string ZipCode(string stateAbbreviation = null)
        {
            var format = string.IsNullOrEmpty(stateAbbreviation)
                ? _fakerContainer.Random.Element(AddressData.Postcodes)
                : AddressData.PostcodeByState[stateAbbreviation];
            return Parse(format);
        }

        public string Zip(string stateAbbreviation = null)
        {
            return ZipCode(stateAbbreviation);
        }

        public string Postcode(string stateAbbreviation = null)
        {
            return ZipCode(stateAbbreviation);
        }

        public string TimeZone()
        {
            return _fakerContainer.Random.Element(AddressData.TimeZones);
        }

        public string StreetSuffix()
        {
            return _fakerContainer.Random.Element(AddressData.StreetSuffixes);
        }

        public string CitySuffix()
        {
            return _fakerContainer.Random.Element(AddressData.CitySuffixes);
        }

        public string CityPrefix()
        {
            return _fakerContainer.Random.Element(AddressData.CityPrefixes);
        }

        public string State()
        {
            return _fakerContainer.Random.Element(AddressData.States);
        }

        public string StateAbbr()
        {
            return _fakerContainer.Random.Element(AddressData.StateAbbreviations);
        }

        public string Country()
        {
            return _fakerContainer.Random.Element(AddressData.Countries);
        }

        public string CountryCode()
        {
            return _fakerContainer.Random.Element(AddressData.CountryCodes);
        }

        public string CountryCodeLong()
        {
            return _fakerContainer.Random.Element(AddressData.LongCountryCodes);
        }

        public string Latitude()
        {
            return $"{_fakerContainer.Number.Between(0, 180) - 90:#.##########}";
        }

        public string Longitude()
        {
            return $"{(_fakerContainer.Number.Between(0, 360) - 180):#.##########}";
        }

        public string FullAddress()
        {
            return Parse(_fakerContainer.Random.Element(AddressData.FullAddresses));
        }

        private string Parse(string format)
        {
            var text = Regex.Replace(format, @"\{(\w+)\}", @"{Address.$1}");

            text = Regex.Replace(text, "#", m => _fakerContainer.Number.NonZeroDigit());

            return _fakerContainer.Fake.F(text);
        }
    }
}
