using System.Collections.Generic;
using FakeItEasy;
using FakerDotNet.Data;
using FakerDotNet.Fakers;
using NUnit.Framework;

namespace FakerDotNet.Tests.Fakers
{
    [TestFixture]
    [Parallelizable]
    public class AddressFakerTests
    {
        [SetUp]
        public void SetUp()
        {
            _fakerContainer = A.Fake<IFakerContainer>();
            _addressFaker = new AddressFaker(_fakerContainer);

            A.CallTo(() => _fakerContainer.Fake).Returns(new FakeFaker(_fakerContainer));
        }

        private IFakerContainer _fakerContainer;
        private IAddressFaker _addressFaker;

        [Test]
        public void City_returns_a_city()
        {
            A.CallTo(() => _fakerContainer.Random.Element(AddressData.Cities))
                .Returns("Imogeneborough");

            Assert.AreEqual("Imogeneborough", _addressFaker.City());
        }

        [Test]
        public void City_runs_placeholders_through_the_IFakeFaker()
        {
            A.CallTo(() => _fakerContainer.Random.Element(AddressData.Cities))
                .Returns("{CityPrefix} {Name.FirstName}{CitySuffix}");
            A.CallTo(() => _fakerContainer.Address.CityPrefix())
                .Returns("test1");
            A.CallTo(() => _fakerContainer.Name.FirstName())
                .Returns("test2");
            A.CallTo(() => _fakerContainer.Address.CitySuffix())
                .Returns("test3");

            Assert.AreEqual("test1 test2test3", _addressFaker.City());
        }

        [Test]
        public void StreetName_returns_a_street_name()
        {
            A.CallTo(() => _fakerContainer.Random.Element(AddressData.StreetNames))
                .Returns("Larkin Fork");

            Assert.AreEqual("Larkin Fork", _addressFaker.StreetName());
        }

        [Test]
        public void StreetName_runs_placeholders_through_the_IFakeFaker()
        {
            A.CallTo(() => _fakerContainer.Random.Element(AddressData.StreetNames))
                .Returns("{CityPrefix} {Name.FirstName}{CitySuffix}");
            A.CallTo(() => _fakerContainer.Address.CityPrefix())
                .Returns("test1");
            A.CallTo(() => _fakerContainer.Name.FirstName())
                .Returns("test2");
            A.CallTo(() => _fakerContainer.Address.CitySuffix())
                .Returns("test3");

            Assert.AreEqual("test1 test2test3", _addressFaker.StreetName());
        }

        [Test]
        public void StreetAddress_returns_a_street_address()
        {
            A.CallTo(() => _fakerContainer.Random.Element(AddressData.StreetAddresses))
                .Returns("### Kevin Brook");
            A.CallTo(() => _fakerContainer.Number.NonZeroDigit()).ReturnsNextFromSequence("2", "8", "2");

            Assert.AreEqual("282 Kevin Brook", _addressFaker.StreetAddress());
        }

        [Test]
        public void StreetAddress_runs_placeholders_through_the_IFakeFaker()
        {
            A.CallTo(() => _fakerContainer.Random.Element(AddressData.StreetAddresses))
                .Returns("{CityPrefix} {Name.FirstName}{CitySuffix}");
            A.CallTo(() => _fakerContainer.Address.CityPrefix())
                .Returns("test1");
            A.CallTo(() => _fakerContainer.Name.FirstName())
                .Returns("test2");
            A.CallTo(() => _fakerContainer.Address.CitySuffix())
                .Returns("test3");

            Assert.AreEqual("test1 test2test3", _addressFaker.StreetAddress());
        }

        [Test]
        public void SecondaryAddress_returns_a_secondary_address()
        {
            A.CallTo(() => _fakerContainer.Random.Element(AddressData.SecondaryAddressPrefixes))
                .Returns("Apt. 672");
            A.CallTo(() => _fakerContainer.Number.NonZeroDigit()).ReturnsNextFromSequence("6", "7", "2");

            Assert.AreEqual("Apt. 672", _addressFaker.SecondaryAddress());
        }

        [Test]
        public void SecondaryAddress_runs_placeholders_through_the_IFakeFaker()
        {
            A.CallTo(() => _fakerContainer.Random.Element(AddressData.SecondaryAddressPrefixes))
                .Returns("{CityPrefix} {Name.FirstName}{CitySuffix}");
            A.CallTo(() => _fakerContainer.Address.CityPrefix())
                .Returns("test1");
            A.CallTo(() => _fakerContainer.Name.FirstName())
                .Returns("test2");
            A.CallTo(() => _fakerContainer.Address.CitySuffix())
                .Returns("test3");

            Assert.AreEqual("test1 test2test3", _addressFaker.SecondaryAddress());
        }

        [Test]
        public void BuildingNumber_returns_a_building_number()
        {
            A.CallTo(() => _fakerContainer.Random.Element(AddressData.BuildingNumbers))
                .Returns("####");
            A.CallTo(() => _fakerContainer.Number.NonZeroDigit())
                .ReturnsNextFromSequence("7", "3", "0", "4");

            Assert.AreEqual("7304", _addressFaker.BuildingNumber());
        }

        [Test]
        public void Community_returns_a_community()
        {
            A.CallTo(() => _fakerContainer.Random.Element(AddressData.CommunityPrefixes))
                .Returns("University");
            A.CallTo(() => _fakerContainer.Random.Element(AddressData.CommunitySuffixes))
                .Returns("Crossing");

            Assert.AreEqual("University Crossing", _addressFaker.Community());
        }

