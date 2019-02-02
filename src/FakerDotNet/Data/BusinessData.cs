using System.Collections.Generic;

namespace FakerDotNet.Data
{
    internal static class BusinessData
    {
        public static readonly IEnumerable<string> CreditCardNumbers = new[]
        {
            "1234-2121-1221-1211",
            "1212-1221-1121-1234",
            "1211-1221-1234-2201",
            "1228-1221-1221-1431"
        };

        public static readonly IEnumerable<string> CreditCardTypes = new[]
        {
            "visa",
            "mastercard",
            "american_express",
            "discover",
            "diners_club",
            "jcb",
            "switch",
            "solo",
            "dankort",
            "maestro",
            "forbrugsforeningen",
            "laser"
        };
    }
}
