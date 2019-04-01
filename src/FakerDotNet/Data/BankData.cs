using System.Collections.Generic;

namespace FakerDotNet.Data
{
    internal static class BankData
    {
        public static readonly IEnumerable<string> Names = new[]
        {
            "UBS CLEARING AND EXECUTION SERVICES LIMITED",
            "ABN AMRO CORPORATE FINANCE LIMITED",
            "ABN AMRO FUND MANAGERS LIMITED",
            "ABN AMRO HOARE GOVETT SECURITIES",
            "ABN AMRO HOARE GOVETT CORPORATE FINANCE LTD.",
            "ALKEN ASSET MANAGEMENT",
            "ALKEN ASSET MANAGEMENT",
            "ABN AMRO HOARE GOVETT LIMITED",
            "AAC CAPITAL PARTNERS LIMITED",
            "ABBOTSTONE AGRICULTURAL PROPERTY UNIT TRUST",
            "ABN AMRO QUOTED INVESTMENTS (UK) LIMITED",
            "ABN AMRO MEZZANINE (UK) LIMITED",
            "ABBEY LIFE",
            "SANTANDER UK PLC",
            "OTKRITIE SECURITIES LIMITED",
            "ABC INTERNATIONAL BANK PLC",
            "ALLIED BANK PHILIPPINES (UK) PLC",
            "ABU DHABI ISLAMIC BANK",
            "ABG SUNDAL COLLIER LIMITED",
            "PGMS (GLASGOW) LIMITED",
            "ABINGWORTH MANAGEMENT LIMITED",
            "THE ROYAL BANK OF SCOTLAND PLC (FORMER RBS NV)"
        };

        public static readonly IEnumerable<string> SwiftBics = new[]
        {
            "AACCGB21",
            "AACNGB21",
            "AAFMGB21",
            "AAHOGB21",
            "AAHVGB21",
            "AANLGB21",
            "AANLGB2L",
            "AAOGGB21",
            "AAPEGB21",
            "AAPUGB21",
            "AAQIGB21",
            "ABAZGB21",
            "ABBEGB21",
            "ABBYGB2L",
            "ABCCGB22",
            "ABCEGB2L",
            "ABCMGB21",
            "ABDIGB21",
            "ABECGB21",
            "ABFIGB21",
            "ABMNGB21",
            "ABNAGB21VOC"
        };

