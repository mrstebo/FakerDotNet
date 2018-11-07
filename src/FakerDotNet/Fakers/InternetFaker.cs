using System;
using System.Linq;
using FakerDotNet.Data;

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
        string IpV4Address();
        string PrivateIpV4Address();
        string PublicIpV4Address();
        string IpV4Cidr();
        string IpV6Address();
        string IpV6Cidr();
        string MacAddress(string prefix = "");
        string Url(string host = null, string path = null, string scheme = "http");
        string Slug(string words = null, string glue = null);
        string UserAgent(string vendor = null);
    }

    internal class InternetFaker : IInternetFaker
    {
        private readonly IFakerContainer _fakerContainer;

        public InternetFaker(IFakerContainer fakerContainer)
        {
            _fakerContainer = fakerContainer;
        }

        public string Email(string name = null, params string[] separators)
        {
            return string.Join("@", 
                Username(name, separators), 
                DomainName());
        }

        public string FreeEmail(string name = null)
        {
            return string.Join("@", 
                Username(name), 
                _fakerContainer.Random.Element(InternetData.FreeEmails));
        }

        public string SafeEmail(string name = null)
        {
            return string.Join("@",
                Username(name),
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
            throw new System.NotImplementedException();
        }

        public string DomainName()
        {
            return $"{DomainWord()}.{DomainSuffix()}";
        }

        public string DomainWord()
        {
            return _fakerContainer.Company.Name().Split(' ')[0].ToLowerInvariant();
        }

        public string DomainSuffix()
        {
            return _fakerContainer.Random.Element(InternetData.DomainSuffixes);
        }

        public string IpV4Address()
        {
            return string.Join(".",
                _fakerContainer.Number.Between(2, 254),
                _fakerContainer.Number.Between(2, 254),
                _fakerContainer.Number.Between(2, 254),
                _fakerContainer.Number.Between(2, 254));
        }

        public string PrivateIpV4Address()
        {
            throw new System.NotImplementedException();
        }

        public string PublicIpV4Address()
        {
            throw new System.NotImplementedException();
        }

        public string IpV4Cidr()
        {
            return $"{IpV4Address()}/{_fakerContainer.Number.Between(1, 31)}";
        }

        public string IpV6Address()
        {
            throw new System.NotImplementedException();
        }

        public string IpV6Cidr()
        {
            throw new System.NotImplementedException();
        }

        public string MacAddress(string prefix = "")
        {
            throw new System.NotImplementedException();
        }

        public string Url(string host = null, string path = null, string scheme = "http")
        {
            throw new System.NotImplementedException();
        }

        public string Slug(string words = null, string glue = null)
        {
            throw new System.NotImplementedException();
        }

        public string UserAgent(string vendor = null)
        {
            throw new System.NotImplementedException();
        }
    }
}
