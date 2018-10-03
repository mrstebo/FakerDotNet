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
            return _fakerContainer.Random.Element(Data.FirstNames);
        }

        public string LastName()
        {
            return _fakerContainer.Random.Element(Data.LastNames);
        }

        public string Prefix()
        {
            return _fakerContainer.Random.Element(Data.Prefixes);
        }

        public string Suffix()
        {
            return _fakerContainer.Random.Element(Data.Suffixes);
        }

        public string Title()
        {
            return string.Join(" ",
                _fakerContainer.Random.Element(Data.TitleDescriptors),
                _fakerContainer.Random.Element(Data.TitleLevels),
                _fakerContainer.Random.Element(Data.TitleJobs));
        }
    }
}