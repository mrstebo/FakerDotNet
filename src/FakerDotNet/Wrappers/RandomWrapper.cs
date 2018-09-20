using System;

namespace FakerDotNet.Wrappers
{
    internal interface IRandomWrapper
    {
        int Next(int min, int max);
    }
    
    internal class RandomWrapper : IRandomWrapper
    {
        private static readonly Random RandomInstance = new Random();
        
        public int Next(int min, int max)
        {
            return RandomInstance.Next(min, max);
        }
    }
}
