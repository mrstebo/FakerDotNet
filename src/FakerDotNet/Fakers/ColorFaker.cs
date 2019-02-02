using System.Collections.Generic;
using System.Linq;
using FakerDotNet.Data;

namespace FakerDotNet.Fakers
{
    public interface IColorFaker
    {
        string HexColor();
        string ColorName();
        IEnumerable<byte> RgbColor();
        IEnumerable<double> HslColor();
        IEnumerable<double> HslaColor();
    }

    internal class ColorFaker : IColorFaker
    {
        private readonly IFakerContainer _fakerContainer;

        public ColorFaker(IFakerContainer fakerContainer)
        {
            _fakerContainer = fakerContainer;
        }

        public string HexColor()
        {
            var n = (int) _fakerContainer.Number.Between(0, 0xffffff);
            return $"#{n:x}".PadLeft(6, '0');
        }

        public string ColorName()
        {
            return _fakerContainer.Random.Element(ColorData.Names);
        }

        public IEnumerable<byte> RgbColor()
        {
            return Enumerable.Range(0, 3)
                .Select(_ => (byte) _fakerContainer.Number.Between(0, 255))
                .ToArray();
        }

        public IEnumerable<double> HslColor()
        {
            return Enumerable.Range(0, 3)
                .Select(_ => _fakerContainer.Number.Between(0, 255))
                .ToArray();
        }

        public IEnumerable<double> HslaColor()
        {
            return Enumerable.Range(0, 3)
                .Select(_ => _fakerContainer.Number.Between(0, 255))
                .Concat(new[] {_fakerContainer.Number.Between(0, 1)})
                .ToArray();
        }
    }
}
