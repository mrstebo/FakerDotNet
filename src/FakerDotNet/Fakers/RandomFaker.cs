using System;
using System.Collections.Generic;
using System.Linq;

namespace FakerDotNet.Fakers
{
    public interface IRandomFaker
    {
        T Element<T>(IEnumerable<T> collection);
        IEnumerable<T> Elements<T>(IEnumerable<T> collection, int count);
    }

    internal class RandomFaker : IRandomFaker
    {
        private static readonly Random RNG = new Random();

        public T Element<T>(IEnumerable<T> collection)
        {
            // ReSharper disable PossibleMultipleEnumeration
            var index = RNG.Next(0, collection.Count());

            return collection.ElementAtOrDefault(index);
            // ReSharper restore PossibleMultipleEnumeration
        }

        public IEnumerable<T> Elements<T>(IEnumerable<T> collection, int count)
        {
            return collection.OrderBy(x => RNG.Next()).Take(count); 
        }
    }
}