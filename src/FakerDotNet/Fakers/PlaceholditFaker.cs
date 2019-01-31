using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace FakerDotNet.Fakers
{
    public interface IPlaceholditFaker
    {
        string Image(
            string size = "300x300",
            string format = "png",
            string backgroundColor = "",
            string textColor = "",
            string text = ""
        );
    }

    internal class PlaceholditFaker : IPlaceholditFaker
    {
        internal static readonly IEnumerable<string> SupportedFormats = new[]
        {
            "png",
            "jpg",
            "gif",
            "jpeg"
        };
        
        private readonly IFakerContainer _fakerContainer;

        public PlaceholditFaker(IFakerContainer fakerContainer)
        {
            _fakerContainer = fakerContainer;
        }

        public string Image(
            string size = "300x300",
            string format = "png",
            string backgroundColor = "",
            string textColor = "",
            string text = ""
        )
        {
            backgroundColor = backgroundColor == RandomColor.Value ? GenerateColor() : backgroundColor;
            textColor = textColor == RandomColor.Value ? GenerateColor() : textColor;

            if (!IsValidSize(size))
                throw new ArgumentException("Size should be specified in format 300x300", nameof(size));

            if (!IsSupportedFormat(format))
                throw new ArgumentException($"Supported formats are {string.Join(", ", SupportedFormats)}", nameof(format));

            if (!IsValidColor(backgroundColor))
                throw new ArgumentException("backgroundColor must be a hex value without '#'", nameof(backgroundColor));
            
            if (!IsValidColor(textColor))
                throw new ArgumentException("textColor must be a hex value without '#'", nameof(textColor));

            return string.Join("",
                "https://placehold.it",
                $"/{size}.{format}",
                string.IsNullOrEmpty(backgroundColor) ? "" : $"/{backgroundColor}",
                string.IsNullOrEmpty(textColor) ? "" : $"/{textColor}",
                string.IsNullOrEmpty(text) ? "" : $"?text={text}"
            );
        }

        private string GenerateColor()
        {
            return _fakerContainer.Color.HexColor().Substring(1);
        }

        private static bool IsValidSize(string size)
        {
            return Regex.IsMatch(size, "^[0-9]+x[0-9]+$");
        }

        private static bool IsSupportedFormat(string format)
        {
            return SupportedFormats.Contains(format);
        }

        private static bool IsValidColor(string color)
        {
            return string.IsNullOrEmpty(color) ||
                   Regex.IsMatch(color, @"^(?:[0-9a-f]{3}$)|(?:[0-9a-f]{6}$)$", RegexOptions.IgnoreCase);
        }
    }
}
        
