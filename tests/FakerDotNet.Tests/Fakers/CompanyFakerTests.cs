using System.Collections.Generic;
using System.Linq;
using FakeItEasy;
using FakerDotNet.Data;
using FakerDotNet.Extensions;
using FakerDotNet.Fakers;
using NUnit.Framework;

namespace FakerDotNet.Tests.Fakers
{
    [TestFixture]
    [Parallelizable]
    public class CompanyFakerTests
    {
        [SetUp]
        public void SetUp()
        {
            _fakerContainer = A.Fake<IFakerContainer>();
            _companyFaker = new CompanyFaker(_fakerContainer);
            
            A.CallTo(() => _fakerContainer.Fake).Returns(new FakeFaker(_fakerContainer));
        }

        private IFakerContainer _fakerContainer;
        private ICompanyFaker _companyFaker;

        [Test]
        public void Name_returns_a_company_name()
        {
            A.CallTo(() => _fakerContainer.Random.Element(CompanyData.Names))
                .Returns("{Name.LastName}-{Name.LastName}");
            A.CallTo(() => _fakerContainer.Name.LastName())
                .ReturnsNextFromSequence("Hirthe", "Ritchie");

            Assert.AreEqual("Hirthe-Ritchie", _companyFaker.Name());
        }

        [Test]
        public void Name_can_handle_calling_self_from_IFakeFaker()
        {
            A.CallTo(() => _fakerContainer.Random.Element(CompanyData.Names))
                .Returns("{Name.LastName} {Suffix}");
            A.CallTo(() => _fakerContainer.Name.LastName())
                .Returns("Awesome");
            A.CallTo(() => _fakerContainer.Company.Suffix())
                .Returns("Inc");

            Assert.AreEqual("Awesome Inc", _companyFaker.Name());
        }

        [Test]
        public void Suffix_returns_the_suffix_for_a_company()
        {
            A.CallTo(() => _fakerContainer.Random.Element(CompanyData.Suffixes))
                .Returns("Group");

            Assert.AreEqual("Group", _companyFaker.Suffix());
        }

        [Test]
        public void Industry_returns_an_industry()
        {
            A.CallTo(() => _fakerContainer.Random.Element(CompanyData.Industries))
                .Returns("Information Services");

            Assert.AreEqual("Information Services", _companyFaker.Industry());
        }

        [Test]
        public void CatchPhrase_returns_a_catch_phrase()
        {
            A.CallTo(() => _fakerContainer.Random.Element(CompanyData.Buzzwords.ElementAt(0)))
                .Returns("Business-focused");
            A.CallTo(() => _fakerContainer.Random.Element(CompanyData.Buzzwords.ElementAt(1)))
                .Returns("coherent");
            A.CallTo(() => _fakerContainer.Random.Element(CompanyData.Buzzwords.ElementAt(2)))
                .Returns("parallelism");

            Assert.AreEqual("Business-focused coherent parallelism", _companyFaker.CatchPhrase());
        }

        [Test]
        public void Buzzword_returns_a_buzzword()
        {
            A.CallTo(() => _fakerContainer.Random.Element(
                    A<IEnumerable<string>>.That.IsSameSequenceAs(CompanyData.Buzzwords.SelectMany(x => x))))
                .Returns("Business-focused");

            Assert.AreEqual("Business-focused", _companyFaker.Buzzword());
        }

        [Test]
        public void Bs_returns_some_bs()
        {
            A.CallTo(() => _fakerContainer.Random.Element(CompanyData.Bs.ElementAt(0)))
                .Returns("empower");
            A.CallTo(() => _fakerContainer.Random.Element(CompanyData.Bs.ElementAt(1)))
                .Returns("one-to-one");
            A.CallTo(() => _fakerContainer.Random.Element(CompanyData.Bs.ElementAt(2)))
                .Returns("web-readiness");

            Assert.AreEqual("empower one-to-one web-readiness", _companyFaker.Bs());
        }

        [Test]
        public void Ein_returns_an_EIN()
        {
            A.CallTo(() => _fakerContainer.Number.Number(2))
                .Returns("34");
            A.CallTo(() => _fakerContainer.Number.Number(7))
                .Returns("8488813");

            Assert.AreEqual("34-8488813", _companyFaker.Ein());
        }

        [Test]
        public void DunsNumber_returns_a_DUNS_number()
        {
            A.CallTo(() => _fakerContainer.Number.Number(2))
                .Returns("08");
            A.CallTo(() => _fakerContainer.Number.Number(3))
                .Returns("341");
            A.CallTo(() => _fakerContainer.Number.Number(4))
                .Returns("3736");

            Assert.AreEqual("08-341-3736", _companyFaker.DunsNumber());
        }

