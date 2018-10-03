namespace FakerDotNet
{
    public sealed class Range<T> where T : struct
    {
        public T Minimum { get; }
        public T Maximum { get; }

        public Range(T minimum, T maximum)
        {
            Minimum = minimum;
            Maximum = maximum;
        }
    }
}
