using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using FakerDotNet.Wrappers;

namespace FakerDotNet.Fakers
{
    public interface IFakeFaker
    {
        string F(string format);
    }

    internal class FakeFaker : IFakeFaker
    {
        private readonly IFakerContainer _fakerContainer;
        private readonly IStackTraceWrapper _stackTraceWrapper;

        public FakeFaker(IFakerContainer fakerContainer)
            : this(fakerContainer, new StackTraceWrapper())
        {
        }

        internal FakeFaker(IFakerContainer fakerContainer, IStackTraceWrapper stackTraceWrapper)
        {
            _fakerContainer = fakerContainer;
            _stackTraceWrapper = stackTraceWrapper;
        }

        public string F(string format)
        {
            if (string.IsNullOrEmpty(format)) return string.Empty;

            var calleeFaker = GetCalleeFaker();
            var placeholders = GetPlaceholders(format).ToArray();
            var result = placeholders.Aggregate(format,
                (current, placeholder) => Parse(current, GetFakerMatch(calleeFaker, placeholder, current)));

            return Numerify(result);
        }

        private string GetCalleeFaker()
        {
            var callee = _stackTraceWrapper.GetClassAtFrame(2) ?? "";

            return Regex.Replace(callee, @"(Faker|FakerTests)$", "");
        }

        private static IEnumerable<string> GetPlaceholders(string input)
        {
            const string pattern = @"\{(\w+)\}|\{(\w+)\.(\w+)\}";

            return Regex.Matches(input, pattern)
                .Cast<Match>()
                .Where(x => x.Success)
                .Select(x => x.Value);
        }

        private static FakerMatch GetFakerMatch(string calleeFaker, string placeholder, string input)
        {
            var pattern = Regex.Escape(placeholder);
            var match = Regex.Match(input, pattern);
            var split = match.Value.Replace("{", "").Replace("}", "").Split('.');
            var name = split.Length > 1 ? split[0] : calleeFaker;
            var method = split.Length > 1 ? split[1] : split[0];

            return new FakerMatch
            {
                Index = match.Index,
                Length = match.Length,
                Name = name,
                Method = method
            };
        }

        private string Parse(string input, FakerMatch match)
        {
            var value = GetValue(match.Name, match.Method) ?? input;
            var start = input.Substring(0, match.Index);
            var end = input.Substring(match.Index + match.Length);

            return $"{start}{value}{end}";
        }

        private object GetValue(string faker, string method)
        {
            switch (faker.ToLowerInvariant())
            {
                case "address":
                    return GetValueForAddressFaker(method);

                case "ancient":
                    return GetValueForAncientFaker(method);

                case "app":
                    return GetValueForAppFaker(method);

                case "avatar":
                    return GetValueForAvatarFaker(method);

                case "bank":
                    return GetValueForBankFaker(method);

                case "beer":
                    return GetValueForBeerFaker(method);

                case "book":
                    return GetValueForBookFaker(method);

                case "boolean":
                    return GetValueForBooleanFaker(method);

                case "business":
                    return GetValueForBusinessFaker(method);

                case "cat":
                    return GetValueForCatFaker(method);

                case "chucknorris":
                    return GetValueForChuckNorrisFaker(method);

                case "coffee":
                    return GetValueForCoffeeFaker(method);

                case "color":
                    return GetValueForColorFaker(method);

                case "commerce":
                    return GetValueForCommerceFaker(method);

                case "company":
                    return GetValueForCompanyFaker(method);

                case "compass":
                    return GetValueForCompassFaker(method);

                case "creditcard":
                    return GetValueForCreditCardFaker(method);

                case "date":
                    return GetValueForDateFaker(method);

                case "demographic":
                    return GetValueForDemographicFaker(method);

                case "dragonball":
                    return GetValueForDragonBallFaker(method);

                case "educator":
                    return GetValueForEducatorFaker(method);

                case "file":
                    return GetValueForFileFaker(method);

                case "fillmurray":
                    return GetValueForFillmurrayFaker(method);

                case "food":
                    return GetValueForFoodFaker(method);

                case "gameofthrones":
                    return GetValueForGameOfThronesFaker(method);

                case "hacker":
                    return GetValueForHackerFaker(method);

                case "harrypotter":
                    return GetValueForHarryPotterFaker(method);

                case "hipster":
                    return GetValueForHipsterFaker(method);

                case "internet":
                    return GetValueForInternetFaker(method);

                case "lordoftherings":
                    return GetValueForLordOfTheRingsFaker(method);

                case "lorem":
                    return GetValueForLoremFaker(method);

                case "loremflickr":
                    return GetValueForLoremFlickrFaker(method);

                case "lorempixel":
                    return GetValueForLoremPixelFaker(method);

                case "matz":
                    return GetValueForMatzFaker(method);

                case "michaelscott":
                    return GetValueForMichaelScottFaker(method);

                case "music":
                    return GetValueForMusicFaker(method);

                case "name":
                    return GetValueForNameFaker(method);

                case "number":
                    return GetValueForNumberFaker(method);

                case "phonenumber":
                    return GetValueForPhoneNumberFaker(method);

                case "placeholdit":
                    return GetValueForPlaceholditFaker(method);

                case "pokemon":
                    return GetValueForPokemonFaker(method);

                case "rickandmorty":
                    return GetValueForRickAndMortyFaker(method);

                case "rockband":
                    return GetValueForRockBandFaker(method);

                case "rupaul":
                    return GetValueForRuPaulFaker(method);

                case "slackemoji":
                    return GetValueForSlackEmojiFaker(method);

                case "space":
                    return GetValueForSpaceFaker(method);

                case "starwars":
                    return GetValueForStarWarsFaker(method);

                case "superhero":
                    return GetValueForSuperheroFaker(method);

                case "team":
                    return GetValueForTeamFaker(method);

                case "time":
                    return GetValueForTimeFaker(method);

                case "twinpeaks":
                    return GetValueForTwinPeaksFaker(method);

                case "university":
                    return GetValueForUniversityFaker(method);

                case "vehicle":
                    return GetValueForVehicleFaker(method);

                case "zelda":
                    return GetValueForZeldaFaker(method);

                default:
                    return null;
            }
        }

