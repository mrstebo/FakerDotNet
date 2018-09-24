using System;
using System.Diagnostics.CodeAnalysis;

namespace FakerDotNet.Wrappers
{
    internal interface IRandomWrapper
    {
        int Next(int min, int max);
        double NextDouble();
    }

    [ExcludeFromCodeCoverage]
    internal class RandomWrapper : IRandomWrapper
    {
        private static readonly Random RandomInstance = new Random();

        public int Next(int min, int max) => RandomInstance.Next(min, max);

        public double NextDouble() => RandomInstance.NextDouble();
    }
}
