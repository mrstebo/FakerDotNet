using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using FakerDotNet.Algorithms;
using FakerDotNet.Data;
using FakerDotNet.Extensions;

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
            return string.Join("-",
                _fakerContainer.Number.Number(2),
                _fakerContainer.Number.Number(7));
        }

        public string DunsNumber()
        {
            return string.Join("-",
                _fakerContainer.Number.Number(2),
                _fakerContainer.Number.Number(3),
                _fakerContainer.Number.Number(4));
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
            // Get a random Swedish organization number. See more here https://sv.wikipedia.org/wiki/Organisationsnummer
            // Valid leading digit: 1, 2, 3, 5, 6, 7, 8, 9
            // Valid third digit: >= 2
            // Last digit is a control digit
            var @base = long.Parse(string.Join("",
                _fakerContainer.Number.NonZeroDigit(),
                _fakerContainer.Number.Digit(),
                (int) _fakerContainer.Number.Between(2, 9),
                _fakerContainer.Number.Number(6)
            ));
            return $"{@base}{LuhnAlgorithm.GetCheckValue(@base)}";
        }

        public string CzechOrganisationNumber()
        {
            var weights = new[] {8, 7, 6, 5, 4, 3, 2};
            var sum = 0;
            var @base = new List<int>();

            foreach (var weight in weights)
            {
                @base.Add(int.Parse(_fakerContainer.Number.Digit()));
                sum += (weight * @base[@base.Count - 1]);
            }

            @base.Add((11 - (sum % 11)) % 10);

            return string.Join("", @base);
        }

        public string FrenchSirenNumber()
        {
            // Get a random French SIREN number. See more here https://fr.wikipedia.org/wiki/Syst%C3%A8me_d%27identification_du_r%C3%A9pertoire_des_entreprises
            var @base = int.Parse(_fakerContainer.Number.Number(8));
            return $"{@base}{LuhnAlgorithm.GetCheckValue(@base)}";
        }

        public string FrenchSiretNumber()
        {
            var location = _fakerContainer.Number.LeadingZeroNumber(3).PadLeft(4, '0');
            var orgNumber = long.Parse(FrenchSirenNumber() + location);
            return $"{orgNumber}{LuhnAlgorithm.GetCheckValue(orgNumber)}";
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
            // Get a random Spanish organization number. See more here https://es.wikipedia.org/wiki/Número_de_identificación_fiscal
            // Valid leading character: A, B, C, D, E, F, G, H, J, N, P, Q, R, S, U, V, W
            // 7 digit numbers
            var letters = "ABCDEFGHIJKLMNOPQRSTUVW".Characters();
            return $"{_fakerContainer.Random.Element(letters)}{_fakerContainer.Number.Number(7)}";
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
        