        private object GetValueForAddressFaker(string method)
        {
            switch (method.ToLowerInvariant())
            {
                case "city":
                    return _fakerContainer.Address.City();

                case "streetname":
                    return _fakerContainer.Address.StreetName();

                case "streetaddress":
                    return _fakerContainer.Address.StreetAddress();

                case "secondaryaddress":
                    return _fakerContainer.Address.SecondaryAddress();

                case "buildingnumber":
                    return _fakerContainer.Address.BuildingNumber();

                case "community":
                    return _fakerContainer.Address.Community();

                case "zipcode":
                    return _fakerContainer.Address.ZipCode();

                case "zip":
                    return _fakerContainer.Address.Zip();

                case "postcode":
                    return _fakerContainer.Address.Postcode();

                case "timezone":
                    return _fakerContainer.Address.TimeZone();

                case "streetsuffix":
                    return _fakerContainer.Address.StreetSuffix();

                case "citysuffix":
                    return _fakerContainer.Address.CitySuffix();

                case "cityprefix":
                    return _fakerContainer.Address.CityPrefix();

                case "state":
                    return _fakerContainer.Address.State();

                case "stateabbr":
                    return _fakerContainer.Address.StateAbbr();

                case "country":
                    return _fakerContainer.Address.Country();

                case "countrycode":
                    return _fakerContainer.Address.CountryCode();

                case "countrycodelong":
                    return _fakerContainer.Address.CountryCodeLong();

                case "latitude":
                    return _fakerContainer.Address.Latitude();

                case "longitude":
                    return _fakerContainer.Address.Longitude();

                case "fulladdress":
                    return _fakerContainer.Address.FullAddress();

                default:
                    return null;
            }
        }

        private object GetValueForAncientFaker(string method)
        {
            switch (method.ToLowerInvariant())
            {
                case "god":
                    return _fakerContainer.Ancient.God();

                case "primordial":
                    return _fakerContainer.Ancient.Primordial();

                case "titan":
                    return _fakerContainer.Ancient.Titan();

                case "hero":
                    return _fakerContainer.Ancient.Hero();

                default:
                    return null;
            }
        }

        private object GetValueForAppFaker(string method)
        {
            switch (method.ToLowerInvariant())
            {
                case "name":
                    return _fakerContainer.App.Name();

                case "version":
                    return _fakerContainer.App.Version();

                case "author":
                    return _fakerContainer.App.Author();

                default:
                    return null;
            }
        }

        private object GetValueForAvatarFaker(string method)
        {
            switch (method.ToLowerInvariant())
            {
                case "image":
                    return _fakerContainer.Avatar.Image();

                default:
                    return null;
            }
        }

        private object GetValueForBankFaker(string method)
        {
            switch (method.ToLowerInvariant())
            {
                case "accountnumber":
                    return _fakerContainer.Bank.AccountNumber();

                case "iban":
                    return _fakerContainer.Bank.Iban();

                case "name":
                    return _fakerContainer.Bank.Name();

                case "swiftbic":
                    return _fakerContainer.Bank.SwiftBic();

                default:
                    return null;
            }
        }

