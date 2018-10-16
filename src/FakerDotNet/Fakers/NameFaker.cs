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
        private readonly IFakerContainer _fakerContainer;

        public NameFaker(IFakerContainer fakerContainer)
        {
            _fakerContainer = fakerContainer;
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
            return _fakerContainer.Random.Element(NameData.FirstNames);
        }

        public string LastName()
        {
            return _fakerContainer.Random.Element(NameData.LastNames);
        }

        public string Prefix()
        {
            return _fakerContainer.Random.Element(NameData.Prefixes);
        }

        public string Suffix()
        {
            return _fakerContainer.Random.Element(NameData.Suffixes);
        }

        public string Title()
        {
            return string.Join(" ",
                _fakerContainer.Random.Element(NameData.TitleDescriptors),
                _fakerContainer.Random.Element(NameData.TitleLevels),
                _fakerContainer.Random.Element(NameData.TitleJobs));
        }
    }
}
