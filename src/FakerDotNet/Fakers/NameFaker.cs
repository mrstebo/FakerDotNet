using FakerDotNet.Data;

namespace FakerDotNet.Fakers
{
    public interface INameFaker
    {
        string Name();
        string NameWithMiddle();
        string FirstName();
        string LastName();
        string Prefix();
        string Suffix();
        string Title();
    }

    internal class NameFaker : INameFaker
    {
        private static readonly NameData Data = new NameData();
        
        private readonly IFaker _faker;

        public NameFaker(IFaker faker)
        {
            _faker = faker;
        }
        
        public string Name()
        {
            return $"{FirstName()} {LastName()}";
        }

        public string NameWithMiddle()
        {
            return $"{FirstName()} {FirstName()} {LastName()}";
        }

        public string FirstName()
        {
            return _faker.Random.Element(Data.FirstNames);
        }

        public string LastName()
        {
            return _faker.Random.Element(Data.LastNames);
        }

        public string Prefix()
        {
            return _faker.Random.Element(Data.Prefixes);
        }

        public string Suffix()
        {
            return _faker.Random.Element(Data.Suffixes);
        }

        public string Title()
        {
            return string.Join(" ",
                _faker.Random.Element(Data.TitleDescriptors),
                _faker.Random.Element(Data.TitleLevels),
                _faker.Random.Element(Data.TitleJobs));
        }
    }
}
