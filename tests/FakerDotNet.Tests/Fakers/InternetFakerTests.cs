using System;
using System.Collections.Generic;
using FakeItEasy;
using FakerDotNet.Data;
using FakerDotNet.Fakers;
using NUnit.Framework;

namespace FakerDotNet.Tests.Fakers
{
    [TestFixture]
    [Parallelizable]
    public class InternetFakerTests
    {
        [SetUp]
        public void SetUp()
        {
            _fakerContainer = A.Fake<IFakerContainer>();
            _internetFaker = new InternetFaker(_fakerContainer);

            A.CallTo(() => _fakerContainer.Fake).Returns(new FakeFaker(_fakerContainer));
        }

        private IFakerContainer _fakerContainer;
        private IInternetFaker _internetFaker;

        [Test]
        public void Email_returns_an_email_address()
        {
            A.CallTo(() => _fakerContainer.Internet.Username((string) null))
                .Returns("eliza");
            A.CallTo(() => _fakerContainer.Internet.DomainName())
                .Returns("mann.net");

            Assert.AreEqual("eliza@mann.net", _internetFaker.Email());
        }

        [Test]
        public void Email_returns_an_email_address_with_the_specified_name()
        {
            A.CallTo(() => _fakerContainer.Internet.Username("Nancy"))
                .Returns("nancy");
            A.CallTo(() => _fakerContainer.Internet.DomainName())
                .Returns("terry.biz");

            Assert.AreEqual("nancy@terry.biz", _internetFaker.Email("Nancy"));
        }

        [Test]
        public void Email_returns_an_email_address_with_the_specified_separator()
        {
            var separators = new[] {"+"};

            A.CallTo(() => _fakerContainer.Internet.Username("Janelle Santiago", separators))
                .Returns("janelle+santiago");
            A.CallTo(() => _fakerContainer.Internet.DomainName())
                .Returns("becker.com");

            Assert.AreEqual("janelle+santiago@becker.com", _internetFaker.Email("Janelle Santiago", separators));
        }

        [Test]
        public void FreeEmail_returns_an_email_address()
        {
            A.CallTo(() => _fakerContainer.Internet.Username((string) null))
                .Returns("freddy");
            A.CallTo(() => _fakerContainer.Random.Element(InternetData.FreeEmails))
                .Returns("gmail.com");

            Assert.AreEqual("freddy@gmail.com", _internetFaker.FreeEmail());
        }

        [Test]
        public void FreeEmail_returns_an_email_address_with_the_specified_name()
        {
            A.CallTo(() => _fakerContainer.Internet.Username("Nancy"))
                .Returns("nancy");
            A.CallTo(() => _fakerContainer.Random.Element(InternetData.FreeEmails))
                .Returns("yahoo.com");

            Assert.AreEqual("nancy@yahoo.com", _internetFaker.FreeEmail("Nancy"));
        }

        [Test]
        public void SafeEmail_returns_an_email_address()
        {
            A.CallTo(() => _fakerContainer.Internet.Username((string) null))
                .Returns("christelle");
            A.CallTo(() => _fakerContainer.Random.Element(InternetData.SafeDomainSuffixes))
                .Returns("org");

            Assert.AreEqual("christelle@example.org", _internetFaker.SafeEmail());
        }

        [Test]
        public void SafeEmail_returns_an_email_address_with_the_specified_name()
        {
            A.CallTo(() => _fakerContainer.Internet.Username("Nancy"))
                .Returns("nancy");
            A.CallTo(() => _fakerContainer.Random.Element(InternetData.SafeDomainSuffixes))
                .Returns("net");

            Assert.AreEqual("nancy@example.net", _internetFaker.SafeEmail("Nancy"));
        }

        [Test]
        public void Username_returns_a_username()
        {
            A.CallTo(() => _fakerContainer.Random.Element(InternetData.UsernameFormats))
                .Returns("{Name.FirstName}");
            A.CallTo(() => _fakerContainer.Name.FirstName())
                .Returns("alexie");

            Assert.AreEqual("alexie", _internetFaker.Username());
        }

        [Test]
        public void Username_returns_a_username_with_the_specified_name()
        {
            Assert.AreEqual("nancy", _internetFaker.Username("Nancy"));
        }

        [Test]
        public void Username_returns_a_username_with_the_specified_separator()
        {
            var separators = new[] {".", "_", "-"};

            A.CallTo(() => _fakerContainer.Random.Element(separators))
                .Returns("-");
            A.CallTo(() => _fakerContainer.Random.Assortment(
                    A<IEnumerable<string>>.That.IsSameSequenceAs("Nancy", "Johnson"), 2))
                .Returns(new[] {"Johnson", "Nancy"});

            Assert.AreEqual("johnson-nancy", _internetFaker.Username("Nancy Johnson", separators));
        }

