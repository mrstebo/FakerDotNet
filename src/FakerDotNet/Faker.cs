using FakerDotNet.Fakers;

namespace FakerDotNet
{
    public static class Faker
    {
        private static readonly IFakerContainer Container = new FakerContainer();

        public static INameFaker Name { get; } = Container.Name;
        public static IRandomFaker Random { get; } = Container.Random;
    }
}