using System;
using FakerDotNet.Data;
using FakerDotNet.Wrappers;
using System.Collections.Generic;
using System.Linq;
using FakerDotNet.Checksums;

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
        int Mileage(int min = 10000, int max = 90000);
        int Kilometers();
        string LicensePlate();
        string LicensePlate(string state);
    }

    internal class VehicleFaker : IVehicleFaker
    {

        private readonly IFakerContainer _fakerContainer;
        private readonly IRandomWrapper _randomWrapper;

        public VehicleFaker(IFakerContainer fakerContainer)
            : this(fakerContainer, new RandomWrapper())
        {
        }

        public VehicleFaker(IFakerContainer fakerContainer, IRandomWrapper randomWrapper)
        {
            _fakerContainer = fakerContainer;
            _randomWrapper = randomWrapper;
        }

        public string Make()
        {
            return _fakerContainer.Random.Element(VehicleData.Makes);
        }

        public string Manufacture()
        {
            return _fakerContainer.Random.Element(VehicleData.Manufactures);
        }

        public string Vin()
        {
            var vin = string.Empty;
            for (var i = 0; i < 8; i++)
            {
                var e = _fakerContainer.Random.Element(VehicleVinChecksum.VehicleVinDigitValues);
                vin += e.Key;
            }

            vin += '0';
            for (var i = 0; i < 8; i++)
            {
                vin += _fakerContainer.Random.Element(VehicleVinChecksum.VehicleVinDigitValues).Key;
            }

            var checksum = VehicleVinChecksum.GetVehicleVinChecksum(vin);


            return vin.Substring(0, 8) + checksum + vin.Substring(9, 8);
        }

        public string Model()
        {
            return Model(_fakerContainer.Random.Element(VehicleData.Makes));
        }

        public string Model(string make)
        {
            return _fakerContainer.Random.Element(VehicleData.Make_Models[make]);
        }

        public string MakeAndModel()
        {
            var make = Make();
            var model = Model(make);
            return $"{make} {model}";
        }

        public string Color()
        {
            return _fakerContainer.Random.Element(VehicleData.Colors);
        }

        public string Transmission()
        {
            return _fakerContainer.Random.Element(VehicleData.Transmissions);
        }

        public string DriveType()
        {
            return _fakerContainer.Random.Element(VehicleData.DriveTypes);
        }

        public string FuelType()
        {
            return _fakerContainer.Random.Element(VehicleData.FuelTypes);
        }

        public string VehicleStyle()
        {
            return _fakerContainer.Random.Element(VehicleData.VehicleStyles);
        }

        public string CarType()
        {
            return _fakerContainer.Random.Element(VehicleData.CarTypes);
        }

        public IEnumerable<string> CarOptions()
        {
            return _fakerContainer.Random.Assortment(VehicleData.CarOptions, _randomWrapper.Next(5, 10));
        }

        public IEnumerable<string> StandardSpecs()
        {
            return _fakerContainer.Random.Assortment(VehicleData.StandardSpecs, _randomWrapper.Next(5, 10));
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
            return _fakerContainer.Random.Element(VehicleData.EngineSize);
        }

        public int Engine()
        {
            return EngineSize();
        }

        public int Year()
        {
            return _fakerContainer.Time.Backward(_randomWrapper.Next(365, 5475), TimePeriod.All).Year;
        }

        public int Mileage(int min = 10000, int max = 90000)
        {
            return _randomWrapper.Next(min, max);
        }

        public int Kilometers()
        {
            return Mileage();
        }

        public string LicensePlate()
        {
            return string.Join(string.Empty,
                VehicleData.LicensePlateTemplate.ToCharArray().Select(ConvertsTemplateChar));
        }

        public string LicensePlate(string state)
        {
            var licensePlateTemplate = _fakerContainer.Random.Element(VehicleData.LicensePlateTemplateByState[state]);
            return string.Join(string.Empty, licensePlateTemplate.ToCharArray().Select(ConvertsTemplateChar));
        }

        private string ConvertsTemplateChar(char c)
        {
            switch (c)
            {
                case '?':
                    return Convert.ToString(_fakerContainer.Random.Element(VehicleData.LicensePlateAlphabet));

                case '#':
                    return Convert.ToString(_fakerContainer.Random.Element(VehicleData.LicensePlateNumbers));

                default:
                    return Convert.ToString(c);
            }
        }
    }
}
