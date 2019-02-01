namespace FakerDotNet.Fakers
{
    public interface IFillmurrayFaker
    {
        string Image(bool grayscale = false, int width = 200, int height = 200);
    }

    internal class FillmurrayFaker : IFillmurrayFaker
    {
        public string Image(bool grayscale = false, int width = 200, int height = 200)
        {
            return grayscale
                ? $"https://fillmurray.com/g/{width}/{height}"
                : $"https://fillmurray.com/{width}/{height}";
        }
    }
}

