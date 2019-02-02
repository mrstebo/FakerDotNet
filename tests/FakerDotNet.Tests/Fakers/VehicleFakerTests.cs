using FakeItEasy;
using FakerDotNet.Fakers;
using FakerDotNet.Wrappers;
using NUnit.Framework;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using FakerDotNet.Data;

namespace FakerDotNet.Tests.Fakers
{
    [TestFixture]
    [Parallelizable]
    public class VehicleFakerTests
    {
        [SetUp]
        public void SetUp()
        {
            _fakerContainer = A.Fake<IFakerContainer>();
            _randomWrapper = A.Fake<IRandomWrapper>();
            _vehicleFaker = new VehicleFaker(_fakerContainer, _randomWrapper);
        }

        private IFakerContainer _fakerContainer;
        private IVehicleFaker _vehicleFaker;
        private IRandomWrapper _randomWrapper;

        [Test]
        public void Make_returns_a_make()
        {
            A.CallTo(() => _fakerContainer.Random.Element(VehicleData.Makes))
                .Returns("Honda");

            Assert.AreEqual("Honda", _vehicleFaker.Make());
        }

        [Test]
        public void Manufacture_returns_a_manufacture()
        {
            A.CallTo(() => _fakerContainer.Random.Element(VehicleData.Manufactures))
                .Returns("Lamborghini");

            Assert.AreEqual("Lamborghini", _vehicleFaker.Manufacture());
        }

        [Test]
        public void Vin_returns_a_valid_vin()
        {
            var fakerContainer = new FakerContainer();
            var vin = fakerContainer.Vehicle.Vin();

            Assert.AreEqual(17, vin.Length);
            Assert.False(vin.Any(c => c == 'I' || c == 'Q' || c == 'O'));
            Assert.IsTrue(Regex.Match(vin, @"^[A-Z0-9]{8}[X0-9][A-Z0-9]{8}", RegexOptions.IgnoreCase).Success, $"Vin was: {vin}");
        }

        [Test] 
        public void Model_returns_a_model()
        {
            A.CallTo(() => _fakerContainer.Random.Element(VehicleData.Makes))
                .Returns("Audi");
            A.CallTo(() => _fakerContainer.Random.Element(VehicleData.MakeModels["Audi"]))
                .Returns("A8");

            Assert.AreEqual("A8", _vehicleFaker.Model());
        }

        [Test]
        public void Model_returns_a_model_for_make()
        {
            A.CallTo(() => _fakerContainer.Random.Element(VehicleData.MakeModels["Toyota"]))
                .Returns("Prius");

            Assert.AreEqual("Prius", _vehicleFaker.Model("Toyota"));
        }

        [Test]
        public void MakeAndModel_returns_a_make_and_model() {
            A.CallTo(() => _fakerContainer.Random.Element(VehicleData.Makes))
                .Returns("Dodge");
            A.CallTo(() => _fakerContainer.Random.Element(VehicleData.MakeModels["Dodge"]))
                .Returns("Charger");

            Assert.AreEqual("Dodge Charger", _vehicleFaker.MakeAndModel());
        }

        [Test]
        public void Color_returns_a_color()
        {
            A.CallTo(() => _fakerContainer.Random.Element(VehicleData.Colors))
               .Returns("Red");

            Assert.AreEqual("Red", _vehicleFaker.Color());
        }

        [Test]
        public void Transmission_returns_a_transmission()
        {
            A.CallTo(() => _fakerContainer.Random.Element(VehicleData.Transmissions))
               .Returns("Automanual");

            Assert.AreEqual("Automanual", _vehicleFaker.Transmission());
        }

        [Test]
        public void DriveType_returns_a_drive_type()
        {
            A.CallTo(() => _fakerContainer.Random.Element(VehicleData.DriveTypes))
               .Returns("4x2/2-wheel drive");

            Assert.AreEqual("4x2/2-wheel drive", _vehicleFaker.DriveType());
        }

        [Test]
        public void FuelType_returns_a_fuel_type()
        {
            A.CallTo(() => _fakerContainer.Random.Element(VehicleData.FuelTypes))
               .Returns("Diesel");

            Assert.AreEqual("Diesel", _vehicleFaker.FuelType());
        }

        [Test]
        public void VehicleStyles_returns_a_vehicle_style()
        {
            A.CallTo(() => _fakerContainer.Random.Element(VehicleData.VehicleStyles))
               .Returns("ESi");

            Assert.AreEqual("ESi", _vehicleFaker.VehicleStyle());
        }

        [Test]
        public void CarTypes_returns_a_car_type()
        {
            A.CallTo(() => _fakerContainer.Random.Element(VehicleData.CarTypes))
               .Returns("Sedan");

            Assert.AreEqual("Sedan", _vehicleFaker.CarType());
        }