        private object GetValueForBeerFaker(string method)
        {
            switch (method.ToLowerInvariant())
            {
                case "brand":
                    return _fakerContainer.Beer.Brand();

                case "name":
                    return _fakerContainer.Beer.Name();

                case "style":
                    return _fakerContainer.Beer.Style();

                case "hop":
                    return _fakerContainer.Beer.Hop();

                case "yeast":
                    return _fakerContainer.Beer.Yeast();

                case "malts":
                    return _fakerContainer.Beer.Malts();

                case "ibu":
                    return _fakerContainer.Beer.Ibu();

                case "alcohol":
                    return _fakerContainer.Beer.Alcohol();

                case "blg":
                    return _fakerContainer.Beer.Blg();

                default:
                    return null;
            }
        }

        private object GetValueForBookFaker(string method)
        {
            switch (method.ToLowerInvariant())
            {
                case "title":
                    return _fakerContainer.Book.Title();

                case "author":
                    return _fakerContainer.Book.Author();

                case "publisher":
                    return _fakerContainer.Book.Publisher();

                case "genre":
                    return _fakerContainer.Book.Genre();

                default:
                    return null;
            }
        }

        private object GetValueForBooleanFaker(string method)
        {
            switch (method.ToLowerInvariant())
            {
                case "boolean":
                    return _fakerContainer.Boolean.Boolean();

                default:
                    return null;
            }
        }

        private object GetValueForBusinessFaker(string method)
        {
            switch (method.ToLowerInvariant())
            {
                case "creditcardnumber":
                    return _fakerContainer.Business.CreditCardNumber();

                case "creditcardexpirydate":
                    return _fakerContainer.Business.CreditCardExpiryDate();

                case "creditcardtype":
                    return _fakerContainer.Business.CreditCardType();

                default:
                    return null;
            }
        }

        private object GetValueForCatFaker(string method)
        {
            switch (method.ToLowerInvariant())
            {
                case "name":
                    return _fakerContainer.Cat.Name();

                case "breed":
                    return _fakerContainer.Cat.Breed();

                case "registry":
                    return _fakerContainer.Cat.Registry();

                default:
                    return null;
            }
        }

        private object GetValueForChuckNorrisFaker(string method)
        {
            switch (method.ToLowerInvariant())
            {
                case "fact":
                    return _fakerContainer.ChuckNorris.Fact();

                default:
                    return null;
            }
        }

        private object GetValueForCoffeeFaker(string method)
        {
            switch (method.ToLowerInvariant())
            {
                case "blendname":
                    return _fakerContainer.Coffee.BlendName();

                case "origin":
                    return _fakerContainer.Coffee.Origin();

                case "variety":
                    return _fakerContainer.Coffee.Variety();

                case "notes":
                    return _fakerContainer.Coffee.Notes();

                case "intensifier":
                    return _fakerContainer.Coffee.Intensifier();

                default:
                    return null;
            }
        }

        private object GetValueForColorFaker(string method)
        {
            switch (method.ToLowerInvariant())
            {
                case "hexcolor":
                    return _fakerContainer.Color.HexColor();

                case "colorname":
                    return _fakerContainer.Color.ColorName();

                case "rgbcolor":
                    return _fakerContainer.Color.RgbColor();

                case "hslcolor":
                    return _fakerContainer.Color.HslColor();

                case "hslacolor":
                    return _fakerContainer.Color.HslaColor();

                default:
                    return null;
            }
        }

        private object GetValueForCommerceFaker(string method)
        {
            switch (method.ToLowerInvariant())
            {
                case "color":
                    return _fakerContainer.Commerce.Color();

                case "department":
                    return _fakerContainer.Commerce.Department();

                case "material":
                    return _fakerContainer.Commerce.Material();

                case "productname":
                    return _fakerContainer.Commerce.ProductName();

                case "price":
                    return _fakerContainer.Commerce.Price();

                case "promotioncode":
                    return _fakerContainer.Commerce.PromotionCode();

                default:
                    return null;
            }
        }

        private object GetValueForCompanyFaker(string method)
        {
            switch (method.ToLowerInvariant())
            {
                case "name":
                    return _fakerContainer.Company.Name();

                case "suffix":
                    return _fakerContainer.Company.Suffix();

                case "industry":
                    return _fakerContainer.Company.Industry();

                case "catchphrase":
                    return _fakerContainer.Company.CatchPhrase();

                case "buzzword":
                    return _fakerContainer.Company.Buzzword();

                case "bs":
                    return _fakerContainer.Company.Bs();

                case "ein":
                    return _fakerContainer.Company.Ein();

                case "dunsnumber":
                    return _fakerContainer.Company.DunsNumber();

                case "logo":
                    return _fakerContainer.Company.Logo();

                case "type":
                    return _fakerContainer.Company.Type();

                case "profession":
                    return _fakerContainer.Company.Profession();

                case "swedishorganisationnumber":
                    return _fakerContainer.Company.SwedishOrganisationNumber();

                case "czechorganisationnumber":
                    return _fakerContainer.Company.CzechOrganisationNumber();

                case "frenchsirennumber":
                    return _fakerContainer.Company.FrenchSirenNumber();

                case "frenchsiretnumber":
                    return _fakerContainer.Company.FrenchSiretNumber();

                case "spanishorganisationnumber":
                    return _fakerContainer.Company.SpanishOrganisationNumber();

                case "southafricanptyltdregistrationnumber":
                    return _fakerContainer.Company.SouthAfricanPtyLtdRegistrationNumber();

                case "southafricanclosecorporationregistrationnumber":
                    return _fakerContainer.Company.SouthAfricanCloseCorporationRegistrationNumber();

                case "southafricanlistedcompanyregistrationnumber":
                    return _fakerContainer.Company.SouthAfricanListedCompanyRegistrationNumber();

                case "southafricantrustregistrationnumber":
                    return _fakerContainer.Company.SouthAfricanTrustRegistrationNumber();

                default:
                    return null;
            }
        }

