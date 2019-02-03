using System;
using System.Linq;
using System.Text;
using FakerDotNet.Data;

namespace FakerDotNet.Fakers
{
    public interface ICommerceFaker
    {
        string Color();
        string Department(int max = 3, bool fixedAmount = false);
        string Material();
        string ProductName();
        string Price(Range<double> range = null);
        string PromotionCode(int digits = 6);
    }

    internal class CommerceFaker : ICommerceFaker
    {
        private readonly IFakerContainer _fakerContainer;

        public CommerceFaker(IFakerContainer fakerContainer)
        {
            _fakerContainer = fakerContainer;
        }

        public string Color()
        {
            return _fakerContainer.Color.ColorName();
        }

        public string Department(int max = 3, bool fixedAmount = false)
        {
            var num = fixedAmount ? max : Convert.ToInt32(_fakerContainer.Number.Between(1, max));
            
            if (num <= 1) return _fakerContainer.Random.Element(CommerceData.Departments);

            var departments = _fakerContainer.Random.Assortment(CommerceData.Departments, num).ToArray();

            return string.Join(" & ",
                string.Join(", ", departments.Take(departments.Length - 1)),
                departments.Last());
        }

        public string Material()
        {
            return _fakerContainer.Random.Element(CommerceData.Materials);
        }

        public string ProductName()
        {
            return string.Join(" ",
                _fakerContainer.Random.Element(CommerceData.ProductAdjectives),
                _fakerContainer.Random.Element(CommerceData.Materials),
                _fakerContainer.Random.Element(CommerceData.ProductNames));
        }

        public string Price(Range<double> range = null)
        {
            range = range ?? new Range<double>(0, 100);
            return _fakerContainer.Number.Between(range.Minimum, range.Maximum).ToString("#.##");
        }

        public string PromotionCode(int digits = 6)
        {
            return string.Join("",
                _fakerContainer.Random.Element(CommerceData.PromotionCodeAdjectives),
                _fakerContainer.Random.Element(CommerceData.PromotionCodeNouns),
                _fakerContainer.Number.Number(digits));
        }
    }
}