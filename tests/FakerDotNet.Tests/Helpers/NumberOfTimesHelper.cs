using System;

namespace FakerDotNet.Tests.Helpers
{
    internal static class NumberOfTimesHelper
    {
        public static void Times(this int n, Action action)
        {
            for (var i = 0; i < n; i++) action.Invoke();
        }
    }
}
