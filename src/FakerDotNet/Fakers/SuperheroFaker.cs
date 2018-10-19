using FakerDotNet.Data;
using System;
using System.Collections.Generic;

namespace FakerDotNet.Fakers
{
    public interface ISuperheroFaker
    {
        string Name();
        string Power();
        string Prefix();
        string Suffix();
        string Descriptor();
    }

    internal class SuperheroFaker : ISuperheroFaker
    {
        private readonly IFakerContainer _fakerContainer;

        public SuperheroFaker(IFakerContainer faker)
        {
            this._fakerContainer = faker;
        }

        public string Power()
        {
            return _fakerContainer.Random.Element(SuperheroData.Powers);
        }

        public string Prefix()
        {
            return _fakerContainer.Random.Element(SuperheroData.Prefixes);
        }

        public string Suffix()
        {
            return _fakerContainer.Random.Element(SuperheroData.Suffixes);
        }

        public string Descriptor()
        {
            return _fakerContainer.Random.Element(SuperheroData.Descriptors);
        }

        public string Name()
        {
            return string.Format(_fakerContainer.Random.Element(NameFormats), Prefix(), Descriptor(), Suffix());
        }

        public IEnumerable<string> NameFormats = new[]
        {
            "{0} {1} {2}",
            "{0} {1}",
            "{1} {2}",
            "{1}"
        };
    }
}
