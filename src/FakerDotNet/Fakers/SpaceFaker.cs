using FakerDotNet.Data;
using System;

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
        private static readonly SpaceData Data = new SpaceData();
        private static readonly NumberFaker NumberFaker = new NumberFaker();

        private readonly IFakerContainer _fakerContainer;

        public SpaceFaker(IFakerContainer fakerContainer)
        {
            _fakerContainer = fakerContainer;
        }

        public string Planet()
        {
            return _fakerContainer.Random.Element(Data.Planets);
        }

        public string Moon()
        {
            return _fakerContainer.Random.Element(Data.Moons);
        }

        public string Galaxy()
        {
            return _fakerContainer.Random.Element(Data.Galaxies);
        }

        public string Nebula()
        {
            return _fakerContainer.Random.Element(Data.Nebulas);
        }

        public string StarCluster()
        {
            return _fakerContainer.Random.Element(Data.StarClusters);
        }

        public string Constellation()
        {
            return _fakerContainer.Random.Element(Data.Constellations);
        }

        public string Star()
        {
            return _fakerContainer.Random.Element(Data.Stars);
        }

        public string Agency()
        {
            return _fakerContainer.Random.Element(Data.Agencies);
        }

        public string AgencyAbv()
        {
            return _fakerContainer.Random.Element(Data.AgencyAbvs);
        }

        public string NasaSpaceCraft()
        {
            return _fakerContainer.Random.Element(Data.NasaSpaceCraft);
        }

        public string Company()
        {
            return _fakerContainer.Random.Element(Data.Companies);
        }

        public string DistanceMeasurement()
        {
            return $"{NumberFaker.Number(2)} {_fakerContainer.Random.Element(Data.DistanceMeasurements)}";
        }

        public string Meteorite()
        {
            return _fakerContainer.Random.Element(Data.Meteorites);
        }

        public string LaunchVehicle()
        {
            return _fakerContainer.Random.Element(Data.LaunchVehicles);
        }
    }
}