        private object GetValueForCompassFaker(string method)
        {
            switch (method.ToLowerInvariant())
            {
                case "direction":
                    return _fakerContainer.Compass.Direction();

                case "cardinal":
                    return _fakerContainer.Compass.Cardinal();

                case "ordinal":
                    return _fakerContainer.Compass.Ordinal();

                case "halfwind":
                    return _fakerContainer.Compass.HalfWind();

                case "quarterwind":
                    return _fakerContainer.Compass.QuarterWind();

                case "abbreviation":
                    return _fakerContainer.Compass.Abbreviation();

                case "cardinalabbreviation":
                    return _fakerContainer.Compass.CardinalAbbreviation();

                case "ordinalabbreviation":
                    return _fakerContainer.Compass.OrdinalAbbreviation();

                case "halfwindabbreviation":
                    return _fakerContainer.Compass.HalfWindAbbreviation();

                case "quarterwindabbreviation":
                    return _fakerContainer.Compass.QuarterWindAbbreviation();

                case "azimuth":
                    return _fakerContainer.Compass.Azimuth();

                case "cardinalazimuth":
                    return _fakerContainer.Compass.CardinalAzimuth();

                case "ordinalazimuth":
                    return _fakerContainer.Compass.OrdinalAzimuth();

                case "halfwindazimuth":
                    return _fakerContainer.Compass.HalfWindAzimuth();

                case "quarterwindazimuth":
                    return _fakerContainer.Compass.QuarterWindAzimuth();

                default:
                    return null;
            }
        }

        private object GetValueForCreditCardFaker(string method)
        {
            switch (method.ToLowerInvariant())
            {
                case "number":
                    return _fakerContainer.CreditCard.Number();

                case "expirydate":
                    return _fakerContainer.CreditCard.ExpiryDate();

                case "brand":
                    return _fakerContainer.CreditCard.Brand();

                case "cvv":
                    return _fakerContainer.CreditCard.CVV();

                default:
                    return null;
            }
        }

        private object GetValueForDateFaker(string method)
        {
            switch (method.ToLowerInvariant())
            {
                case "forward":
                    return _fakerContainer.Date.Forward();

                case "backward":
                    return _fakerContainer.Date.Backward();

                case "birthday":
                    return _fakerContainer.Date.Birthday();

                default:
                    return null;
            }
        }

        private object GetValueForDemographicFaker(string method)
        {
            switch (method.ToLowerInvariant())
            {
                case "race":
                    return _fakerContainer.Demographic.Race();

                case "educationalattainment":
                    return _fakerContainer.Demographic.EducationalAttainment();

                case "demonym":
                    return _fakerContainer.Demographic.Demonym();

                case "maritalstatus":
                    return _fakerContainer.Demographic.MaritalStatus();

                case "sex":
                    return _fakerContainer.Demographic.Sex();

                case "height":
                    return _fakerContainer.Demographic.Height();

                default:
                    return null;
            }
        }

        private object GetValueForDragonBallFaker(string method)
        {
            switch (method.ToLowerInvariant())
            {
                case "character":
                    return _fakerContainer.DragonBall.Character();

                default:
                    return null;
            }
        }

        private object GetValueForEducatorFaker(string method)
        {
            switch (method.ToLowerInvariant())
            {
                case "university":
                    return _fakerContainer.Educator.University();

                case "secondaryschool":
                    return _fakerContainer.Educator.SecondarySchool();

                case "degree":
                    return _fakerContainer.Educator.Degree();

                case "coursename":
                    return _fakerContainer.Educator.CourseName();

                case "campus":
                    return _fakerContainer.Educator.Campus();

                default:
                    return null;
            }
        }

        private object GetValueForFileFaker(string method)
        {
            switch (method.ToLowerInvariant())
            {
                case "extension":
                    return _fakerContainer.File.Extension();

                case "mimetype":
                    return _fakerContainer.File.MimeType();

                case "filename":
                    return _fakerContainer.File.FileName();

                default:
                    return null;
            }
        }