        [Test]
        public void Username_returns_a_username_with_length_in_specified_range()
        {
            A.CallTo(() => _fakerContainer.Random.Element(InternetData.UsernameFormats))
                .Returns("{Name.FirstName}");
            A.CallTo(() => _fakerContainer.Name.FirstName())
                .ReturnsNextFromSequence("amy", "brad", "nancy");

            Assert.AreEqual("nancy", _internetFaker.Username(new Range<int>(5, 8)));
        }

        [Test]
        public void Username_when_range_with_min_length_that_is_too_large_throws_ArgumentError()
        {
            var range = new Range<int>(10_000_000, 10_000_000);

            var ex = Assert.Throws<ArgumentException>(() => _internetFaker.Username(range));

            Assert.That(ex.Message.StartsWith("Given argument is too large"));
        }

        [Test]
        public void Username_returns_an_empty_username_if_range_with_min_length_is_less_than_zero()
        {
            var range = new Range<int>(-5, 5);

            A.CallTo(() => _fakerContainer.Random.Element(InternetData.UsernameFormats))
                .Returns("{Name.FirstName}");
            A.CallTo(() => _fakerContainer.Name.FirstName())
                .Returns("nancy");

            Assert.AreEqual("", _internetFaker.Username(range));
        }

        [Test]
        public void Username_returns_a_username_with_length_greater_or_equal_to_the_min_length()
        {
            A.CallTo(() => _fakerContainer.Random.Element(InternetData.UsernameFormats))
                .Returns("{Name.FirstName}");
            A.CallTo(() => _fakerContainer.Name.FirstName())
                .ReturnsNextFromSequence("nancy", "alexie", "johnathon");

            Assert.AreEqual("johnathon", _internetFaker.Username(8));
        }

        [Test]
        public void Username_returns_an_empty_username_if_min_length_is_less_than_zero()
        {
            A.CallTo(() => _fakerContainer.Random.Element(InternetData.UsernameFormats))
                .Returns("{Name.FirstName}");
            A.CallTo(() => _fakerContainer.Name.FirstName())
                .Returns("nancy");

            Assert.AreEqual("", _internetFaker.Username(-5));
        }

        [Test]
        public void Username_with_min_length_that_is_too_large_throws_ArgumentError()
        {
            var ex = Assert.Throws<ArgumentException>(() => _internetFaker.Username(10_000_000));

            Assert.That(ex.Message.StartsWith("Given argument is too large"));
        }

        [Test]
        public void Password_returns_a_password()
        {
            A.CallTo(() => _fakerContainer.Lorem.Characters(8))
                .Returns("vg5msvy1");
            A.CallTo(() => _fakerContainer.Number.Between(0, 8))
                .Returns(5);
            A.CallTo(() => _fakerContainer.Lorem.Characters(5))
                .Returns("uerg7");
            
            Assert.AreEqual("Vg5mSvY1UeRg7", _internetFaker.Password());
        }

        [Test]
        public void Password_returns_a_password_with_length_greater_or_equal_to_the_min_length()
        {
            A.CallTo(() => _fakerContainer.Lorem.Characters(8))
                .Returns("yfgjik0h");
            A.CallTo(() => _fakerContainer.Number.Between(0, 8))
                .Returns(6);
            A.CallTo(() => _fakerContainer.Lorem.Characters(6))
                .Returns("gzdqs0");
            
            Assert.AreEqual("YfGjIk0hGzDqS0", _internetFaker.Password(8));
        }

        [Test]
        public void Password_returns_a_password_with_length_inclusively_between_min_and_max_length()
        {
            A.CallTo(() => _fakerContainer.Lorem.Characters(10))
                .Returns("eoc9shwd1h");
            A.CallTo(() => _fakerContainer.Number.Between(0, 10))
                .Returns(8);
            A.CallTo(() => _fakerContainer.Lorem.Characters(8))
                .Returns("wq4vbgfw");
            
            Assert.AreEqual("EoC9ShWd1hWq4vBgFw", _internetFaker.Password(10, 20));
        }

        [Test]
        public void Password_returns_a_password_with_mixed_casing_when_specified()
        {
            A.CallTo(() => _fakerContainer.Lorem.Characters(10))
                .Returns("3k5qs15anm");
            A.CallTo(() => _fakerContainer.Number.Between(0, 10))
                .Returns(1);
            A.CallTo(() => _fakerContainer.Lorem.Characters(1))
                .Returns("g");
            
            Assert.AreEqual("3k5qS15aNmG", _internetFaker.Password(10, 20, true));
        }

