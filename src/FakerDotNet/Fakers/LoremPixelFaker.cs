using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace FakerDotNet.Fakers
{
    public interface ILoremPixelFaker
    {
        string Image(
            string size = "300x300",
            bool isGray = false,
            string category = null,
            int? number = null,
            string text = null);
    }

    internal class LoremPixelFaker : ILoremPixelFaker
    {
        internal static readonly IEnumerable<string> SupportedCategories = new[]
        {
            "abstract",
            "animals",
            "business",
            "cats",
            "city",
            "food",
            "nightlife",
            "fashion",
            "people",
            "nature",
            "sports",
            "technics",
            "transport"
        };

        private readonly IFakerContainer _fakerContainer;

        public LoremPixelFaker(IFakerContainer fakerContainer)
        {
            _fakerContainer = fakerContainer;
        }

        public string Image(
            string size = "300x300",
            bool isGray = false,
            string category = null,
            int? number = null,
            string text = null)
        {
            if (!IsValidSize(size))
                throw new ArgumentException("Size should be specified in format 300x300", nameof(size));

            if (!IsSupportedCategory(category))
                throw new ArgumentException($"Supported categories are {string.Join(", ", SupportedCategories)}",
                    nameof(category));

            if (!IsValidNumber(number))
                throw new ArgumentException("Number must be between 1 and 10", nameof(number));

            if (!IsValidCategoryNumber(category, number))
                throw new ArgumentException("Category required when number is passed", nameof(number));

            if (!IsValidCategoryText(category, text))
                throw new ArgumentException("Category and number must be passed when text is passed", nameof(text));

            return string.Join("/", new[]
            {
                "https://lorempixel.com",
                isGray ? "g" : "",
                string.Join("/", size.Split('x')),
                category,
                Convert.ToString(number),
                text
            }.Where(x => !string.IsNullOrEmpty(x)));
        }

        private static bool IsValidSize(string size)
        {
            return Regex.IsMatch(size, "^[0-9]+x[0-9]+$");
        }

        private static bool IsSupportedCategory(string category)
        {
            return string.IsNullOrEmpty(category) || SupportedCategories.Contains(category);
        }

        private static bool IsValidNumber(int? number)
        {
            var n = number.GetValueOrDefault(1);
            return n >= 1 && n <= 10;
        }

        private static bool IsValidCategoryNumber(string category, int? number)
        {
            return !number.HasValue || !string.IsNullOrEmpty(category);
        }

        private static bool IsValidCategoryText(string category, string text)
        {
            return string.IsNullOrEmpty(text) || !string.IsNullOrEmpty(category);
        }
    }
}
