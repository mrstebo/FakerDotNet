using System.Collections.Generic;

namespace FakerDotNet.Data
{
    internal static class UniversityData
    {
        public static readonly IEnumerable<string> Names = new[]
        {
            "{Name.LastName} {Suffix}",
            "{Prefix} {Name.LastName} {Suffix}",
            "{Prefix} {Name.LastName}",
            "{Prefix} {Address.State} {Suffix}"
        };

        public static readonly IEnumerable<string> Prefixes = new[]
        {
            "The",
            "Northern",
            "North",
            "Western",
            "West",
            "Southern",
            "South",
            "Eastern",
            "East"
        };

        public static readonly IEnumerable<string> Suffixes = new[]
        {
            "University",
            "Institute",
            "College",
            "Academy"
        };

        public static readonly IEnumerable<string> GreekAlphabets = new[]
        {
            "Α",
            "B",
            "Γ",
            "Δ",
            "E",
            "Z",
            "H",
            "Θ",
            "I",
            "K",
            "Λ",
            "M",
            "N",
            "Ξ",
            "O",
            "Π",
            "P",
            "Σ",
            "T",
            "Y",
            "Φ",
            "X",
            "Ψ",
            "Ω"
        };
    }
}
