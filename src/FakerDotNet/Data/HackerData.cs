using System.Collections.Generic;

namespace FakerDotNet.Data
{
    internal static class HackerData
    {
        public static readonly IEnumerable<string> Abbreviations = new[]
        {
            "TCP",
            "HTTP",
            "SDD",
            "RAM",
            "GB",
            "CSS",
            "SSL",
            "AGP",
            "SQL",
            "FTP",
            "PCI",
            "AI",
            "ADP",
            "RSS",
            "XML",
            "EXE",
            "COM",
            "HDD",
            "THX",
            "SMTP",
            "SMS",
            "USB",
            "PNG",
            "SAS",
            "IB",
            "SCSI",
            "JSON",
            "XSS",
            "JBOD"
        };

        public static readonly IEnumerable<string> Adjectives = new[]
        {
            "auxiliary",
            "primary",
            "back-end",
            "digital",
            "open-source",
            "virtual",
            "cross-platform",
            "redundant",
            "online",
            "haptic",
            "multi-byte",
            "bluetooth",
            "wireless",
            "1080p",
            "neural, optical",
            "solid state",
            "mobile"
        };

        public static readonly IEnumerable<string> Nouns = new[]
        {
            "driver",
            "protocol",
            "bandwidth",
            "panel",
            "microchip",
            "program",
            "port",
            "card",
            "array",
            "interface",
            "system",
            "sensor",
            "firewall",
            "hard drive",
            "pixel",
            "alarm",
            "feed",
            "monitor",
            "application",
            "transmitter",
            "bus",
            "circuit",
            "capacitor",
            "matrix"
        };

        public static readonly IEnumerable<string> Verbs = new[]
        {
            "back up",
            "bypass",
            "hack",
            "override",
            "compress",
            "copy",
            "navigate",
            "index",
            "connect",
            "generate",
            "quantify",
            "calculate",
            "synthesize",
            "input",
            "transmit",
            "program",
            "reboot",
            "parse"
        };

        public static readonly IEnumerable<string> Ingverbs = new[]
        {
            "backing up",
            "bypassing",
            "hacking",
            "overriding",
            "compressing",
            "copying",
            "navigating",
            "indexing",
            "connecting",
            "generating",
            "quantifying",
            "calculating, synthesizing",
            "transmitting",
            "programming",
            "parsing"
        };

        public static readonly IEnumerable<string> Phrases = new[]
        {
            "If we {Verb} the {Noun}, we can get to the {Abbreviation} {Noun} through the {Adjective} {Abbreviation} {Noun}!",
            "We need to {Verb} the {Adjective} {Abbreviation} {Noun}!",
            "Try to {Verb} the {Abbreviation} {Noun}, maybe it will {Verb} the {Adjective} {Noun}!",
            "You can't {Verb} the {Noun} without {Ingverb} the {Adjective} {Abbreviation} {Noun}!",
            "Use the {Adjective} {Abbreviation} {Noun}, then you can {Verb} the {Adjective} {Noun}!",
            "The {Abbreviation} {Noun} is down, {Verb} the {Adjective} {Noun} so we can {Verb} the {Abbreviation} {Noun}!",
            "{Ingverb} the {Noun} won't do anything, we need to {Verb} the {Adjective} {Abbreviation} {Noun}!",
            "I'll {Verb} the {Adjective} {Abbreviation} {Noun}, that should {Noun} the {Abbreviation} {Noun}!"
        };
    }
}