        [Test]
        public void ZipCode_returns_a_postcode()
        {
            A.CallTo(() => _fakerContainer.Random.Element(AddressData.Postcodes))
                .Returns("58517");

            Assert.AreEqual("58517", _addressFaker.ZipCode());
        }

        [Test]
        public void ZipCode_returns_a_state_zip_code_if_stateAbbreviation_is_specified()
        {
            A.CallTo(() => _fakerContainer.Number.NonZeroDigit()).Returns("1");

            Assert.AreEqual("35011", _addressFaker.ZipCode("AL"));
        }

        [Test]
        public void Zip_returns_a_postcode()
        {
            A.CallTo(() => _fakerContainer.Random.Element(AddressData.Postcodes))
                .Returns("58517");

            Assert.AreEqual("58517", _addressFaker.Zip());
        }

        [Test]
        public void Zip_returns_a_state_zip_code_if_stateAbbreviation_is_specified()
        {
            A.CallTo(() => _fakerContainer.Number.NonZeroDigit()).Returns("1");

            Assert.AreEqual("35011", _addressFaker.Zip("AL"));
        }

        [Test]
        public void Postcode_returns_a_postcode()
        {
            A.CallTo(() => _fakerContainer.Random.Element(AddressData.Postcodes))
                .Returns("58517");

            Assert.AreEqual("58517", _addressFaker.Postcode());
        }

        [Test]
        public void Postcode_returns_a_state_zip_code_if_stateAbbreviation_is_specified()
        {
            A.CallTo(() => _fakerContainer.Number.NonZeroDigit()).Returns("1");

            Assert.AreEqual("35011", _addressFaker.Postcode("AL"));
        }

        [Test]
        public void TimeZone_returns_a_time_zone()
        {
            A.CallTo(() => _fakerContainer.Random.Element(AddressData.TimeZones))
                .Returns("Asia/Yakutsk");

            Assert.AreEqual("Asia/Yakutsk", _addressFaker.TimeZone());
        }

        [Test]
        public void StreetSuffix_returns_a_street_suffix()
        {
            A.CallTo(() => _fakerContainer.Random.Element(AddressData.StreetSuffixes))
                .Returns("Street");

            Assert.AreEqual("Street", _addressFaker.StreetSuffix());
        }

        [Test]
        public void CitySuffix_returns_a_city_suffix()
        {
            A.CallTo(() => _fakerContainer.Random.Element(AddressData.CitySuffixes))
                .Returns("fort");

            Assert.AreEqual("fort", _addressFaker.CitySuffix());
        }

        [Test]
        public void CityPrefix_returns_a_city_prefix()
        {
            A.CallTo(() => _fakerContainer.Random.Element(AddressData.CityPrefixes))
                .Returns("Lake");

            Assert.AreEqual("Lake", _addressFaker.CityPrefix());
        }

        [Test]
        public void State_returns_a_state()
        {
            A.CallTo(() => _fakerContainer.Random.Element(AddressData.States))
                .Returns("California");

            Assert.AreEqual("California", _addressFaker.State());
        }

        [Test]
        public void StateAbbr_returns_a_state_abbreviation()
        {
            A.CallTo(() => _fakerContainer.Random.Element(AddressData.StateAbbreviations))
                .Returns("AP");

            Assert.AreEqual("AP", _addressFaker.StateAbbr());
        }

        [Test]
        public void Country_returns_a_country()
        {
            A.CallTo(() => _fakerContainer.Random.Element(AddressData.Countries))
                .Returns("French Guiana");

            Assert.AreEqual("French Guiana", _addressFaker.Country());
        }

        [Test]
        public void CountryCode_returns_a_country_code()
        {
            A.CallTo(() => _fakerContainer.Random.Element(AddressData.CountryCodes))
                .Returns("IT");

            Assert.AreEqual("IT", _addressFaker.CountryCode());
        }

        [Test]
        public void CountryCodeLong_returns_a_long_country_code()
        {
            A.CallTo(() => _fakerContainer.Random.Element(AddressData.LongCountryCodes))
                .Returns("ITA");

            Assert.AreEqual("ITA", _addressFaker.CountryCodeLong());
        }

        [Test]
        public void Latitude_returns_a_latitude()
        {
            A.CallTo(() => _fakerContainer.Number.Between(0, 180)).Returns(31.82743772556281);
            
            Assert.AreEqual((-58.1725622744).ToString("#.##########"), _addressFaker.Latitude());
        }

        [Test]
        public void Longitude_returns_a_longitude()
        {
            A.CallTo(() => _fakerContainer.Number.Between(0, 360)).Returns(23.344516179048668);
            
            Assert.AreEqual((-156.655483821).ToString("#.##########"), _addressFaker.Longitude());
        }

        [Test]
        public void FullAddress_returns_a_full_address()
        {
            A.CallTo(() => _fakerContainer.Random.Element(AddressData.FullAddresses))
                .Returns("{StreetAddress}, {City}, {StateAbbr} {ZipCode}");
            A.CallTo(() => _fakerContainer.Address.StreetAddress()).Returns("282 Kevin Brook");
            A.CallTo(() => _fakerContainer.Address.City()).Returns("Imogeneborough");
            A.CallTo(() => _fakerContainer.Address.StateAbbr()).Returns("CA");
            A.CallTo(() => _fakerContainer.Address.ZipCode(null)).Returns("58517");
            
            Assert.AreEqual("282 Kevin Brook, Imogeneborough, CA 58517", _addressFaker.FullAddress());
        }
    }
}
