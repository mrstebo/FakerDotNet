using System.Text.RegularExpressions;
using FakerDotNet.Data;

namespace FakerDotNet.Fakers
{
    public interface ICompassFaker
    {
        string Direction();
        string Cardinal();
        string Ordinal();
        string HalfWind();
        string QuarterWind();
        string Abbreviation();
        string CardinalAbbreviation();
        string OrdinalAbbreviation();
        string HalfWindAbbreviation();
        string QuarterWindAbbreviation();
        string Azimuth();
        string CardinalAzimuth();
        string OrdinalAzimuth();
        string HalfWindAzimuth();
        string QuarterWindAzimuth();
    }

    internal class CompassFaker : ICompassFaker
    {
        private readonly IFakerContainer _fakerContainer;

        public CompassFaker(IFakerContainer fakerContainer)
        {
            _fakerContainer = fakerContainer;
        }

        public string Direction()
        {
            return Parse(_fakerContainer.Random.Element(CompassData.Directions));
        }

        public string Cardinal()
        {
            return _fakerContainer.Random.Element(CompassData.CardinalWords);
        }

        public string Ordinal()
        {
            return _fakerContainer.Random.Element(CompassData.OrdinalWords);
        }

        public string HalfWind()
        {
            return _fakerContainer.Random.Element(CompassData.HalfWindWords);
        }

        public string QuarterWind()
        {
            return _fakerContainer.Random.Element(CompassData.QuarterWindWords);
        }

        public string Abbreviation()
        {
            return Parse(_fakerContainer.Random.Element(CompassData.Abbreviations));
        }

        public string CardinalAbbreviation()
        {
            return _fakerContainer.Random.Element(CompassData.CardinalAbbreviations);
        }

        public string OrdinalAbbreviation()
        {
            return _fakerContainer.Random.Element(CompassData.OrdinalAbbreviations);
        }

        public string HalfWindAbbreviation()
        {
            return _fakerContainer.Random.Element(CompassData.HalfWindAbbreviations);
        }

        public string QuarterWindAbbreviation()
        {
            return _fakerContainer.Random.Element(CompassData.QuarterWindAbbreviations);
        }

        public string Azimuth()
        {
            return Parse(_fakerContainer.Random.Element(CompassData.Azimuths));
        }

        public string CardinalAzimuth()
        {
            return _fakerContainer.Random.Element(CompassData.CardinalAzimuths);
        }

        public string OrdinalAzimuth()
        {
            return _fakerContainer.Random.Element(CompassData.OrdinalAzimuths);
        }

        public string HalfWindAzimuth()
        {
            return _fakerContainer.Random.Element(CompassData.HalfWindAzimuths);
        }

        public string QuarterWindAzimuth()
        {
            return _fakerContainer.Random.Element(CompassData.QuarterWindAzimuths);
        }
        
        private string Parse(string format)
        {
            return _fakerContainer.Fake.F(format);
        }
    }
}
        
