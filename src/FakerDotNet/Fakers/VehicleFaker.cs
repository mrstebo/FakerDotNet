using FakerDotNet.Data;
using FakerDotNet.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;

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
        string Color();
        string Transmission();
        string DriveType();
        string FuelType();
        string VehicleStyle();
        string CarType();
        IEnumerable<string> CarOptions();
        IEnumerable<string> StandardSpecs();
        int Doors();
        int DoorCount();
        int EngineSize();
        int Engine();
        int Year();
        int Mileage(int minium = 10000, int maxium = 90000);
        int Kilometers();
        string LicensePlate();
        string LicensePlate(string state);
    }

    internal class VehicleFaker : IVehicleFaker
    {
        private static readonly VehicleData Data = new VehicleData();
        private int[] vinDigitPositionMultiplier = new[] { 8, 7, 6, 5, 4, 3, 2, 10, 0, 9, 8, 7, 6, 5, 4, 3, 2 };
        private Dictionary<char, int> vinDigitValues = new Dictionary<char, int>() { { 'A', 1 }, { 'B', 2 }, { 'C', 3 }, { 'D', 4 }, { 'E', 5 }, { 'F', 6 }, { 'G', 7 }, { 'H', 8 }, { 'J', 1 }, { 'K', 2 }, { 'L', 3 }, { 'M', 4 }, { 'N', 5 }, { 'P', 7 }, { 'R', 9 }, { 'S', 2 }, { 'T', 3 }, { 'U', 4 }, { 'V', 5 }, { 'W', 6 }, { 'X', 7 }, { 'Y', 8 }, { 'Z', 9 }, { '1', 1 }, { '2', 2 }, { '3', 3 }, { '4', 4 }, { '5', 5 }, { '6', 6 }, { '7', 7 }, { '8', 8 }, { '9', 9 }, { '0', 0 } };
        
        private readonly IFakerContainer _fakerContainer;
        private readonly IRandomWrapper _randomWrapper;

        public VehicleFaker(IFakerContainer _fakerContainer)
            : this(_fakerContainer, new RandomWrapper())
        {
        }

        public VehicleFaker(IFakerContainer fakerContainer, IRandomWrapper randomWrapper)
        {
            this._fakerContainer = fakerContainer;
            this._randomWrapper = randomWrapper;
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

        public string Color()
        {
            return _fakerContainer.Random.Element(Data.Colors);
        }

        public string Transmission()
        {
            return _fakerContainer.Random.Element(Data.Transmissions);
        }

        public string DriveType()
        {
            return _fakerContainer.Random.Element(Data.DriveTypes);
        }

        public string FuelType()
        {
            return _fakerContainer.Random.Element(Data.FuelTypes);
        }

        public string VehicleStyle()
        {
            return _fakerContainer.Random.Element(Data.VehicleStyles);
        }

        public string CarType()
        {
            return _fakerContainer.Random.Element(Data.CarTypes);
        }

        public IEnumerable<string> CarOptions()
        {
            return _fakerContainer.Random.Assortment(Data.CarOptions, _randomWrapper.Next(5, 10));
        }

        public IEnumerable<string> StandardSpecs()
        {
            return _fakerContainer.Random.Assortment(Data.StandardSpecs, _randomWrapper.Next(5, 10));
        }

        public int Doors()
        {
            return _randomWrapper.Next(1, 4);
        }

        public int DoorCount()
        {
            return Doors();
        }

        public int EngineSize()
        {
            return _fakerContainer.Random.Element(Data.EngineSize);
        }

        public int Engine()
        {
            return EngineSize();
        }

        public int Year()
        {
            return _fakerContainer.Time.Backward(_randomWrapper.Next(365, 5475), TimePeriod.All).Year;
        }

        public int Mileage(int minium = 10000, int maxium = 90000) {
            return _randomWrapper.Next(minium, maxium);
        }

        public int Kilometers()
        {
            return Mileage();
        }

        public string LicensePlate()
        {
            return String.Join(String.Empty, Data.LicensePlateTemplate.ToCharArray().Select(ConvertsTemplateChar));
        }

        public string LicensePlate(string state)
        {
            var licensePlateTemplate = _fakerContainer.Random.Element(Data.LicensePlateTemplateByState[state]);
            return String.Join(String.Empty, licensePlateTemplate.ToCharArray().Select(ConvertsTemplateChar));
        }

        private string ConvertsTemplateChar(char c)
        {
            char[] alphabet = Enumerable.Range('A', 26).Select(x => (char)x).ToArray();

            if (c == '?')
            {
                return _fakerContainer.Random.Element(alphabet).ToString();
            }
            if (c == '#')
                return _fakerContainer
                    .Random.Element(Enumerable.Range(0, 9).ToArray()).ToString();

            return c.ToString();
        }
        private string GetChecksum(string vin)
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
