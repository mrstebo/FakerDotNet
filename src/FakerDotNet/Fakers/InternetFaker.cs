using System;
using System.Linq;
using FakerDotNet.Data;
using FakerDotNet.Extensions;
using FakerDotNet.Validators;

namespace FakerDotNet.Fakers
{
    public interface IInternetFaker
    {
        string Email(string name = null, params string[] separators);
        string FreeEmail(string name = null);
        string SafeEmail(string name = null);
        string Username(string name = null, params string[] separators);
        string Username(Range<int> range, params string[] separators);
        string Username(int minLength, params string[] separators);
        string Password(int minLength = 8, int maxLength = 16, bool mixCase = true, bool specialChars = false);
        string DomainName();
        string DomainWord();
        string DomainSuffix();
        string IPv4Address();
        string PrivateIPv4Address();
        string PublicIPv4Address();
        string IPv4Cidr();
        string IPv6Address();
        string IPv6Cidr();
        string MacAddress(string prefix = "");
        string Url(string host = null, string path = null, string scheme = "http");
        string Slug(string words = null, string glue = null);
        string UserAgent(string vendor = null);
    }

    internal class InternetFaker : IInternetFaker
    {
        public static readonly string[] DefaultGlues = {"-", ".", "_"};
        public static readonly string[] SpecialCharacters = {"!", "@", "#", "$", "%", "^", "&", "*"};

        private readonly IFakerContainer _fakerContainer;

        public InternetFaker(IFakerContainer fakerContainer)
        {
            _fakerContainer = fakerContainer;
        }

        public string Email(string name = null, params string[] separators)
        {
            return string.Join("@",
                _fakerContainer.Internet.Username(name, separators),
                _fakerContainer.Internet.DomainName());
        }

        public string FreeEmail(string name = null)
        {
            return string.Join("@",
                _fakerContainer.Internet.Username(name),
                _fakerContainer.Random.Element(InternetData.FreeEmails));
        }

        public string SafeEmail(string name = null)
        {
            return string.Join("@",
                _fakerContainer.Internet.Username(name),
                $"example.{_fakerContainer.Random.Element(InternetData.SafeDomainSuffixes)}");
        }

        public string Username(string name = null, params string[] separators)
        {
            var separator = _fakerContainer.Random.Element(separators) ?? "";
            var initialFormat = string.IsNullOrEmpty(name)
                ? _fakerContainer.Random.Element(InternetData.UsernameFormats)
                : name;
            var words = initialFormat.Split(' ');
            var sections = words.Length > 1
                ? _fakerContainer.Random.Assortment(words, words.Length)
                : words;
            var format = string.Join(separator, sections);

            return (_fakerContainer.Fake.F(format)).ToLowerInvariant();
        }

        public string Username(Range<int> range, params string[] separators)
        {
            var result = Username(range.Minimum, separators);

            return result.Length > range.Maximum
                ? result.Substring(0, range.Maximum)
                : result;
        }

        public string Username(int minLength, params string[] separators)
        {
            if (minLength > Math.Pow(10, 6))
                throw new ArgumentException("Given argument is too large", nameof(minLength));

            var result = "";

            for (var i = 0; i < 7; i++)
            {
                result = Username((string) null, separators);

                if (result.Length >= minLength) break;
            }

            return minLength > 0 ? result : "";
        }

        public string Password(int minLength = 8, int maxLength = 16, bool mixCase = true, bool specialChars = false)
        {
            var result = _fakerContainer.Lorem.Characters(minLength);
            var diffLength = maxLength - minLength;

            if (diffLength > 0)
            {
                result += _fakerContainer.Lorem
                    .Characters((int) _fakerContainer.Number.Between(0, diffLength));
            }

            result = result.ToLowerInvariant();

            if (mixCase)
            {
                result = string.Join("", result.Characters()
                    .Select((c, i) => i % 2 == 0 ? c.ToUpperInvariant() : c));
            }

            if (specialChars)
            {
                var numberOfSpecialCharacters = _fakerContainer.Number.Between(1, minLength);

                result = string.Join("", result.Characters()
                    .Select((c, i) => i < numberOfSpecialCharacters
                        ? _fakerContainer.Random.Element(SpecialCharacters)
                        : c));
            }

            return result;
        }

