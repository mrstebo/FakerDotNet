using FakerDotNet.Fakers;

namespace FakerDotNet
{
    public static class Faker
    {
        private static readonly IFakerContainer Container = new FakerContainer();

        public static IAddressFaker Address { get; } = Container.Address;
        public static IAncientFaker Ancient { get; } = Container.Ancient;
        public static IAppFaker App { get; } = Container.App;
        public static IAvatarFaker Avatar { get; } = Container.Avatar;
        public static IBankFaker Bank { get; } = Container.Bank;
        public static IBeerFaker Beer { get; } = Container.Beer;
        public static IBookFaker Book { get; } = Container.Book;
        public static IBooleanFaker Boolean { get; } = Container.Boolean;
        public static IBusinessFaker Business { get; } = Container.Business;
        public static ICatFaker Cat { get; } = Container.Cat;
        public static IChuckNorrisFaker ChuckNorris { get; } = Container.ChuckNorris;
        public static ICoffeeFaker Coffee { get; } = Container.Coffee;
        public static IColorFaker Color { get; } = Container.Color;
        public static ICommerceFaker Commerce { get; } = Container.Commerce;
        public static ICompanyFaker Company { get; } = Container.Company;
        public static ICompassFaker Compass { get; } = Container.Compass;
        public static IDateFaker Date { get; } = Container.Date;
        public static IDemographicFaker Demographic { get; } = Container.Demographic;
        public static IDragonBallFaker DragonBall { get; } = Container.DragonBall;
        public static IEducatorFaker Educator { get; } = Container.Educator;
        public static IFakeFaker Fake { get; } = Container.Fake;
        public static IFileFaker File { get; } = Container.File;
        public static IFillmurrayFaker Fillmurray { get; } = Container.Fillmurray;
        public static IFoodFaker Food { get; } = Container.Food;
        public static IFriendsFaker Friends { get; } = Container.Friends;
        public static IGameOfThronesFaker GameOfThrones { get; } = Container.GameOfThrones;
        public static IHackerFaker Hacker { get; } = Container.Hacker;
        public static IHarryPotterFaker HarryPotter { get; } = Container.HarryPotter;
        public static IHipsterFaker Hipster { get; } = Container.Hipster;
        public static IInternetFaker Internet { get; } = Container.Internet;
        public static ILordOfTheRingsFaker LordOfTheRings { get; } = Container.LordOfTheRings;
        public static ILoremFaker Lorem { get; } = Container.Lorem;
        public static ILoremFlickrFaker LoremFlickr { get; } = Container.LoremFlickr;
        public static ILoremPixelFaker LoremPixel { get; } = Container.LoremPixel;
        public static IMatzFaker Matz { get; } = Container.Matz;
        public static IMichaelScottFaker MichaelScott { get; } = Container.MichaelScott;
        public static IMusicFaker Music { get; } = Container.Music;
        public static INameFaker Name { get; } = Container.Name;
        public static INumberFaker Number { get; } = Container.Number;
        public static IPhoneNumberFaker PhoneNumber { get; } = Container.PhoneNumber;
        public static IPlaceholditFaker Placeholdit { get; } = Container.Placeholdit;
        public static IPokemonFaker Pokemon { get; } = Container.Pokemon;
        public static IRandomFaker Random { get; } = Container.Random;
        public static IRickAndMortyFaker RickAndMorty { get; } = Container.RickAndMorty;
        public static IRockBandFaker RockBand { get; } = Container.RockBand;
        public static IRuPaulFaker RuPaul { get; } = Container.RuPaul;
        public static ISlackEmojiFaker SlackEmoji { get; } = Container.SlackEmoji;
        public static ISpaceFaker Space { get; } = Container.Space;
        public static IStarWarsFaker StarWars { get; } = Container.StarWars;
        public static ISuperheroFaker Superhero { get; } = Container.Superhero;
        public static ITeamFaker Team { get; } = Container.Team;
        public static ITimeFaker Time { get; } = Container.Time;
        public static ITwinPeaksFaker TwinPeaks { get; } = Container.TwinPeaks;
        public static IUniversityFaker University { get; } = Container.University;
        public static IVehicleFaker Vehicle {get; } = Container.Vehicle;
        public static IZeldaFaker Zelda { get; } = Container.Zelda;
    }
}
