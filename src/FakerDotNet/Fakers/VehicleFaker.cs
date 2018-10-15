using FakerDotNet.Data;
using System.Collections.Generic;

namespace FakerDotNet.Fakers
{
    public interface IVehicleFaker
    {
        string Vin();
        string Manufacture();
        string Make();
        string Model();
        string Model(string make);
        string MakeAndModel();
    }

    internal class VehicleFaker : IVehicleFaker
    {
        private static readonly VehicleData Data = new VehicleData();
        private int[] vinDigitPositionMultiplier = new[] { 8, 7, 6, 5, 4, 3, 2, 10, 0, 9, 8, 7, 6, 5, 4, 3, 2 };
        private Dictionary<char, int> vinDigitValues = new Dictionary<char, int>() { { 'A', 1 }, { 'B', 2 }, { 'C', 3 }, { 'D', 4 }, { 'E', 5 }, { 'F', 6 }, { 'G', 7 }, { 'H', 8 }, { 'J', 1 }, { 'K', 2 }, { 'L', 3 }, { 'M', 4 }, { 'N', 5 }, { 'P', 7 }, { 'R', 9 }, { 'S', 2 }, { 'T', 3 }, { 'U', 4 }, { 'V', 5 }, { 'W', 6 }, { 'X', 7 }, { 'Y', 8 }, { 'Z', 9 }, { '1', 1 }, { '2', 2 }, { '3', 3 }, { '4', 4 }, { '5', 5 }, { '6', 6 }, { '7', 7 }, { '8', 8 }, { '9', 9 }, { '0', 0 } };

        private readonly IFakerContainer _fakerContainer;

        public VehicleFaker(IFakerContainer fakerContainer)
        {
            this._fakerContainer = fakerContainer;
        }

        public string Make()
        {
            return _fakerContainer.Random.Element(Data.Makes);
        }

        public string Manufacture()
        {
            return _fakerContainer.Random.Element(Data.Manufactures);
        }

        public string Vin()
        {
            string vin = string.Empty;
            for (var i = 0; i < 8; i ++)
            {
                var e = _fakerContainer.Random.Element(vinDigitValues);
                vin += e.Key;
            }
            vin += '0';
            for (var i = 0; i < 8; i++)
            {
                vin += _fakerContainer.Random.Element(vinDigitValues).Key;
            }
            var checksum = GetChecksum(vin);


            return vin.Substring(0, 8) + checksum + vin.Substring(9, 8);
        }

        public string Model()
        {
            return Model(_fakerContainer.Random.Element(Data.Makes));
        }
        public string Model(string make)
        {
            return _fakerContainer.Random.Element(Data.Make_Models[make]);
        }

        public string MakeAndModel()
        {
            var make = Make();
            var model = Model(make);
            return $"{make} {model}";
        }

        public string GetChecksum(string vin)
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
