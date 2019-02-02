using FakeItEasy;
using FakerDotNet.Data;
using FakerDotNet.Fakers;
using FakerDotNet.Tests.Helpers;
using NUnit.Framework;
using System.Linq;
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

        private IFakerContainer _fakerContainer;
        private ISpaceFaker _spaceFaker;

        [Test]
        public void Planet_returns_a_planet()
        {
            A.CallTo(() => _fakerContainer.Random.Element(SpaceData.Planets))
                .Returns(SpaceData.Planets.First());

            Assert.AreEqual(SpaceData.Planets.First(), _spaceFaker.Planet());
        }

        [Test]
        public void Moon_returns_a_moon()
        {
            A.CallTo(() => _fakerContainer.Random.Element(SpaceData.Moons))
                .Returns(SpaceData.Moons.First());

            Assert.AreEqual(SpaceData.Moons.First(), _spaceFaker.Moon());
        }

        [Test]
        public void Galaxy_returns_a_galaxy()
        {
            A.CallTo(() => _fakerContainer.Random.Element(SpaceData.Galaxies))
                .Returns(SpaceData.Galaxies.First());

            Assert.AreEqual(SpaceData.Galaxies.First(), _spaceFaker.Galaxy());
        }

        [Test]
        public void Nebula_returns_a_nebula()
        {
            A.CallTo(() => _fakerContainer.Random.Element(SpaceData.Nebulas))
                .Returns(SpaceData.Nebulas.First());

            Assert.AreEqual(SpaceData.Nebulas.First(), _spaceFaker.Nebula());
        }

        [Test]
        public void StarCluster_returns_a_star_cluster()
        {
            A.CallTo(() => _fakerContainer.Random.Element(SpaceData.StarClusters))
                .Returns(SpaceData.StarClusters.First());

            Assert.AreEqual(SpaceData.StarClusters.First(), _spaceFaker.StarCluster());
        }

        [Test]
        public void Constellation_returns_a_constellation()
        {
            A.CallTo(() => _fakerContainer.Random.Element(SpaceData.Constellations))
                .Returns(SpaceData.Constellations.First());

            Assert.AreEqual(SpaceData.Constellations.First(), _spaceFaker.Constellation());
        }

        [Test]
        public void Star_returns_a_star()
        {
            A.CallTo(() => _fakerContainer.Random.Element(SpaceData.Stars))
                .Returns(SpaceData.Stars.First());

            Assert.AreEqual(SpaceData.Stars.First(), _spaceFaker.Star());
        }

        [Test]
        public void Agency_returns_an_agency()
        {
            A.CallTo(() => _fakerContainer.Random.Element(SpaceData.Agencies))
                .Returns(SpaceData.Agencies.First());

            Assert.AreEqual(SpaceData.Agencies.First(), _spaceFaker.Agency());
        }

        [Test]
        public void AgencyAbv_returns_an_agency_abreviation()
        {
            A.CallTo(() => _fakerContainer.Random.Element(SpaceData.AgencyAbvs))
                .Returns(SpaceData.AgencyAbvs.First());

            Assert.AreEqual(SpaceData.AgencyAbvs.First(), _spaceFaker.AgencyAbv());
        }

        [Test]
        public void NasaSpaceCraft_returns_a_nasa_spacecraft()
        {
            A.CallTo(() => _fakerContainer.Random.Element(SpaceData.NasaSpaceCraft))
                .Returns(SpaceData.NasaSpaceCraft.First());

            Assert.AreEqual(SpaceData.NasaSpaceCraft.First(), _spaceFaker.NasaSpaceCraft());
        }

        [Test]
        public void Company_returns_a_company()
        {
            A.CallTo(() => _fakerContainer.Random.Element(SpaceData.Companies))
                .Returns(SpaceData.Companies.First());

            Assert.AreEqual(SpaceData.Companies.First(), _spaceFaker.Company());
        }

        [Test]
        public void DistanceMeasurement_returns_a_distance_measurement_with_two_digit_number()
        {
            A.CallTo(() => _fakerContainer.Random.Element(SpaceData.DistanceMeasurements))
                .Returns(SpaceData.DistanceMeasurements.First());
            A.CallTo(() => _fakerContainer.Number.Number(2))
                .Returns("15");

            Assert.AreEqual($"15 {SpaceData.DistanceMeasurements.First()}", _spaceFaker.DistanceMeasurement());
        }

        [Test]
        public void Meteorite_returns_a_meteorite()
        {
            A.CallTo(() => _fakerContainer.Random.Element(SpaceData.Meteorites))
                .Returns(SpaceData.Meteorites.First());

            Assert.AreEqual(SpaceData.Meteorites.First(), _spaceFaker.Meteorite());
        }

        [Test]
        public void LaunchVehicle_returns_a_launch_vehicle()
        {
            A.CallTo(() => _fakerContainer.Random.Element(SpaceData.LaunchVehicles))
                .Returns(SpaceData.LaunchVehicles.First());

            Assert.AreEqual(SpaceData.LaunchVehicles.First(), _spaceFaker.LaunchVehicle());
        }
    }
}
