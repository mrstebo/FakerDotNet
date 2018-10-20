using System.Collections.Generic;
using System.Linq;

namespace FakerDotNet.Extensions
{
    internal static class StringCharactersExtension
    {
        public static IEnumerable<string> Characters(this string text)
        {
            return $"{text}".ToCharArray().Select(c => new string(c, 1));
        }
    }
}