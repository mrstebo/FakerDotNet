using System;
using System.Linq;
using System.Text.RegularExpressions;
using FakerDotNet.Data;

namespace FakerDotNet.Fakers
{
    public interface ICompanyFaker
    {
        string Name();
        string Suffix();
        string Industry();
        string CatchPhrase();
        string Buzzword();
        string Bs();
        string Ein();
        string DunsNumber();
        string Logo();
        string Type();
        string Profession();
        string SwedishOrganisationNumber();
        string CzechOrganisationNumber();
        string FrenchSirenNumber();
        string FrenchSiretNumber();
        string NorwegianOrganisationNumber();
        string AustralianBusinessNumber();
        string SpanishOrganisationNumber();
        string PolishTaxpayerIdentificationNumber();
        string PolishRegisterOfNationalEconomy();
        string SouthAfricanPtyLtdRegistrationNumber();
        string SouthAfricanCloseCorporationRegistrationNumber();
        string SouthAfricanListedCompanyRegistrationNumber();
        string SouthAfricanTrustRegistrationNumber();
    }

    internal class CompanyFaker : ICompanyFaker
    {
        private readonly IFakerContainer _fakerContainer;

        public CompanyFaker(IFakerContainer fakerContainer)
        {
            _fakerContainer = fakerContainer;
        }

        public string Name()
        {
            return Parse(_fakerContainer.Random.Element(CompanyData.Names));
        }

        public string Suffix()
        {
            return _fakerContainer.Random.Element(CompanyData.Suffixes);
        }

        public string Industry()
        {
            return _fakerContainer.Random.Element(CompanyData.Industries);
        }

        public string CatchPhrase()
        {
            return string.Join(" ", CompanyData.Buzzwords.Select(_fakerContainer.Random.Element));
        }

        public string Buzzword()
        {
            return _fakerContainer.Random.Element(CompanyData.Buzzwords.SelectMany(x => x));
        }

        public string Bs()
        {
            return string.Join(" ", CompanyData.Bs.Select(_fakerContainer.Random.Element));
        }

        public string Ein()
        {
            throw new NotImplementedException();
        }

        public string DunsNumber()
        {
            throw new NotImplementedException();
        }

        public string Logo()
        {
            var n = _fakerContainer.Number.Between(1, 13);
            return $"https://pigment.github.io/fake-logos/logos/medium/color/{n}.png";
        }

        public string Type()
        {
            return _fakerContainer.Random.Element(CompanyData.Types);
        }

        public string Profession()
        {
            return _fakerContainer.Random.Element(CompanyData.Professions);
        }

        public string SwedishOrganisationNumber()
        {
            throw new NotImplementedException();
        }

        public string CzechOrganisationNumber()
        {
            throw new NotImplementedException();
        }

        public string FrenchSirenNumber()
        {
            throw new NotImplementedException();
        }

        public string FrenchSiretNumber()
        {
            throw new NotImplementedException();
        }

        public string NorwegianOrganisationNumber()
        {
            throw new NotImplementedException();
        }

        public string AustralianBusinessNumber()
        {
            throw new NotImplementedException();
        }

        public string SpanishOrganisationNumber()
        {
            throw new NotImplementedException();
        }

        public string PolishTaxpayerIdentificationNumber()
        {
            throw new NotImplementedException();
        }

        public string PolishRegisterOfNationalEconomy()
        {
            throw new NotImplementedException();
        }

        public string SouthAfricanPtyLtdRegistrationNumber()
        {
            throw new NotImplementedException();
        }

        public string SouthAfricanCloseCorporationRegistrationNumber()
        {
            throw new NotImplementedException();
        }

        public string SouthAfricanListedCompanyRegistrationNumber()
        {
            throw new NotImplementedException();
        }

        public string SouthAfricanTrustRegistrationNumber()
        {
            throw new NotImplementedException();
        }
        
        private string Parse(string format)
        {
            var text = Regex.Replace(format, @"\{(\w+)\}", @"{Company.$1}");

            return _fakerContainer.Fake.F(text);
        }
    }
}
        
