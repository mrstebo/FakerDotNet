using System.Linq;

namespace FakerDotNet.Algorithms
{
    internal static class LuhnAlgorithm
    {
        public static int GetCheckValue(long number)
        {
            var sum = $"{number}"
                .ToCharArray()
                .Reverse()
                .Select(c => int.Parse(new string(c, 1)))
                .Select((x, i) => i % 2 == 0 ? x * 2 : x)
                .Select(SumAllDigits)
                .Sum();

            return sum % 10 == 0 ? 0 : (sum / 10 + 1) * 10 - sum;
        }

        private static int SumAllDigits(int number)
        {
            return $"{number}"
                .ToCharArray()
                .Sum(c => int.Parse(new string(c, 1)));
        }
    }
}
