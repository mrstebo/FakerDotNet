using System;
using System.Linq;
using System.Text;
using FakerDotNet.Wrappers;

namespace FakerDotNet.Fakers
{
    public interface INumberFaker
    {
        long Number(int digits = 10);
        decimal Decimal(int leftDigits = 5, int rightDigits = 2);
        double Normal(int mean = 1, int standardDeviation = 1);
        int Digit();
        string Hexadecimal(int digits = 6);
        double Between(double min, double max);
        double Within(Range<double> range);
        double Positive(double from = 1.00D, double to = 5000.00D);
        double Negative(double from = -5000.00D, double to = -1.00D);
    }

    internal class NumberFaker : INumberFaker
    {
        private readonly IRandomWrapper _randomWrapper;

        public NumberFaker()
            : this(new RandomWrapper())
        {
        }

        internal NumberFaker(IRandomWrapper randomWrapper)
        {
            _randomWrapper = randomWrapper;
        }

        public long Number(int digits = 10)
        {
            var sb = new StringBuilder();

            sb.Append(_randomWrapper.Next(digits > 1 ? 1 : 0, 9));
            sb.Append(string.Join("", Enumerable.Range(1, digits - 1).Select(_ => _randomWrapper.Next(0, 9))));

            return long.Parse(sb.ToString());
        }

        public decimal Decimal(int leftDigits = 5, int rightDigits = 2)
        {
            return decimal.Parse($"{Number(leftDigits)}.{Number(rightDigits)}");
        }

        public double Normal(int mean = 1, int standardDeviation = 1)
        {
            var theta = 2 * Math.PI * _randomWrapper.NextDouble();
            var rho = Math.Sqrt(-2 * Math.Log(1 - +_randomWrapper.NextDouble()));
            var scale = standardDeviation * rho;
            return mean + scale * Math.Cos(theta);
        }

        public int Digit()
        {
            return _randomWrapper.Next(0, 9);
        }

        public string Hexadecimal(int digits = 6)
        {
            return string.Join("", Enumerable.Range(0, digits).Select(_ => Digit().ToString("X")));
        }

        public double Between(double min, double max)
        {
            var realMin = Math.Min(min, max);
            var realMax = Math.Max(min, max);

            return _randomWrapper.NextDouble() * (realMax - realMin) + realMin;
        }

        public double Within(Range<double> range)
        {
            return Between(range.Minimum, range.Maximum);
        }

        public double Positive(double from = 1.00D, double to = 5000.00D)
        {
            return Between(from, to);
        }

        public double Negative(double from = -5000.00D, double to = -1.00D)
        {
            return Between(from, to);
        }
    }
}