        public string DomainName()
        {
            return $"{_fakerContainer.Internet.DomainWord()}.{_fakerContainer.Internet.DomainSuffix()}";
        }

        public string DomainWord()
        {
            return _fakerContainer.Company.Name().Split(' ')[0].ToLowerInvariant();
        }

        public string DomainSuffix()
        {
            return _fakerContainer.Random.Element(InternetData.DomainSuffixes);
        }

        public string IPv4Address()
        {
            return string.Join(".",
                _fakerContainer.Number.Between(2, 254),
                _fakerContainer.Number.Between(0, 255),
                _fakerContainer.Number.Between(0, 255),
                _fakerContainer.Number.Between(0, 255));
        }

        public string PrivateIPv4Address()
        {
            string ip;

            do
            {
                ip = _fakerContainer.Internet.IPv4Address();
            } while (!IPv4Validator.IsPrivate(ip));

            return ip;
        }

        public string PublicIPv4Address()
        {

            string ip;

            do
            {
                ip = _fakerContainer.Internet.IPv4Address();
            } while (!IPv4Validator.IsPublic(ip));

            return ip;
        }

        public string IPv4Cidr()
        {
            return $"{_fakerContainer.Internet.IPv4Address()}/{_fakerContainer.Number.Between(1, 31)}";
        }

        public string IPv6Address()
        {
            return string.Join(":", Enumerable.Range(0, 8)
                .Select(_ => (int) _fakerContainer.Number.Between(0, 65_536))
                .Select(i => Convert.ToString(i, 16)));
        }

        public string IPv6Cidr()
        {
            return $"{_fakerContainer.Internet.IPv6Address()}/{_fakerContainer.Number.Between(1, 127)}";
        }

        public string MacAddress(string prefix = "")
        {
            var prefixDigits = prefix
                .Split(':')
                .Where(x => !string.IsNullOrEmpty(x))
                .Select(x => Convert.ToInt32(x, 16))
                .ToArray();
            var addressDigits = Enumerable
                .Range(0, 6 - prefixDigits.Length)
                .Select(_ => (int) _fakerContainer.Number.Between(0, 255))
                .ToArray();

            return string.Join(":", prefixDigits
                    .Concat(addressDigits)
                    .Select(i => $"{i:X2}"))
                .ToLowerInvariant();
        }

        public string Url(string host = null, string path = null, string scheme = "http")
        {
            host = string.IsNullOrEmpty(host)
                ? _fakerContainer.Internet.DomainName()
                : host;
            path = string.IsNullOrEmpty(path)
                ? $"/{_fakerContainer.Internet.Username()}"
                : path;

            return $"{scheme}://{host}{path}";
        }

        public string Slug(string words = null, string glue = null)
        {
            words = string.IsNullOrEmpty(words)
                ? string.Join(" ", _fakerContainer.Lorem.Words(2))
                : words;
            glue = string.IsNullOrEmpty(glue)
                ? _fakerContainer.Random.Element(DefaultGlues)
                : glue;

            return words
                .Replace(",", "")
                .Replace(".", "")
                .Replace(" ", glue)
                .ToLowerInvariant();
        }

        public string UserAgent(string vendor = null)
        {
            vendor = string.IsNullOrEmpty(vendor) || !InternetData.UserAgents.ContainsKey(vendor)
                ? _fakerContainer.Random.Element(InternetData.UserAgents.Keys)
                : vendor;

            return _fakerContainer.Random.Element(InternetData.UserAgents[vendor]);
        }
    }
}
