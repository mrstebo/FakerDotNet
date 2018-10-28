using System.Collections.Generic;

namespace FakerDotNet.Algorithms
{
    internal static class VinCheckSum
    {
        public static int[] vinDigitPositionMultiplier = new[] { 8, 7, 6, 5, 4, 3, 2, 10, 0, 9, 8, 7, 6, 5, 4, 3, 2 };
        public static Dictionary<char, int> vinDigitValues = new Dictionary<char, int>() { { 'A', 1 }, { 'B', 2 }, { 'C', 3 }, { 'D', 4 }, { 'E', 5 }, { 'F', 6 }, { 'G', 7 }, { 'H', 8 }, { 'J', 1 }, { 'K', 2 }, { 'L', 3 }, { 'M', 4 }, { 'N', 5 }, { 'P', 7 }, { 'R', 9 }, { 'S', 2 }, { 'T', 3 }, { 'U', 4 }, { 'V', 5 }, { 'W', 6 }, { 'X', 7 }, { 'Y', 8 }, { 'Z', 9 }, { '1', 1 }, { '2', 2 }, { '3', 3 }, { '4', 4 }, { '5', 5 }, { '6', 6 }, { '7', 7 }, { '8', 8 }, { '9', 9 }, { '0', 0 } };

        public static string GetChecksum(string vin)
        {
            int checkSumTotal = 0;
            var vinArray = vin.ToCharArray();
            for (var i = 0; i < vinArray.Length; i++)
            {
                checkSumTotal += vinDigitValues[vinArray[i]] * vinDigitPositionMultiplier[i];
            }
            var remainder = checkSumTotal % 11;
            if (remainder == 10)
            {
                return "X";
            }
            return remainder.ToString();
        }
    }
}
