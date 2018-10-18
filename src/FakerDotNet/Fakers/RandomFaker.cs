using System;
using System.Collections.Generic;
using System.Linq;

namespace FakerDotNet.Fakers
{
    public interface IRandomFaker
    {
        T Element<T>(IEnumerable<T> collection);
        IEnumerable<T> Assortment<T>(IEnumerable<T> collection, int count);
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

        public IEnumerable<T> Assortment<T>(IEnumerable<T> collection, int count)
        {
            var array = collection.ToArray();
            var n = Math.Max(0, count);
            var repeatCount = (int) Math.Ceiling((double) n / array.Length);
            var repeated = Enumerable.Range(0, (repeatCount <= 0 ? 1 : repeatCount) * array.Length)
                .Select(i => array[i % array.Length])
                .ToArray();
            return Shuffle(repeated).Take(count);
        }

        private static IEnumerable<T> Shuffle<T>(IReadOnlyList<T> collection)
        {
            var rand = new Random();
            var index = -1;
            var result = new T[collection.Count];
            while (++index < collection.Count)
            {
                var n = rand.Next(0, index);
                result[index] = result[n];
                result[n] = collection[index];
            }
            return result;
        }
    }
}