        [Test]
        public void CarOptions_returns_some_car_options()
        {
            var carOptions = new[]
            {
                "DVD System",
                "MP3 (Single Disc)",
                "Tow Package",
                "CD (Multi Disc)",
                "Cassette Player",
                "Bucket Seats",
                "Cassette Player",
                "Leather Interior",
                "AM/FM Stereo",
                "Third Row Seats"
            };

            A.CallTo(() => _randomWrapper.Next(5, 10))
                .Returns(10);
            A.CallTo(() => _fakerContainer.Random.Assortment(VehicleData.CarOptions, 10))
                .Returns(carOptions);

            Assert.AreEqual(carOptions, _vehicleFaker.CarOptions());
        }

        [Test]
        public void StandardSpecs_returns_some_standard_specs()
        {
            var standardSpecs = new[]
            {
                "Full-size spare tire w/aluminum alloy wheel",
                "Back-up camera",
                "Carpeted cargo area",
                "Silver accent IP trim finisher -inc: silver shifter finisher",
                "Back-up camera",
                "Water-repellent windshield & front door glass",
                "Floor carpeting"
            };
            
            A.CallTo(() => _randomWrapper.Next(5, 10))
               .Returns(8);
            A.CallTo(() => _fakerContainer.Random.Assortment(VehicleData.StandardSpecs, 8))
               .Returns(standardSpecs);

            Assert.AreEqual(standardSpecs, _vehicleFaker.StandardSpecs());
        }

        [Test]
        public void Doors_returns_a_door()
        {
            A.CallTo(() => _randomWrapper.Next(1, 4))
               .Returns(1);

            Assert.AreEqual(1, _vehicleFaker.Doors());
        }

        [Test]
        public void DoorCount_returns_a_door_count()
        {
            A.CallTo(() => _randomWrapper.Next(1, 4))
               .Returns(3);

            Assert.AreEqual(3, _vehicleFaker.DoorCount());
        }

        [Test]
        public void EngineSize_returns_an_engine_size()
        {
            A.CallTo(() => _fakerContainer.Random.Element(VehicleData.EngineSize))
               .Returns(6);

            Assert.AreEqual(6, _vehicleFaker.EngineSize());
        }

        [Test]
        public void Engine_returns_an_engine()
        {
            A.CallTo(() => _fakerContainer.Random.Element(VehicleData.EngineSize))
               .Returns(4);

            Assert.AreEqual(4, _vehicleFaker.Engine());
        }

        [Test]
        public void Year_returns_a_year()
        {
            A.CallTo(() => _randomWrapper.Next(365, 5475))
                .Returns(3650);
            A.CallTo(() => _fakerContainer.Time.Backward(3650, TimePeriod.All))
              .Returns(DateTime.Now.AddYears(-10));

            Assert.AreEqual(DateTime.Now.AddYears(-10).Year, _vehicleFaker.Year());
        }

        [Test]
        public void Mileage_returns_mileage_defaults()
        {
            A.CallTo(() => _randomWrapper.Next(10000, 90000))
                .Returns(26961);

            Assert.AreEqual(26961, _vehicleFaker.Mileage());
        }

        [Test]
        public void Mileage_returns_mileage_min_specified()
        {
            A.CallTo(() => _randomWrapper.Next(50000, 90000))
                .Returns(81557);

            Assert.AreEqual(81557, _vehicleFaker.Mileage(50000));
        }

        [Test]
        public void Mileage_returns_mileage_min_and_max_specified()
        {
            A.CallTo(() => _randomWrapper.Next(50000, 250000))
                .Returns(117503);

            Assert.AreEqual(117503, _vehicleFaker.Mileage(50000, 250000));
        }

        [Test]
        public void Kilometer_calls_mileage()
        {
            A.CallTo(() => _randomWrapper.Next(10000, 90000))
                .Returns(35378);

            Assert.AreEqual(35378, _vehicleFaker.Kilometers());
        }

        [Test]
        public void LicensePlate_returns_plate_no_state()
        {
            A.CallTo(() => _fakerContainer.Random.Element(VehicleData.LicensePlateAlphabet))
              .Returns('A');
            A.CallTo(() => _fakerContainer.Random.Element(VehicleData.LicensePlateNumbers))
             .Returns(1);

            Assert.AreEqual("AAA-1111", _vehicleFaker.LicensePlate());
        }

        [Test]
        public void LicensePlate_returns_plate_Florida_state()
        {
            A.CallTo(() => _fakerContainer.Random.Element(VehicleData.LicensePlateTemplateByState["FL"]))
              .Returns("??? ?##");
            A.CallTo(() => _fakerContainer.Random.Element(VehicleData.LicensePlateAlphabet))
              .Returns('T');
            A.CallTo(() => _fakerContainer.Random.Element(VehicleData.LicensePlateNumbers))
             .Returns(5);

            Assert.AreEqual("TTT T55", _vehicleFaker.LicensePlate("FL"));
        }
    }
}
