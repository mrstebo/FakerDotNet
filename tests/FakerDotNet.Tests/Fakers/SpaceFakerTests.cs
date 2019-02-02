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
                .Returns("Venus");

            Assert.AreEqual("Venus", _spaceFaker.Planet());
        }

        [Test]
        public void Moon_returns_a_moon()
        {
            A.CallTo(() => _fakerContainer.Random.Element(SpaceData.Moons))
                .Returns("Europa");

            Assert.AreEqual("Europa", _spaceFaker.Moon());
        }

        [Test]
        public void Galaxy_returns_a_galaxy()
        {
            A.CallTo(() => _fakerContainer.Random.Element(SpaceData.Galaxies))
                .Returns("Andromeda");

            Assert.AreEqual("Andromeda", _spaceFaker.Galaxy());
        }

        [Test]
        public void Nebula_returns_a_nebula()
        {
            A.CallTo(() => _fakerContainer.Random.Element(SpaceData.Nebulas))
                .Returns("Triffid Nebula");

            Assert.AreEqual("Triffid Nebula", _spaceFaker.Nebula());
        }

        [Test]
        public void StarCluster_returns_a_star_cluster()
        {
            A.CallTo(() => _fakerContainer.Random.Element(SpaceData.StarClusters))
                .Returns("Messier 70");

            Assert.AreEqual("Messier 70", _spaceFaker.StarCluster());
        }

        [Test]
        public void Constellation_returns_a_constellation()
        {
            A.CallTo(() => _fakerContainer.Random.Element(SpaceData.Constellations))
                .Returns("Orion");

            Assert.AreEqual("Orion", _spaceFaker.Constellation());
        }

        [Test]
        public void Star_returns_a_star()
        {
            A.CallTo(() => _fakerContainer.Random.Element(SpaceData.Stars))
                .Returns("Proxima Centauri");

            Assert.AreEqual("Proxima Centauri", _spaceFaker.Star());
        }

        [Test]
        public void Agency_returns_an_agency()
        {
            A.CallTo(() => _fakerContainer.Random.Element(SpaceData.Agencies))
                .Returns("Japan Aerospace Exploration Agency");

            Assert.AreEqual("Japan Aerospace Exploration Agency", _spaceFaker.Agency());
        }

        [Test]
        public void AgencyAbv_returns_an_agency_abbreviation()
        {
            A.CallTo(() => _fakerContainer.Random.Element(SpaceData.AgencyAbvs))
                .Returns("NASA");

            Assert.AreEqual("NASA", _spaceFaker.AgencyAbv());
        }

        [Test]
        public void NasaSpaceCraft_returns_a_nasa_spacecraft()
        {
            A.CallTo(() => _fakerContainer.Random.Element(SpaceData.NasaSpaceCraft))
                .Returns("Endeavour");

            Assert.AreEqual("Endeavour", _spaceFaker.NasaSpaceCraft());
        }

        [Test]
        public void Company_returns_a_company()
        {
            A.CallTo(() => _fakerContainer.Random.Element(SpaceData.Companies))
                .Returns("SpaceX");

            Assert.AreEqual("SpaceX", _spaceFaker.Company());
        }

        [Test]
        public void DistanceMeasurement_returns_a_distance_measurement_with_two_digit_number()
        {
            A.CallTo(() => _fakerContainer.Number.Number(2))
                .Returns("15");
            A.CallTo(() => _fakerContainer.Random.Element(SpaceData.DistanceMeasurements))
                .Returns("parsecs");

            Assert.AreEqual($"15 parsecs", _spaceFaker.DistanceMeasurement());
        }

        [Test]
        public void Meteorite_returns_a_meteorite()
        {
            A.CallTo(() => _fakerContainer.Random.Element(SpaceData.Meteorites))
                .Returns("Ensisheim");

            Assert.AreEqual("Ensisheim", _spaceFaker.Meteorite());
        }

        [Test]
        public void LaunchVehicle_returns_a_launch_vehicle()
        {
            A.CallTo(() => _fakerContainer.Random.Element(SpaceData.LaunchVehicles))
                .Returns("Saturn IV");

            Assert.AreEqual("Saturn IV", _spaceFaker.LaunchVehicle());
        }
    }
}