        private object GetValueForFillmurrayFaker(string method)
        {
            switch (method.ToLowerInvariant())
            {
                case "image":
                    return _fakerContainer.Fillmurray.Image();

                default:
                    return null;
            }
        }

        private object GetValueForFoodFaker(string method)
        {
            switch (method.ToLowerInvariant())
            {
                case "dish":
                    return _fakerContainer.Food.Dish();

                case "description":
                    return _fakerContainer.Food.Description();

                case "ingredient":
                    return _fakerContainer.Food.Ingredient();

                case "fruit":
                    return _fakerContainer.Food.Fruit();

                case "vegetable":
                    return _fakerContainer.Food.Vegetable();

                case "spice":
                    return _fakerContainer.Food.Spice();

                case "sushi":
                    return _fakerContainer.Food.Sushi();

                case "measurement":
                    return _fakerContainer.Food.Measurement();

                case "metricmeasurement":
                    return _fakerContainer.Food.MetricMeasurement();

                default:
                    return null;
            }
        }

        private object GetValueForGameOfThronesFaker(string method)
        {
            switch (method.ToLowerInvariant())
            {
                case "character":
                    return _fakerContainer.GameOfThrones.Character();

                case "house":
                    return _fakerContainer.GameOfThrones.House();

                case "city":
                    return _fakerContainer.GameOfThrones.City();

                case "quote":
                    return _fakerContainer.GameOfThrones.Quote();

                case "dragon":
                    return _fakerContainer.GameOfThrones.Dragon();

                default:
                    return null;
            }
        }

        private object GetValueForHackerFaker(string method)
        {
            switch (method.ToLowerInvariant())
            {
                case "saysomethingsmart":
                    return _fakerContainer.Hacker.SaySomethingSmart();

                case "abbreviation":
                    return _fakerContainer.Hacker.Abbreviation();

                case "adjective":
                    return _fakerContainer.Hacker.Adjective();

                case "noun":
                    return _fakerContainer.Hacker.Noun();

                case "verb":
                    return _fakerContainer.Hacker.Verb();

                case "ingverb":
                    return _fakerContainer.Hacker.Ingverb();

                default:
                    return null;
            }
        }

        private object GetValueForHarryPotterFaker(string method)
        {
            switch (method.ToLowerInvariant())
            {
                case "character":
                    return _fakerContainer.HarryPotter.Character();

                case "location":
                    return _fakerContainer.HarryPotter.Location();

                case "quote":
                    return _fakerContainer.HarryPotter.Quote();

                case "book":
                    return _fakerContainer.HarryPotter.Book();

                case "house":
                    return _fakerContainer.HarryPotter.House();

                case "spell":
                    return _fakerContainer.HarryPotter.Spell();

                default:
                    return null;
            }
        }

        private object GetValueForHipsterFaker(string method)
        {
            switch (method.ToLowerInvariant())
            {
                case "word":
                    return _fakerContainer.Hipster.Word();

                case "words":
                    return _fakerContainer.Hipster.Words();

                case "sentence":
                    return _fakerContainer.Hipster.Sentence();

                case "sentences":
                    return _fakerContainer.Hipster.Sentences();

                case "paragraph":
                    return _fakerContainer.Hipster.Paragraph();

                case "paragraphs":
                    return _fakerContainer.Hipster.Paragraphs();

                case "paragraphbychars":
                    return _fakerContainer.Hipster.ParagraphByChars();

                default:
                    return null;
            }
        }

        private object GetValueForInternetFaker(string method)
        {
            switch (method.ToLowerInvariant())
            {
                case "email":
                    return _fakerContainer.Internet.Email();

                case "freeemail":
                    return _fakerContainer.Internet.FreeEmail();

                case "safeemail":
                    return _fakerContainer.Internet.SafeEmail();

                case "username":
                    return _fakerContainer.Internet.Username();

                case "password":
                    return _fakerContainer.Internet.Password();

                case "domainname":
                    return _fakerContainer.Internet.DomainName();

                case "domainword":
                    return _fakerContainer.Internet.DomainWord();

                case "domainsuffix":
                    return _fakerContainer.Internet.DomainSuffix();

                case "ipv4address":
                    return _fakerContainer.Internet.IPv4Address();

                case "privateipv4address":
                    return _fakerContainer.Internet.PrivateIPv4Address();

                case "publicipv4address":
                    return _fakerContainer.Internet.PublicIPv4Address();

                case "ipv4cidr":
                    return _fakerContainer.Internet.IPv4Cidr();

                case "ipv6address":
                    return _fakerContainer.Internet.IPv6Address();

                case "ipv6cidr":
                    return _fakerContainer.Internet.IPv6Cidr();

                case "macaddress":
                    return _fakerContainer.Internet.MacAddress();

                case "url":
                    return _fakerContainer.Internet.Url();

                case "slug":
                    return _fakerContainer.Internet.Slug();

                case "useragent":
                    return _fakerContainer.Internet.UserAgent();

                default:
                    return null;
            }
        }

