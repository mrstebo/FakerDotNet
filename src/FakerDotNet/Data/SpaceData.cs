﻿using System.Collections.Generic;

namespace FakerDotNet.Data
{
    internal class SpaceData
    {
        public IEnumerable<string> Planets => new[]
        {
            "Mercury", "Venus", "Earth", "Mars", "Jupiter", "Saturn", "Uranus", "Neptune"
        };

        public IEnumerable<string> Moons => new[]
        {
            "Moon", "Luna", "Deimos", "Phobos", "Ganymede", "Callisto", "Io", "Europa", "Titan", "Rhea", "Iapetus", "Dione", "Tethys", "Hyperion", "Ariel", "Puck", "Oberon", "Umbriel", "Triton", "Proteus"
        };

        public IEnumerable<string> Galaxies => new[]
        {
            "Milky Way", "Andromeda", "Triangulum", "Whirlpool", "Blackeye", "Sunflower", "Pinwheel", "Hoags Object", "Centaurus A", "Messier 83"
        };

        public IEnumerable<string> Nebulas => new[]
        {
            "Lagoon Nebula", "Eagle Nebula", "Triffid Nebula", "Dumbell Nebula", "Orion Nebula", "Ring Nebula", "Bodes Nebula", "Owl Nebula"
        };

        public IEnumerable<string> StarClusters => new[]
        {
            "Wild Duck", "Hyades", "Coma", "Butterfly", "Messier 7", "Pleiades", "Beehive Cluster", "Pearl Cluster", "Hodge 301", "Jewel Box Cluster", "Wishing Well Cluster", "Diamond Cluster", "Trumpler 10", "Collinder 140", "Liller 1", "Koposov II", "Koposov I", "Djorgovski 1", "Arp-Madore 1", "NGC 6144", "NGC 2808", "NGC 1783", "Messier 107", "Messier 70", "Omega Centauri", "Palomar 12", "Palomar 4", "Palomar 6", "Pyxis Cluster", "Segue 3"
        };

        public IEnumerable<string> Constellations => new[]
        {
            "Big Dipper", "Litte Dipper", "Orion", "Loe", "Gemini", "Cancer", "Canis Minor", "Canis Major", "Ursa Major", "Ursa Minor", "Virgo", "Libra", "Scorpius", "Sagittarius", "Lyra", "Capricornus", "Aquarius", "Pisces", "Aries", "Leo Minor", "Auriga"
        };

        public IEnumerable<string> Stars => new[]
        {
            "Sun", "Proxima Centauri", "Rigil Kentaurus", "Barnards Star", "Wolf 359", "Luyten 726-8A", "Luyten 726-8B", "Sirius A", "Sirius B", "Ross 154", "Ross 248", "Procyon A", "Procyon B", "Vega", "Rigel", "Arcturus", "Betelgeuse", "Mahasim", "Polaris"
        };

        public IEnumerable<string> Agencies => new[]
        {
            "National Aeronautics and Space Administration", "European Space Agency", "German Aerospace Center", "Indian Space Research Organization", "China National Space Administration", "UK Space Agency", "Brazilian Space Agency", "Mexican Space Agency", "Israeli Space Agency", "Italian Space Agency", "Japan Aerospace Exploration Agency", "National Space Agency of Ukraine", "Russian Federal Space Agency", "Swedish National Space Board"
        };

        public IEnumerable<string> AgencyAbvs => new[]
        {
            "NASA", "AEM", "AEB", "UKSA", "CSA", "CNSA", "ESA", "DLR", "ISRO", "JAXA", "ISA", "CNES", "NSAU", "ROSCOSMOS", "SNSB"
        };

        public IEnumerable<string> NasaSpaceCraft => new[]
        {
            "Orion", "Mercury", "Gemini", "Apollo", "Enterprise", "Columbia", "Challenger", "Discovery", "Atlantis", "Endeavour"
        };

