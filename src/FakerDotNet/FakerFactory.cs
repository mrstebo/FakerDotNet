namespace FakerDotNet
{
    public static class FakerFactory
    {
        public static IFaker Create() => new Faker();
    }
}