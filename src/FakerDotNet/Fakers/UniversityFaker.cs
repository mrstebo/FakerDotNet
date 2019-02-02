using FakerDotNet.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FakerDotNet.Fakers
{
    public interface IUniversityFaker
    {
        string Name();
        string Prefix();
        string Suffix();
        string GreekOrganization();
        string GreekAlphabet();
    }

    internal class UniversityFaker : IUniversityFaker
    {
        private readonly IFakerContainer _fakerContainer;
        
        public UniversityFaker(IFakerContainer faker)
        {
            _fakerContainer = faker;
        }

        public string Name()
        {
            return Parse(_fakerContainer.Random.Element(UniversityData.Names));
        }

        public string Prefix()
        {
            return _fakerContainer.Random.Element(UniversityData.Prefixes);
        }

        public string Suffix()
        {
            return _fakerContainer.Random.Element(UniversityData.Suffixes);
        }

        public string GreekOrganization()
        {
            return string.Join("", Enumerable.Repeat(GreekAlphabet(), 3));
        }

        public string GreekAlphabet()
        {
            return _fakerContainer.Random.Element(UniversityData.GreekAlphabets);
        }

        private string Parse(string format)
        {
            var text = Regex.Replace(format, @"\{(\w+)\}", @"{University.$1}");

            return _fakerContainer.Fake.F(text);
        }
    }
}