        public IEnumerable<string> Companies => new[]
        {
            "Rocket Lab", "SpaceX", "Blue Origin", "Virgin Galactic", "SpaceDev", "Bigelow Aerospace", "Orbital Sciences", "JPL", "NASA Jet Propulsion Laboratory"
        };

        public IEnumerable<string> DistanceMeasurements => new[]
        {
            "light years", "AU", "parsecs", "kiloparsecs", "megaparsecs"
        };

        public IEnumerable<string> Meteorites => new[]
        {
            "Aarhus", "Abee", "Adelie Land", "Adhi Kot", "Adzhi-Bogdo", "Santa Rosa de Viterbo", "Agen", "Akbarpur", "Albareto", "Allan Hills 84001", "Allan Hills A81005", "Allegan", "Allende", "Ambapur Nagla", "Andura", "Angers", "Angra dos Reis", "Ankober", "Anlong", "Annaheim", "Appley Bridge", "Arbol Solo", "Archie", "Arroyo Aguiar", "Assisi", "Atoka", "Avanhandava", "Bacubirito", "Baszkówka","Beardsley", "Bellsbank", "Bench Crater", "Benton", "Białystok", "Blithfield","Block Island", "Bovedy", "Brachina", "Brahin", "Brenham", "Buzzard Coulee","Campo del Cielo", "Canyon Diablo", "Cape York", "Carancas", "Chambord","Chassigny", "Chelyabinsk", "Chergach", "Chinga", "Chinguetti", "Claxton","Coahuila", "Cranbourne", "D'Orbigny", "Dronino", "Eagle Station", "Elbogen","Ensisheim", "Esquel", "Fukang", "Gancedo", "Gao–Guenie", "Gay Gulch", "Gebel Kamil", "Gibeon", "Goose Lake", "Grant", "Hadley Rille", "Heat Shield Rock","Hoba", "Homestead", "Hraschina", "Huckitta", "Imilac", "Itqiy", "Kaidun","Kainsaz", "Karoonda", "Kesen", "Krasnojarsk", "L'Aigle", "Lac Dodon", "Lake Murray", "Loreto", "Los Angeles", "Łowicz", "Mackinac Island", "Mbozi","Middlesbrough", "Millbillillie", "Mineo", "Monte Milone", "Moss","Mundrabilla", "Muonionalusta", "Murchison", "Nakhla", "Nantan","Neuschwanstein", "Northwest Africa 7034", "Northwest Africa 7325", "Norton County", "Novato", "Northwest Africa 3009", "Oileán Ruaidh (Martian)", "Old Woman", "Oldenburg", "Omolon", "Orgueil", "Ornans", "Osseo", "Österplana 065","Ourique", "Pallasovka", "Paragould", "Park Forest", "Pavlovka", "Peace River","Peekskill", "Penouille", "Polonnaruwa", "High Possil", "Příbram", "Pultusk","Qidong", "Richardton", "Santa Vitoria do Palmar", "Sayh al Uhaymir 169","Seymchan", "Shelter Island", "Shergotty", "Sikhote-Alin", "Sołtmany","Springwater", "St-Robert", "Stannern", "Sulagiri", "Sutter's Mill","Sylacauga", "Tagish Lake", "Tamdakht", "Tenham", "Texas Fireball", "Tissint","Tlacotepec", "Toluca", "Treysa", "Twannberg", "Veliky Ustyug", "Vermillion","Weston", "Willamette", "Winona", "Wold Cottage", "Yamato 000593","Yamato 691","Yamato 791197", "Yardymly", "Zagami", "Zaisho", "Zaklodzie"
        };

        public IEnumerable<string> LaunchVehicles => new[]
        {
            "Antares", "Ariane 5", "Atlas", "Diamant", "Dnepr", "Delta", "Electron", "Energia", "Europa", "Falcon 9", "Falcon Heavy", "GSLV", "Juno", "Long March", "Mercury-Redstone", "Minotaur", "Pegasus", "Proton", "PSLV", "Safir", "Shavit", "Saturn IV", "Semiorka", "Soyouz", "Titan", "Vega", "Veronique", "Zenit"
        };
    }
}