using System.Collections.Generic;

namespace FakerDotNet.Data
{
    internal static class CompassData
    {
        public static readonly IEnumerable<string> CardinalWords = new[]
        {
            "north",
            "east",
            "south",
            "west"
        };

        public static readonly IEnumerable<string> CardinalAbbreviations = new[]
        {
            "N",
            "E",
            "S",
            "W"
        };

        public static readonly IEnumerable<string> CardinalAzimuths = new[]
        {
            "0",
            "90",
            "180",
            "270"
        };
       
        public static readonly IEnumerable<string> OrdinalWords = new[]
        {
            "northeast",
            "southeast",
            "southwest",
            "northwest"
        };

        public static readonly IEnumerable<string> OrdinalAbbreviations = new[]
        {
            "NE",
            "SE",
            "SW",
            "NW"
        };

        public static readonly IEnumerable<string> OrdinalAzimuths = new[]
        {
            "45",
            "135",
            "225",
            "315"
        };
        
        public static readonly IEnumerable<string> HalfWindWords = new[]
        {
            "north-northeast",
            "east-northeast",
            "east-southeast",
            "south-southeast",
            "south-southwest",
            "west-southwest",
            "west-northwest",
            "north-northwest"
        };

        public static readonly IEnumerable<string> HalfWindAbbreviations = new[]
        {
            "NNE",
            "ENE",
            "ESE",
            "SSE",
            "SSW",
            "WSW",
            "WNW",
            "NNW"
        };

        public static readonly IEnumerable<string> HalfWindAzimuths = new[]
        {
            "22.5",
            "67.5",
            "112.5",
            "157.5",
            "202.5",
            "247.5",
            "292.5",
            "337.5"
        };
        
        public static readonly IEnumerable<string> QuarterWindWords = new[]
        {
            "north by east",
            "northeast by north",
            "northeast by east",
            "east by north",
            "east by south",
            "southeast by east",
            "southeast by south",
            "south by east",
            "south by west",
            "southwest by south",
            "southwest by west",
            "west by south",
            "west by north",
            "northwest by west",
            "northwest by north",
            "north by west"
        };

        public static readonly IEnumerable<string> QuarterWindAbbreviations = new[]
        {
            "NbE",
            "NEbN",
            "NEbE",
            "EbN",
            "EbS",
            "SEbE",
            "SEbS",
            "SbE",
            "SbW",
            "SWbS",
            "SWbW",
            "WbS",
            "WbN",
            "NWbW",
            "NWbN",
            "NbW"
        };

        public static readonly IEnumerable<string> QuarterWindAzimuths = new[]
        {
            "11.25",
            "33.75",
            "56.25",
            "78.75",
            "101.25",
            "123.75",
            "146.25",
            "168.75",
            "191.25",
            "213.75",
            "236.25",
            "258.75",
            "281.25",
            "303.75",
            "326.25",
            "348.75"
        };

        public static readonly IEnumerable<string> Directions = new[]
        {
            "{Cardinal}",
            "{Ordinal}",
            "{HalfWind}",
            "{QuarterWind}"
        };

        public static readonly IEnumerable<string> Abbreviations = new[]
        {
            "{CardinalAbbreviation}",
            "{OrdinalAbbreviation}",
            "{HalfWindAbbreviation}",
            "{QuarterWindAbbreviation}"
        };

        public static readonly IEnumerable<string> Azimuths = new[]
        {
            "{CardinalAzimuth}",
            "{OrdinalAzimuth}",
            "{HalfWindAzimuth}",
            "{QuarterWindAzimuth}"
        };
    }
}
