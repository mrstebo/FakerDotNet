using FakeItEasy;
using FakerDotNet.Data;
using FakerDotNet.Fakers;
using FakerDotNet.Tests.Helpers;
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
    public class SpaceFakerTests
    {
        [SetUp]
        public void SetUp()
        {
            _fakerContainer = A.Fake<IFakerContainer>();
            _spaceFaker = new SpaceFaker(_fakerContainer);
        }

        private static readonly SpaceData Data = new SpaceData();

        private IFakerContainer _fakerContainer;
        private ISpaceFaker _spaceFaker;

        [Test]
        public void Planet_returns_a_planet()
        {
            A.CallTo(() => _fakerContainer.Random.Element(
                    A<IEnumerable<string>>.That.IsSameSequenceAs(Data.Planets)))
                .Returns(Data.Planets.First());

            Assert.AreEqual(Data.Planets.First(), _spaceFaker.Planet());
        }

        [Test]
        public void Moon_returns_a_moon()
        {
            A.CallTo(() => _fakerContainer.Random.Element(
                    A<IEnumerable<string>>.That.IsSameSequenceAs(Data.Moons)))
                .Returns(Data.Moons.First());

            Assert.AreEqual(Data.Moons.First(), _spaceFaker.Moon());
        }

        [Test]
        public void Galaxy_returns_a_galaxy()
        {
            A.CallTo(() => _fakerContainer.Random.Element(
                    A<IEnumerable<string>>.That.IsSameSequenceAs(Data.Galaxies)))
                .Returns(Data.Galaxies.First());

            Assert.AreEqual(Data.Galaxies.First(), _spaceFaker.Galaxy());
        }

        [Test]
        public void Nebula_returns_a_nebula()
        {
            A.CallTo(() => _fakerContainer.Random.Element(
                    A<IEnumerable<string>>.That.IsSameSequenceAs(Data.Nebulas)))
                .Returns(Data.Nebulas.First());

            Assert.AreEqual(Data.Nebulas.First(), _spaceFaker.Nebula());
        }

        [Test]
        public void StarCluster_returns_a_starcluster()
        {
            A.CallTo(() => _fakerContainer.Random.Element(
                    A<IEnumerable<string>>.That.IsSameSequenceAs(Data.StarClusters)))
                .Returns(Data.StarClusters.First());

            Assert.AreEqual(Data.StarClusters.First(), _spaceFaker.StarCluster());
        }

        [Test]
        public void Constellation_returns_a_constellation()
        {
            A.CallTo(() => _fakerContainer.Random.Element(
                    A<IEnumerable<string>>.That.IsSameSequenceAs(Data.Constellations)))
                .Returns(Data.Constellations.First());

            Assert.AreEqual(Data.Constellations.First(), _spaceFaker.Constellation());
        }

        [Test]
        public void Star_returns_a_star()
        {
            A.CallTo(() => _fakerContainer.Random.Element(
                    A<IEnumerable<string>>.That.IsSameSequenceAs(Data.Stars)))
                .Returns(Data.Stars.First());

            Assert.AreEqual(Data.Stars.First(), _spaceFaker.Star());
        }

        [Test]
        public void Agency_returns_an_agency()
        {
            A.CallTo(() => _fakerContainer.Random.Element(
                    A<IEnumerable<string>>.That.IsSameSequenceAs(Data.Agencies)))
                .Returns(Data.Agencies.First());

            Assert.AreEqual(Data.Agencies.First(), _spaceFaker.Agency());
        }

        [Test]
        public void Agencyabv_returns_an_agencyabv()
        {
            A.CallTo(() => _fakerContainer.Random.Element(
                    A<IEnumerable<string>>.That.IsSameSequenceAs(Data.AgencyAbvs)))
                .Returns(Data.AgencyAbvs.First());

            Assert.AreEqual(Data.AgencyAbvs.First(), _spaceFaker.AgencyAbv());
        }

        [Test]
        public void NasaSpaceCraft_returns_a_nasaspacecraft()
        {
            A.CallTo(() => _fakerContainer.Random.Element(
                    A<IEnumerable<string>>.That.IsSameSequenceAs(Data.NasaSpaceCraft)))
                .Returns(Data.NasaSpaceCraft.First());

            Assert.AreEqual(Data.NasaSpaceCraft.First(), _spaceFaker.NasaSpaceCraft());
        }

        [Test]
        public void Company_returns_a_company()
        {
            A.CallTo(() => _fakerContainer.Random.Element(
                    A<IEnumerable<string>>.That.IsSameSequenceAs(Data.Companies)))
                .Returns(Data.Companies.First());

            Assert.AreEqual(Data.Companies.First(), _spaceFaker.Company());
        }

        [Test]
        public void DistanceMeasurement_returns_a_distancemeasurement_with_two_digit_number()
        {
            100.Times(() =>
            {
                A.CallTo(() => _fakerContainer.Random.Element(
                        A<IEnumerable<string>>.That.IsSameSequenceAs(Data.DistanceMeasurements)))
                    .Returns(Data.DistanceMeasurements.First());

                var result = _spaceFaker.DistanceMeasurement();

                Assert.That(Regex.IsMatch(result, $@"[1-9]\d {Data.DistanceMeasurements.First()}"), $"Result did not match: {result}");
            });
        }

        [Test]
        public void Meteorite_returns_a_meteorite()
        {
            A.CallTo(() => _fakerContainer.Random.Element(
                    A<IEnumerable<string>>.That.IsSameSequenceAs(Data.Meteorites)))
                .Returns(Data.Meteorites.First());

            Assert.AreEqual(Data.Meteorites.First(), _spaceFaker.Meteorite());
        }

        [Test]
        public void LaunchVehicle_returns_a_launchvehicle()
        {
            A.CallTo(() => _fakerContainer.Random.Element(
                    A<IEnumerable<string>>.That.IsSameSequenceAs(Data.LaunchVehicles)))
                .Returns(Data.LaunchVehicles.First());

            Assert.AreEqual(Data.LaunchVehicles.First(), _spaceFaker.LaunchVehicle());
        }
    }
}
