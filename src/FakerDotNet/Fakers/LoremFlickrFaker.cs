using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace FakerDotNet.Fakers
{
    public interface ILoremFlickrFaker
    {
        string Image(
            string size = "300x300",
            string[] searchTerms = null,
            bool matchAll = false);

        string GrayscaleImage(
            string size = "300x300",
            string[] searchTerms = null,
            bool matchAll = false);

        string PixelatedImage(
            string size = "300x300",
            string[] searchTerms = null,
            bool matchAll = false);

        string ColorizedImage(
            string size = "300x300",
            string color = "red",
            string[] searchTerms = null,
            bool matchAll = false);
    }

    internal class LoremFlickrFaker : ILoremFlickrFaker
    {
        private readonly IFakerContainer _fakerContainer;

        public LoremFlickrFaker(IFakerContainer fakerContainer)
        {
            _fakerContainer = fakerContainer;
        }

        public string Image(string size = "300x300", string[] searchTerms = null, bool matchAll = false)
        {
            return BuildUrl(size, null, searchTerms, matchAll);
        }

        public string GrayscaleImage(string size = "300x300", string[] searchTerms = null, bool matchAll = false)
        {
            return BuildUrl(size, "g", searchTerms, matchAll);
        }

        public string PixelatedImage(string size = "300x300", string[] searchTerms = null, bool matchAll = false)
        {
            return BuildUrl(size, "p", searchTerms, matchAll);
        }

        public string ColorizedImage(string size = "300x300", string color = "red", string[] searchTerms = null,
            bool matchAll = false)
        {
            return BuildUrl(size, color, searchTerms, matchAll);
        }

        private static string BuildUrl(string size, string format, string[] searchTerms, bool matchAll)
        {
            if (!IsValidSize(size))
                throw new ArgumentException("Size should be specified in format 300x300", nameof(size));

            return string.Join("/", new[]
            {
                "https://loremflickr.com",
                format,
                string.Join("/", size.Split('x')),
                string.Join(",", searchTerms ?? new string[] { }),
                matchAll ? "all" : null
            }.Where(x => !string.IsNullOrEmpty(x)));
        }

        private static bool IsValidSize(string size)
        {
            return Regex.IsMatch(size, "^[0-9]+x[0-9]+$");
        }
    }
}
