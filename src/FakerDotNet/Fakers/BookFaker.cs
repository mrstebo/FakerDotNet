using FakerDotNet.Data;

namespace FakerDotNet.Fakers
{
    public interface IBookFaker
    {
        string Title();
        string Author();
        string Publisher();
        string Genre();
    }
    
    internal class BookFaker : IBookFaker
    {
        private static readonly BookData Data = new BookData();

        private readonly IFakerContainer _fakerContainer;

        public BookFaker(IFakerContainer fakerContainer)
        {
            _fakerContainer = fakerContainer;
        }

        public string Title()
        {
            return _fakerContainer.Random.Element(Data.Titles);
        }

        public string Author()
        {
            return $"{_fakerContainer.Name.FirstName()} {_fakerContainer.Name.LastName()}";
        }

        public string Publisher()
        {
            return _fakerContainer.Random.Element(Data.Publishers);
        }

        public string Genre()
        {
            return _fakerContainer.Random.Element(Data.Genres);
        }
    }
}
