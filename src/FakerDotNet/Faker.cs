using FakerDotNet.Fakers;

namespace FakerDotNet
{
    public static class Faker
    {
        private static readonly IFakerContainer Container = new FakerContainer();

        public static IAddressFaker Address { get; } = Container.Address;
        public static IAppFaker App { get; } = Container.App;
        public static IBeerFaker Beer { get; } = Container.Beer;
        public static IBookFaker Book { get; } = Container.Book;
        public static IBooleanFaker Boolean { get; } = Container.Boolean;
        public static IBusinessFaker Business { get; } = Container.Business;
        public static IColorFaker Color { get; } = Container.Color;
        public static ICompanyFaker Company { get; } = Container.Company;
        public static IDateFaker Date { get; } = Container.Date;
        public static IFakeFaker Fake { get; } = Container.Fake;
        public static IFriendsFaker Friends { get; } = Container.Friends;
        public static IGameOfThronesFaker GameOfThrones { get; } = Container.GameOfThrones;
        public static ILoremFaker Lorem { get; } = Container.Lorem;
        public static INameFaker Name { get; } = Container.Name;
        public static INumberFaker Number { get; } = Container.Number;
        public static IPokemonFaker Pokemon { get; } = Container.Pokemon;
        public static IRandomFaker Random { get; } = Container.Random;
        public static ITeamFaker Team { get; } = Container.Team;
        public static IRockBandFaker RockBand { get; } = Container.RockBand;
        public static ISuperheroFaker Superhero { get; } = Container.Superhero;
        public static ITimeFaker Time { get; } = Container.Time;
        public static ITwinPeaksFaker TwinPeaks { get; } = Container.TwinPeaks;
        public static IUniversityFaker University { get; } = Container.University;
        public static IZeldaFaker Zelda { get; } = Container.Zelda;
    }
}