        [Test]
        public void Password_returns_a_password_with_special_casing_when_specified()
        {
            A.CallTo(() => _fakerContainer.Lorem.Characters(10))
                .Returns("xxNkOnJsH4");
            A.CallTo(() => _fakerContainer.Number.Between(0, 10))
                .Returns(0);
            A.CallTo(() => _fakerContainer.Lorem.Characters(0))
                .Returns("");
            A.CallTo(() => _fakerContainer.Number.Between(1, 10))
                .Returns(2);
            A.CallTo(() => _fakerContainer.Random.Element(InternetFaker.SpecialCharacters))
                .ReturnsNextFromSequence("*", "%");
            
            Assert.AreEqual("*%NkOnJsH4", _internetFaker.Password(10, 20, true, true));
        }

        [Test]
        public void DomainName_returns_a_domain_name()
        {
            A.CallTo(() => _fakerContainer.Internet.DomainWord())
                .Returns("effertz");
            A.CallTo(() => _fakerContainer.Internet.DomainSuffix())
                .Returns("info");

            Assert.AreEqual("effertz.info", _internetFaker.DomainName());
        }

        [Test]
        public void DomainWord_returns_a_domain_word()
        {
            A.CallTo(() => _fakerContainer.Company.Name())
                .Returns("Haleyziemann Corp");

            Assert.AreEqual("haleyziemann", _internetFaker.DomainWord());
        }

        [Test]
        public void DomainSuffix_returns_a_domain_suffix()
        {
            A.CallTo(() => _fakerContainer.Random.Element(InternetData.DomainSuffixes))
                .Returns("info");

            Assert.AreEqual("info", _internetFaker.DomainSuffix());
        }

        [Test]
        public void IpV4Address_returns_an_IPv4_address()
        {
            A.CallTo(() => _fakerContainer.Number.Between(2, 254))
                .Returns(24);
            A.CallTo(() => _fakerContainer.Number.Between(0, 255))
                .ReturnsNextFromSequence(29, 18, 175);

            Assert.AreEqual("24.29.18.175", _internetFaker.IpV4Address());
        }

        [Test]
        public void PrivateIpV4Address_returns_a_private_IPv4_address()
        {
            A.CallTo(() => _fakerContainer.Internet.IpV4Address())
                .Returns("10.0.0.1");
            
            Assert.AreEqual("10.0.0.1", _internetFaker.PrivateIpV4Address());
        }

        [Test]
        public void PrivateIpV4Address_only_returns_private_IPv4_addresses()
        {
            A.CallTo(() => _fakerContainer.Internet.IpV4Address())
                .ReturnsNextFromSequence("24.29.18.175", "11.21.45.211", "10.1.2.3");

            Assert.AreEqual("10.1.2.3", _internetFaker.PrivateIpV4Address());
        }

        [Test]
        public void PublicIpV4Address_returns_a_public_IPv4_address()
        {
            A.CallTo(() => _fakerContainer.Internet.IpV4Address())
                .Returns("24.29.18.175");
            
            Assert.AreEqual("24.29.18.175", _internetFaker.PublicIpV4Address());
        }

        [Test]
        public void PublicIpV4Address_only_returns_public_IPv4_addresses()
        {
            A.CallTo(() => _fakerContainer.Internet.IpV4Address())
                .ReturnsNextFromSequence("10.1.2.3", "192.0.0.1", "172.16.1.20", "24.29.18.175");
            
            Assert.AreEqual("24.29.18.175", _internetFaker.PublicIpV4Address());
        }

        [Test]
        public void IpV4Cidr_returns_an_IPv4_CIDR_range()
        {
            A.CallTo(() => _fakerContainer.Internet.IpV4Address())
                .Returns("24.29.18.175");
            A.CallTo(() => _fakerContainer.Number.Between(1, 31))
                .Returns(21);

            Assert.AreEqual("24.29.18.175/21", _internetFaker.IpV4Cidr());
        }

        [Test]
        public void IpV6Address_returns_an_IPv6_address()
        {
            A.CallTo(() => _fakerContainer.Number.Between(0, 65_536))
                .ReturnsNextFromSequence(0xac5f, 0xd696, 0x3807, 0x1d72, 0x2eb5, 0x4e81, 0x7d2b, 0xe1df);
            
            Assert.AreEqual("ac5f:d696:3807:1d72:2eb5:4e81:7d2b:e1df", _internetFaker.IpV6Address());
        }

