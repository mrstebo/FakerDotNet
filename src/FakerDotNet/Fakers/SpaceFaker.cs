using FakerDotNet.Data;

namespace FakerDotNet.Fakers
{
    public interface ISpaceFaker
    {
        string Planet();
        string Moon();
        string Galaxy();
        string Nebula();
        string StarCluster();
        string Constellation();
        string Star();
        string Agency();
        string AgencyAbv();
        string NasaSpaceCraft();
        string Company();
        string DistanceMeasurement();
        string Meteorite();
        string LaunchVehicle();
    }

    internal class SpaceFaker : ISpaceFaker
    {
        private readonly IFakerContainer _fakerContainer;

        public SpaceFaker(IFakerContainer fakerContainer)
        {
            _fakerContainer = fakerContainer;
        }

        public string Planet()
        {
            return _fakerContainer.Random.Element(SpaceData.Planets);
        }

        public string Moon()
        {
            return _fakerContainer.Random.Element(SpaceData.Moons);
        }

        public string Galaxy()
        {
            return _fakerContainer.Random.Element(SpaceData.Galaxies);
        }

        public string Nebula()
        {
            return _fakerContainer.Random.Element(SpaceData.Nebulas);
        }

        public string StarCluster()
        {
            return _fakerContainer.Random.Element(SpaceData.StarClusters);
        }

        public string Constellation()
        {
            return _fakerContainer.Random.Element(SpaceData.Constellations);
        }

        public string Star()
        {
            return _fakerContainer.Random.Element(SpaceData.Stars);
        }

        public string Agency()
        {
            return _fakerContainer.Random.Element(SpaceData.Agencies);
        }

        public string AgencyAbv()
        {
            return _fakerContainer.Random.Element(SpaceData.AgencyAbvs);
        }

        public string NasaSpaceCraft()
        {
            return _fakerContainer.Random.Element(SpaceData.NasaSpaceCraft);
        }

        public string Company()
        {
            return _fakerContainer.Random.Element(SpaceData.Companies);
        }

        public string DistanceMeasurement()
        {
            return string.Join(" ",
                _fakerContainer.Number.Number(2),
                _fakerContainer.Random.Element(SpaceData.DistanceMeasurements));
        }

        public string Meteorite()
        {
            return _fakerContainer.Random.Element(SpaceData.Meteorites);
        }

        public string LaunchVehicle()
        {
            return _fakerContainer.Random.Element(SpaceData.LaunchVehicles);
        }
    }
}