        private object GetValueForLordOfTheRingsFaker(string method)
        {
            switch (method.ToLowerInvariant())
            {
                case "character":
                    return _fakerContainer.LordOfTheRings.Character();

                case "location":
                    return _fakerContainer.LordOfTheRings.Location();

                default:
                    return null;
            }
        }

        private object GetValueForLoremFaker(string method)
        {
            switch (method.ToLowerInvariant())
            {
                case "word":
                    return _fakerContainer.Lorem.Word();

                case "words":
                    return _fakerContainer.Lorem.Words();

                case "multibyte":
                    return _fakerContainer.Lorem.Multibyte();

                case "characters":
                    return _fakerContainer.Lorem.Characters();

                case "sentence":
                    return _fakerContainer.Lorem.Sentence();

                case "sentences":
                    return _fakerContainer.Lorem.Sentences();

                case "paragraph":
                    return _fakerContainer.Lorem.Paragraph();

                case "paragraphs":
                    return _fakerContainer.Lorem.Paragraphs();

                default:
                    return null;
            }
        }

        private object GetValueForLoremFlickrFaker(string method)
        {
            switch (method.ToLowerInvariant())
            {
                case "image":
                    return _fakerContainer.LoremFlickr.Image();

                case "grayscaleimage":
                    return _fakerContainer.LoremFlickr.GrayscaleImage();

                case "pixelatedimage":
                    return _fakerContainer.LoremFlickr.PixelatedImage();

                case "colorizedimage":
                    return _fakerContainer.LoremFlickr.ColorizedImage();

                default:
                    return null;
            }
        }

        private object GetValueForLoremPixelFaker(string method)
        {
            switch (method.ToLowerInvariant())
            {
                case "image":
                    return _fakerContainer.LoremPixel.Image();

                default:
                    return null;
            }
        }

        private object GetValueForMatzFaker(string method)
        {
            switch (method.ToLowerInvariant())
            {
                case "quote":
                    return _fakerContainer.Matz.Quote();

                default:
                    return null;
            }
        }

        private object GetValueForMichaelScottFaker(string method)
        {
            switch (method.ToLowerInvariant())
            {
                case "quote":
                    return _fakerContainer.MichaelScott.Quote();

                default:
                    return null;
            }
        }

        private object GetValueForMusicFaker(string method)
        {
            switch (method.ToLowerInvariant())
            {
                case "key":
                    return _fakerContainer.Music.Key();

                case "chord":
                    return _fakerContainer.Music.Chord();

                case "instrument":
                    return _fakerContainer.Music.Instrument();

                case "band":
                    return _fakerContainer.Music.Band();

                case "album":
                    return _fakerContainer.Music.Album();

                case "genre":
                    return _fakerContainer.Music.Genre();

                default:
                    return null;
            }
        }

        private object GetValueForNameFaker(string method)
        {
            switch (method.ToLowerInvariant())
            {
                case "name":
                    return _fakerContainer.Name.Name();

                case "namewithmiddle":
                    return _fakerContainer.Name.NameWithMiddle();

                case "firstname":
                    return _fakerContainer.Name.FirstName();

                case "lastname":
                    return _fakerContainer.Name.LastName();

                case "prefix":
                    return _fakerContainer.Name.Prefix();

                case "suffix":
                    return _fakerContainer.Name.Suffix();

                case "title":
                    return _fakerContainer.Name.Title();

                default:
                    return null;
            }
        }

        private object GetValueForNumberFaker(string method)
        {
            switch (method.ToLowerInvariant())
            {
                case "number":
                    return _fakerContainer.Number.Number();

                case "leadingzeronumber":
                    return _fakerContainer.Number.LeadingZeroNumber();

                case "decimal":
                    return _fakerContainer.Number.Decimal();

                case "normal":
                    return _fakerContainer.Number.Normal();

                case "hexadecimal":
                    return _fakerContainer.Number.Hexadecimal();

                case "positive":
                    return _fakerContainer.Number.Positive();

                case "negative":
                    return _fakerContainer.Number.Negative();

                case "nonzerodigit":
                    return _fakerContainer.Number.NonZeroDigit();

                case "digit":
                    return _fakerContainer.Number.Digit();

                default:
                    return null;
            }
        }