        [Test]
        public void IpV6Cidr_returns_an_IPv6_CIDR_range()
        {
            A.CallTo(() => _fakerContainer.Internet.IpV6Address())
                .Returns("ac5f:d696:3807:1d72:2eb5:4e81:7d2b:e1df");
            A.CallTo(() => _fakerContainer.Number.Between(1, 127))
                .Returns(78);
            
            Assert.AreEqual("ac5f:d696:3807:1d72:2eb5:4e81:7d2b:e1df/78", _internetFaker.IpV6Cidr());
        }

        [Test]
        public void MacAddress_returns_a_mac_address()
        {
            A.CallTo(() => _fakerContainer.Number.Between(0, 255))
                .ReturnsNextFromSequence(0xe6, 0x0d, 0x00, 0x11, 0xed, 0x4f);
            
            Assert.AreEqual("e6:0d:00:11:ed:4f", _internetFaker.MacAddress());
        }

        [Test]
        public void MacAddress_returns_a_mac_address_with_the_specified_prefix()
        {
            A.CallTo(() => _fakerContainer.Number.Between(0, 255))
                .ReturnsNextFromSequence(0x02, 0x1d, 0x9b);
            
            Assert.AreEqual("55:44:33:02:1d:9b", _internetFaker.MacAddress("55:44:33"));
        }

        [Test]
        public void Url_returns_a_url()
        {
            A.CallTo(() => _fakerContainer.Internet.DomainName())
                .Returns("thiel.com");
            A.CallTo(() => _fakerContainer.Internet.Username((string) null))
                .Returns("chauncey_simonis");
            
            Assert.AreEqual("http://thiel.com/chauncey_simonis", _internetFaker.Url());
        }

        [Test]
        public void Url_returns_a_url_with_the_specified_host()
        {
            A.CallTo(() => _fakerContainer.Internet.Username((string) null))
                .Returns("clotilde.swift");
            
            Assert.AreEqual("http://example.com/clotilde.swift", _internetFaker.Url("example.com"));
        }

        [Test]
        public void Url_returns_a_url_with_the_specified_path()
        {
            Assert.AreEqual("http://example.com/foobar.html", _internetFaker.Url("example.com", "/foobar.html"));
        }

        [Test]
        public void Url_returns_a_url_with_the_specified_scheme()
        {
            Assert.AreEqual("git://example.com/foobar.git", _internetFaker.Url("example.com", "/foobar.git", "git"));
        }

        [Test]
        public void Slug_returns_a_slugged_string()
        {
            A.CallTo(() => _fakerContainer.Lorem.Words(2, false))
                .Returns(new[] {"Pariatur", "Laudantium"});
            A.CallTo(() => _fakerContainer.Random.Element(InternetFaker.DefaultGlues))
                .Returns("_");

            Assert.AreEqual("pariatur_laudantium", _internetFaker.Slug());
        }

        [Test]
        public void Slug_returns_a_slugged_string_with_the_specified_words()
        {
            A.CallTo(() => _fakerContainer.Random.Element(InternetFaker.DefaultGlues))
                .Returns(".");

            Assert.AreEqual("foo.bar", _internetFaker.Slug("foo bar"));
        }

        [Test]
        public void Slug_returns_a_slugged_string_with_the_specified_glue()
        {
            Assert.AreEqual("foo-bar", _internetFaker.Slug("foo bar", "-"));
        }

        [Test]
        public void UserAgent_returns_a_user_agent()
        {
            const string vendor = "firefox";
            const string userAgent =
                "Mozilla/5.0 (compatible; MSIE 9.0; AOL 9.7; AOLBuild 4343.19; Windows NT 6.1; WOW64; Trident/5.0; FunWebProducts)";
            
            A.CallTo(() => _fakerContainer.Random.Element(InternetData.UserAgents.Keys))
                .Returns(vendor);
            A.CallTo(() => _fakerContainer.Random.Element(InternetData.UserAgents["firefox"]))
                .Returns(userAgent);
            
            Assert.AreEqual(userAgent, _internetFaker.UserAgent());
        }

        [Test]
        public void UserAgent_returns_a_user_agent_for_the_specified_vendor()
        {
            const string userAgent =
                "Mozilla/5.0 (compatible; MSIE 9.0; AOL 9.7; AOLBuild 4343.19; Windows NT 6.1; WOW64; Trident/5.0; FunWebProducts)";
            
            A.CallTo(() => _fakerContainer.Random.Element(InternetData.UserAgents[UserAgent.Firefox]))
                .Returns(userAgent);
            
            Assert.AreEqual(userAgent, _internetFaker.UserAgent(UserAgent.Firefox));
        }
    }
}
