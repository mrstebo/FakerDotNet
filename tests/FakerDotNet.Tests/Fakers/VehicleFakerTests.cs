using FakeItEasy;
using FakerDotNet.Data;
using FakerDotNet.Fakers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

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
            _vehicleFaker = new VehicleFaker(_fakerContainer);
        }

        private static readonly VehicleData Data = new VehicleData();

        private IFakerContainer _fakerContainer;
        private IVehicleFaker _vehicleFaker;

        [Test]
        public void Make_returns_a_make()
        {
            A.CallTo(() => _fakerContainer.Random.Element(
                    A<IEnumerable<string>>.That.IsSameSequenceAs(Data.Makes)))
                .Returns("Honda");

            Assert.AreEqual("Honda", _vehicleFaker.Make());
        }

        [Test]
        public void Manufacture_returns_a_manufacture()
        {
            A.CallTo(() => _fakerContainer.Random.Element(
                    A<IEnumerable<string>>.That.IsSameSequenceAs(Data.Manufactures)))
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
    }
}
