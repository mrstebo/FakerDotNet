using System;
using System.Collections.Generic;
using System.Linq;

namespace FakerDotNet.Tests.Helpers
{
    internal static class NumberOfTimesHelper
    {
        public static void Times(this int n, Action action)
        {
            for (var i = 0; i < n; i++) action.Invoke();
        }

        public static IEnumerable<T> Times<T>(this int n, Func<T> func)
        {
            return Enumerable.Range(0, n).Select(_ => func());
        }
    }
}
