using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace FakerDotNet.Fakers
{
    public interface IAvatarFaker
    {
        string Image(
            string slug = null,
            string size = "300x300",
            string format = "png",
            string set = "set1",
            string bgset = null);
    }

    internal class AvatarFaker : IAvatarFaker
    {
        public static readonly IEnumerable<string> SupportedFormats = new[]
        {
            "png",
            "jpg",
            "bmp"
        };

        private readonly IFakerContainer _fakerContainer;

        public AvatarFaker(IFakerContainer fakerContainer)
        {
            _fakerContainer = fakerContainer;
        }

        public string Image(
            string slug = null,
            string size = "300x300",
            string format = "png",
            string set = "set1",
            string bgset = null)
        {
            if (IsInvalidSize(size))
                throw new ArgumentException("Size should be specified in the format 300x300", nameof(size));

            if (IsInvalidFormat(format))
                throw new ArgumentException($"Supported formats are {string.Join(", ", SupportedFormats)}");

            var parameters = string.Join("&", new[]
            {
                $"size={size}",
                string.IsNullOrEmpty(set) ? null : $"set={set}",
                string.IsNullOrEmpty(bgset) ? null : $"bgset={bgset}"
            }.Where(x => !string.IsNullOrEmpty(x)));

            slug = string.IsNullOrEmpty(slug) ? string.Join("", _fakerContainer.Lorem.Words()) : slug;

            return $"https://robohash.org/{slug}.{format}?{parameters}";
        }

        private static bool IsInvalidSize(string size)
        {
            return !Regex.IsMatch(size, @"^[0-9]+x[0-9]+$");
        }

        private static bool IsInvalidFormat(string format)
        {
            return !SupportedFormats.Any(x => string.Equals(x, format, StringComparison.OrdinalIgnoreCase));
        }
    }
}