        public static readonly IReadOnlyDictionary<string, (int length, string pattern)> IbanDetails =
            new Dictionary<string, (int length, string pattern)>
            {
                {"ad", (24, @"\d{8}[A-Z0-9]{12}")}, // Andorra
                {"ae", (23, @"\d{19}")}, // United Arab Emirates
                {"al", (28, @"\d{8}[A-Z0-9]{16}")}, // Albania
                {"at", (20, @"\d{16}")}, // Austria
                {"az", (28, @"[A-Z]{4}[A-Z0-9]{20}")}, // Azerbaijan, Republic of
                {"ba", (20, @"\d{16}")}, // Bosnia
                {"be", (16, @"\d{12}")}, // Belgium
                {"bg", (22, @"[A-Z]{4}\d{6}[A-Z0-9]{8}")}, // Bulgaria
                {"bh", (22, @"[A-Z]{4}[A-Z0-9]{14}")}, // Bahrain
                {"br", (29, @"[0-9]{8}[0-9]{5}[0-9]{10}[A-Z]{1}[A-Z0-9]{1}")}, // Brazil
                {"ch", (21, @"\d{5}[A-Z0-9]{12}")}, // Switzerland
                {"cr", (22, @"0\d{3}\d{14}")}, // Costa Rica
                {"cy", (28, @"\d{8}[A-Z0-9]{16}")}, // Cyprus
                {"cz", (24, @"\d{20}")}, // Czech Republic
                {"de", (22, @"\d{18}")}, // Germany
                {"dk", (18, @"\d{14}")}, // Denmark
                {"do", (28, @"[A-Z]{4}\d{20}")}, // Dominican Republic
                {"ee", (20, @"\d{16}")}, // Estonia
                {"es", (24, @"\d{20}")}, // Spain
                {"fi", (18, @"\d{14}")}, // Finland
                {"fo", (18, @"\d{14}")}, // Faroe Islands
                {"fr", (27, @"\d{10}[A-Z0-9]{11}\d{2}")}, // France
                {"gb", (22, @"[A-Z]{4}\d{14}")}, // United Kingdom
                {"ge", (22, @"[A-Z]{2}\d{16}")}, // Georgia
                {"gi", (23, @"[A-Z]{4}[A-Z0-9]{15}")}, // Gibraltar
                {"gl", (18, @"\d{14}")}, // Greenland
                {"gr", (27, @"\d{7}[A-Z0-9]{16}")}, // Greece
                {"gt", (28, @"[A-Z0-9]{4}\d{2}\d{2}[A-Z0-9]{16}")}, // Guatemala
                {"hr", (21, @"\d{17}")}, // Croatia
                {"hu", (28, @"\d{24}")}, // Hungary
                {"ie", (22, @"[A-Z]{4}\d{14}")}, // Ireland
                {"il", (23, @"\d{19}")}, // Israel
                {"is", (26, @"\d{22}")}, // Iceland
                {"it", (27, @"[A-Z]\d{10}[A-Z0-9]{12}")}, // Italy
                {"kw", (30, @"[A-Z]{4}\d{22}")}, // Kuwait
                {"kz", (20, @"[0-9]{3}[A-Z0-9]{13}")}, // Kazakhstan
                {"lb", (28, @"\d{4}[A-Z0-9]{20}")}, // Lebanon
                {"li", (21, @"\d{5}[A-Z0-9]{12}")}, // Liechtenstein
                {"lt", (20, @"\d{16}")}, // Lithuania
                {"lu", (20, @"\d{3}[A-Z0-9]{13}")}, // Luxembourg
                {"lv", (21, @"[A-Z]{4}[A-Z0-9]{13}")}, // Latvia
                {"mc", (27, @"\d{10}[A-Z0-9]{11}\d{2}")}, // Monaco
                {"md", (24, @"[A-Z]{2}[A-Z0-9]{18}")}, // Moldova
                {"me", (22, @"\d{18}")}, // Montenegro
                {"mk", (19, @"\d{3}[A-Z0-9]{10}\d{2}")}, // Macedonia
                {"mr", (27, @"\d{23}")}, // Mauritania
                {"mt", (31, @"[A-Z]{4}\d{5}[A-Z0-9]{18}")}, // Malta
                {"mu", (30, @"[A-Z]{4}\d{19}[A-Z]{3}")}, // Mauritius
                {"nl", (18, @"[A-Z]{4}\d{10}")}, // Netherlands
                {"no", (15, @"\d{11}")}, // Norway
                {"pk", (24, @"[A-Z]{4}[A-Z0-9]{16}")}, // Pakistan
                {"pl", (28, @"\d{8}[A-Z0-9]{16}")}, // Poland
                {"ps", (29, @"[A-Z]{4}[A-Z0-9]{21}")}, // Palestinian Territory, Occupied
                {"pt", (25, @"\d{21}")}, // Portugal
                {"qa", (29, @"[A-Z]{4}[A-Z0-9]{21}")}, // Qatar
                {"ro", (24, @"[A-Z]{4}[A-Z0-9]{16}")}, // Romania
                {"rs", (22, @"\d{18}")}, // Serbia
                {"sa", (24, @"\d{2}[A-Z0-9]{18}")}, // Saudi Arabia
                {"se", (24, @"\d{20}")}, // Sweden
                {"si", (19, @"\d{15}")}, // Slovenia
                {"sk", (24, @"\d{20}")}, // Slovakia
                {"sm", (27, @"[A-Z]\d{10}[A-Z0-9]{12}")}, // San Marino
                {"tl", (23, @"\d{19}")}, // Timor-Leste
                {"tn", (24, @"\d{20}")}, // Tunisia
                {"tr", (26, @"\d{5}[A-Z0-9]{17}")}, // Turkey
                {"ua", (29, @"\d{25}")}, // Ukraine
                {"vg", (24, @"[A-Z]{4}\d{16}")}, // Virgin Islands, British
                {"xk", (20, @"\d{16}")}, // Kosovo, Republic of
            };
    }
}
