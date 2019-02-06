using System;
using FakerDotNet.Data;

namespace FakerDotNet.Fakers
{
    public interface IDemographicFaker
    {
        string Race();
        string EducationalAttainment();
        string Demonym();
        string MaritalStatus();
        string Sex();
        string Height(UnitType unitType = UnitType.Metric);
    }

    internal class DemographicFaker : IDemographicFaker
    {
        private readonly IFakerContainer _fakerContainer;

        public DemographicFaker(IFakerContainer fakerContainer)
        {
            _fakerContainer = fakerContainer;
        }

        public string Race()
        {
            return _fakerContainer.Random.Element(DemographicData.Races);
        }

        public string EducationalAttainment()
        {
            return _fakerContainer.Random.Element(DemographicData.EducationalAttainments);
        }

        public string Demonym()
        {
            return _fakerContainer.Random.Element(DemographicData.Demonyms);
        }

        public string MaritalStatus()
        {
            return _fakerContainer.Random.Element(DemographicData.MaritalStatuses);
        }

        public string Sex()
        {
            return _fakerContainer.Random.Element(DemographicData.Sexes);
        }

        public string Height(UnitType unitType = UnitType.Metric)
        {
            switch (unitType)
            {
                case UnitType.Imperial:
                    var inches = _fakerContainer.Number.Between(57, 86);
                    return $"{inches / 12:#} ft, {inches % 12} in";

                default:
                    return _fakerContainer.Number.Between(1.45, 2.13).ToString("#.##");
            }
        }
    }
}
