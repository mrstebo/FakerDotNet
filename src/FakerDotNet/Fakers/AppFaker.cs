using System.Linq;
using System.Text.RegularExpressions;
using FakerDotNet.Data;

namespace FakerDotNet.Fakers
{
    public interface IAppFaker
    {
        string Name();
        string Version();
        string Author();
    }

    internal class AppFaker : IAppFaker
    {
        private static readonly AppData Data = new AppData();

        private readonly IFakerContainer _fakerContainer;

        public AppFaker(IFakerContainer fakerContainer)
        {
            _fakerContainer = fakerContainer;
        }

        public string Name()
        {
            return _fakerContainer.Random.Element(Data.Names);
        }

        public string Version()
        {
            var numbers = Enumerable.Range(0, 9);
            var format = _fakerContainer.Random.Element(Data.Versions);

            return Regex.Replace(format, "#", m => _fakerContainer.Random.Element(numbers).ToString());
        }

        public string Author()
        {
            return $"{_fakerContainer.Name.FirstName()} {_fakerContainer.Name.LastName()}";
        }
    }
}