        [Test]
        public void Logo_returns_a_company_logo()
        {
            A.CallTo(() => _fakerContainer.Number.Between(1, 13))
                .Returns(5);

            Assert.AreEqual("https://pigment.github.io/fake-logos/logos/medium/color/5.png", _companyFaker.Logo());
        }

        [Test]
        public void Type_returns_a_type_of_company()
        {
            A.CallTo(() => _fakerContainer.Random.Element(CompanyData.Types))
                .Returns("Privately Held");

            Assert.AreEqual("Privately Held", _companyFaker.Type());
        }

        [Test]
        public void Profession_returns_a_profession()
        {
            A.CallTo(() => _fakerContainer.Random.Element(CompanyData.Professions))
                .Returns("firefighter");

            Assert.AreEqual("firefighter", _companyFaker.Profession());
        }

        [Test]
        public void SwedishOrganisationNumber_returns_a_swedish_organisation_number()
        {
            A.CallTo(() => _fakerContainer.Number.NonZeroDigit())
                .Returns("7");
            A.CallTo(() => _fakerContainer.Number.Digit())
                .Returns("9");
            A.CallTo(() => _fakerContainer.Number.Between(2, 9))
                .Returns(6);
            A.CallTo(() => _fakerContainer.Number.Number(6))
                .Returns("257802");
            
            Assert.AreEqual("7962578022", _companyFaker.SwedishOrganisationNumber());
        }

        [Test]
        public void CzechOrganisationNumber_returns_a_czech_organisation_number()
        {
            A.CallTo(() => _fakerContainer.Number.Digit())
                .ReturnsNextFromSequence("7", "7", "7", "7", "8", "1", "7");
            
            Assert.AreEqual("77778171", _companyFaker.CzechOrganisationNumber());
        }

        [Test]
        public void FrenchSirenNumber_returns_a_french_siren_number()
        {
            Assert.AreEqual("819489626", _companyFaker.FrenchSirenNumber());
        }

        [Test]
        public void FrenchSiretNumber_returns_a_french_siret_number()
        {
            Assert.AreEqual("81948962600013", _companyFaker.FrenchSiretNumber());
        }

        [Test]
        public void NorwegianOrganisationNumber_returns_a_norwegian_organisation_number()
        {
            Assert.AreEqual("839071558", _companyFaker.NorwegianOrganisationNumber());
        }

        [Test]
        public void AustralianBusinessNumber_returns_an_australian_business_number()
        {
            Assert.AreEqual("81137773602", _companyFaker.AustralianBusinessNumber());
        }

        [Test]
        public void SpanishOrganisationNumber_returns_a_spanish_organisation_number()
        {
            var letters = "ABCDEFGHIJKLMNOPQRSTUVW".Characters();

            A.CallTo(() => _fakerContainer.Random.Element(
                    A<IEnumerable<string>>.That.IsSameSequenceAs(letters)))
                .Returns("P");
            A.CallTo(() => _fakerContainer.Number.Number(7))
                .Returns("2344979");
            
            Assert.AreEqual("P2344979", _companyFaker.SpanishOrganisationNumber());
        }

        [Test]
        public void PolishTaxpayerIdentificationNumber_returns_a_polish_taxpayer_identification_number()
        {
            Assert.AreEqual("1060000062", _companyFaker.PolishTaxpayerIdentificationNumber());
        }

        [Test]
        public void PolishRegisterOfNationalEconomy_returns_a_polish_register_of_national_economy()
        {
            Assert.AreEqual("123456785", _companyFaker.PolishRegisterOfNationalEconomy());
        }

        [Test]
        public void SouthAfricanPtyLtdRegistrationNumber_returns_a_south_african_pty_ltd_registration_number()
        {
            Assert.AreEqual("5301/714689/07", _companyFaker.SouthAfricanPtyLtdRegistrationNumber());
        }

        [Test]
        public void SouthAfricanCloseCorporationRegistrationNumber_returns_a_south_african_close_corporation_registration_number()
        {
            Assert.AreEqual("CK74/7585/23", _companyFaker.SouthAfricanCloseCorporationRegistrationNumber());
        }

        [Test]
        public void SouthAfricanListedCompanyRegistrationNumber_returns_a_south_african_listed_company_registration_number()
        {
            Assert.AreEqual("7039/3135/06", _companyFaker.SouthAfricanListedCompanyRegistrationNumber());
        }

        [Test]
        public void SouthAfricanTrustRegistrationNumber_returns_a_south_african_trust_registration_number()
        {
            Assert.AreEqual("IT38/6489900", _companyFaker.SouthAfricanTrustRegistrationNumber());
        }
    }
}
