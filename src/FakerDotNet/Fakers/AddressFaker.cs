using System;
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
        private static readonly AddressData Data = new AddressData();
        
        private readonly IFakerContainer _fakerContainer;

        public AddressFaker(IFakerContainer fakerContainer)
        {
            _fakerContainer = fakerContainer;
        }

        public string City()
        {
            return Parse(_fakerContainer.Random.Element(Data.Cities));
        }

        public string StreetName()
        {
            return Parse(_fakerContainer.Random.Element(Data.StreetNames));
        }

        public string StreetAddress()
        {
            return Parse(_fakerContainer.Random.Element(Data.StreetAddresses));
        }

        public string SecondaryAddress()
        {
            return Parse(_fakerContainer.Random.Element(Data.SecondaryAddressPrefixes));
        }

        public string BuildingNumber()
        {
            return Parse(_fakerContainer.Random.Element(Data.BuildingNumbers));
        }

        public string Community()
        {
            return string.Join(" ",
                _fakerContainer.Random.Element(Data.CommunityPrefixes),
                _fakerContainer.Random.Element(Data.CommunitySuffixes));
        }

        public string ZipCode(string stateAbbreviation = null)
        {
            var format = string.IsNullOrEmpty(stateAbbreviation)
                ? _fakerContainer.Random.Element(Data.Postcodes)
                : Data.PostcodeByState[stateAbbreviation];
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
            return _fakerContainer.Random.Element(Data.TimeZones);
        }

        public string StreetSuffix()
        {
            return _fakerContainer.Random.Element(Data.StreetSuffixes);
        }

        public string CitySuffix()
        {
            return _fakerContainer.Random.Element(Data.CitySuffixes);
        }

        public string CityPrefix()
        {
            return _fakerContainer.Random.Element(Data.CityPrefixes);
        }

        public string State()
        {
            return _fakerContainer.Random.Element(Data.States);
        }

        public string StateAbbr()
        {
            return _fakerContainer.Random.Element(Data.StateAbbreviations);
        }

        public string Country()
        {
            return _fakerContainer.Random.Element(Data.Countries);
        }

        public string CountryCode()
        {
            return _fakerContainer.Random.Element(Data.CountryCodes);
        }

        public string CountryCodeLong()
        {
            return _fakerContainer.Random.Element(Data.LongCountryCodes);
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
            return Parse(_fakerContainer.Random.Element(Data.FullAddresses));
        }

        private string Parse(string format)
        {
            var text = Regex.Replace(format, @"\{(\w+)\}", @"{Address.$1}");

            text = Regex.Replace(text, "#", m => _fakerContainer.Number.NonZeroDigit());

            return _fakerContainer.Fake.F(text);
        }
    }
}