        private object GetValueForPhoneNumberFaker(string method)
        {
            switch (method.ToLowerInvariant())
            {
                case "phonenumber":
                    return _fakerContainer.PhoneNumber.PhoneNumber();

                case "cellphone":
                    return _fakerContainer.PhoneNumber.CellPhone();

                case "areacode":
                    return _fakerContainer.PhoneNumber.AreaCode();

                case "exchangecode":
                    return _fakerContainer.PhoneNumber.ExchangeCode();

                case "subscribernumber":
                    return _fakerContainer.PhoneNumber.SubscriberNumber();

                case "extension":
                    return _fakerContainer.PhoneNumber.Extension();

                default:
                    return null;
            }
        }

        private object GetValueForPlaceholditFaker(string method)
        {
            switch (method.ToLowerInvariant())
            {
                case "image":
                    return _fakerContainer.Placeholdit.Image();

                default:
                    return null;
            }
        }

        private object GetValueForPokemonFaker(string method)
        {
            switch (method.ToLowerInvariant())
            {
                case "name":
                    return _fakerContainer.Pokemon.Name();

                case "location":
                    return _fakerContainer.Pokemon.Location();

                case "move":
                    return _fakerContainer.Pokemon.Move();

                default:
                    return null;
            }
        }

        private object GetValueForRickAndMortyFaker(string method)
        {
            switch (method.ToLowerInvariant())
            {
                case "character":
                    return _fakerContainer.RickAndMorty.Character();

                case "location":
                    return _fakerContainer.RickAndMorty.Location();

                case "quote":
                    return _fakerContainer.RickAndMorty.Quote();

                default:
                    return null;
            }
        }

        private object GetValueForRockBandFaker(string method)
        {
            switch (method.ToLowerInvariant())
            {
                case "name":
                    return _fakerContainer.RockBand.Name();

                default:
                    return null;
            }
        }

        private object GetValueForRuPaulFaker(string method)
        {
            switch (method.ToLowerInvariant())
            {
                case "quote":
                    return _fakerContainer.RuPaul.Quote();

                case "queen":
                    return _fakerContainer.RuPaul.Queen();

                default:
                    return null;
            }
        }

        private object GetValueForSlackEmojiFaker(string method)
        {
            switch (method.ToLowerInvariant())
            {
                case "people":
                    return _fakerContainer.SlackEmoji.People();

                case "nature":
                    return _fakerContainer.SlackEmoji.Nature();

                case "foodanddrink":
                    return _fakerContainer.SlackEmoji.FoodAndDrink();

                case "celebration":
                    return _fakerContainer.SlackEmoji.Celebration();

                case "activity":
                    return _fakerContainer.SlackEmoji.Activity();

                case "travelandplaces":
                    return _fakerContainer.SlackEmoji.TravelAndPlaces();

                case "objectsandsymbols":
                    return _fakerContainer.SlackEmoji.ObjectsAndSymbols();

                case "custom":
                    return _fakerContainer.SlackEmoji.Custom();

                case "emoji":
                    return _fakerContainer.SlackEmoji.Emoji();

                default:
                    return null;
            }
        }

        private object GetValueForSpaceFaker(string method)
        {
            switch (method.ToLowerInvariant())
            {
                case "planet":
                    return _fakerContainer.Space.Planet();

                case "moon":
                    return _fakerContainer.Space.Moon();

                case "galaxy":
                    return _fakerContainer.Space.Galaxy();

                case "nebula":
                    return _fakerContainer.Space.Nebula();

                case "starcluster":
                    return _fakerContainer.Space.StarCluster();

                case "constellation":
                    return _fakerContainer.Space.Constellation();

                case "star":
                    return _fakerContainer.Space.Star();

                case "agency":
                    return _fakerContainer.Space.Agency();

                case "agencyabv":
                    return _fakerContainer.Space.AgencyAbv();

                case "nasaspacecraft":
                    return _fakerContainer.Space.NasaSpaceCraft();

                case "company":
                    return _fakerContainer.Space.Company();

                case "distancemeasurement":
                    return _fakerContainer.Space.DistanceMeasurement();

                case "meteorite":
                    return _fakerContainer.Space.Meteorite();

                case "launchvehicle":
                    return _fakerContainer.Space.LaunchVehicle();

                default:
                    return null;
            }
        }

        private object GetValueForStarWarsFaker(string method)
        {
            switch (method.ToLowerInvariant())
            {
                case "callsquadron":
                    return _fakerContainer.StarWars.CallSquadron();

                case "callsign":
                    return _fakerContainer.StarWars.CallSign();

                case "callnumber":
                    return _fakerContainer.StarWars.CallNumber();

                case "character":
                    return _fakerContainer.StarWars.Character();

                case "droid":
                    return _fakerContainer.StarWars.Droid();

                case "planet":
                    return _fakerContainer.StarWars.Planet();

                case "quote":
                    return _fakerContainer.StarWars.Quote();

                case "specie":
                    return _fakerContainer.StarWars.Specie();

                case "vehicle":
                    return _fakerContainer.StarWars.Vehicle();

                case "wookieesentence":
                    return _fakerContainer.StarWars.WookieeSentence();

                default:
                    return null;
            }
        }

        private object GetValueForSuperheroFaker(string method)
        {
            switch (method.ToLowerInvariant())
            {
                case "name":
                    return _fakerContainer.Superhero.Name();

                case "power":
                    return _fakerContainer.Superhero.Power();

                case "prefix":
                    return _fakerContainer.Superhero.Prefix();

                case "suffix":
                    return _fakerContainer.Superhero.Suffix();

                case "descriptor":
                    return _fakerContainer.Superhero.Descriptor();

                default:
                    return null;
            }
        }

        private object GetValueForTeamFaker(string method)
        {
            switch (method.ToLowerInvariant())
            {
                case "creature":
                    return _fakerContainer.Team.Creature();

                case "name":
                    return _fakerContainer.Team.Name();

                case "state":
                    return _fakerContainer.Team.State();

                case "sport":
                    return _fakerContainer.Team.Sport();

                case "mascot":
                    return _fakerContainer.Team.Mascot();

                default:
                    return null;
            }
        }

        private object GetValueForTimeFaker(string method)
        {
            switch (method.ToLowerInvariant())
            {
                case "forward":
                    return _fakerContainer.Time.Forward();

                case "backward":
                    return _fakerContainer.Time.Backward();

                default:
                    return null;
            }
        }

        private object GetValueForTwinPeaksFaker(string method)
        {
            switch (method.ToLowerInvariant())
            {
                case "character":
                    return _fakerContainer.TwinPeaks.Character();

                case "location":
                    return _fakerContainer.TwinPeaks.Location();

                case "quote":
                    return _fakerContainer.TwinPeaks.Quote();

                default:
                    return null;
            }
        }

        private object GetValueForUniversityFaker(string method)
        {
            switch (method.ToLowerInvariant())
            {
                case "name":
                    return _fakerContainer.University.Name();

                case "prefix":
                    return _fakerContainer.University.Prefix();

                case "suffix":
                    return _fakerContainer.University.Suffix();

                case "greekorganization":
                    return _fakerContainer.University.GreekOrganization();

                case "greekalphabet":
                    return _fakerContainer.University.GreekAlphabet();

                default:
                    return null;
            }
        }

        private object GetValueForVehicleFaker(string method)
        {
            switch (method.ToLowerInvariant())
            {
                case "vin":
                    return _fakerContainer.Vehicle.Vin();

                case "manufacture":
                    return _fakerContainer.Vehicle.Manufacture();

                case "make":
                    return _fakerContainer.Vehicle.Make();

                case "model":
                    return _fakerContainer.Vehicle.Model();

                case "makeandmodel":
                    return _fakerContainer.Vehicle.MakeAndModel();

                case "color":
                    return _fakerContainer.Vehicle.Color();

                case "transmission":
                    return _fakerContainer.Vehicle.Transmission();

                case "drivetype":
                    return _fakerContainer.Vehicle.DriveType();

                case "fueltype":
                    return _fakerContainer.Vehicle.FuelType();

                case "vehiclestyle":
                    return _fakerContainer.Vehicle.VehicleStyle();

                case "cartype":
                    return _fakerContainer.Vehicle.CarType();

                case "caroptions":
                    return _fakerContainer.Vehicle.CarOptions();

                case "standardspecs":
                    return _fakerContainer.Vehicle.StandardSpecs();

                case "doors":
                    return _fakerContainer.Vehicle.Doors();

                case "doorcount":
                    return _fakerContainer.Vehicle.DoorCount();

                case "enginesize":
                    return _fakerContainer.Vehicle.EngineSize();

                case "engine":
                    return _fakerContainer.Vehicle.Engine();

                case "year":
                    return _fakerContainer.Vehicle.Year();

                case "mileage":
                    return _fakerContainer.Vehicle.Mileage();

                case "kilometers":
                    return _fakerContainer.Vehicle.Kilometers();

                case "licenseplate":
                    return _fakerContainer.Vehicle.LicensePlate();

                default:
                    return null;
            }
        }

        private object GetValueForZeldaFaker(string method)
        {
            switch (method.ToLowerInvariant())
            {
                case "game":
                    return _fakerContainer.Zelda.Game();

                case "character":
                    return _fakerContainer.Zelda.Character();

                case "location":
                    return _fakerContainer.Zelda.Location();

                case "item":
                    return _fakerContainer.Zelda.Item();

                default:
                    return null;
            }
        }

        private string Numerify(string input)
        {
            return Regex.Replace(input, "#", m => _fakerContainer.Number.NonZeroDigit());
        }

        private struct FakerMatch
        {
            public int Index;
            public int Length;
            public string Name;
            public string Method;
        }
    }
}