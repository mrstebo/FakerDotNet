using System.Collections.Generic;

namespace FakerDotNet.Data
{
    internal static class InternetData
    {
        public static readonly IEnumerable<string> FreeEmails = new[]
        {
            "gmail.com",
            "yahoo.com",
            "hotmail.com"
        };

        public static readonly IEnumerable<string> DomainSuffixes = new[]
        {
            "com",
            "biz",
            "info",
            "name",
            "net",
            "org",
            "io",
            "co"
        };

        public static readonly IEnumerable<string> SafeDomainSuffixes = new[]
        {
            "org",
            "com",
            "net"
        };

        public static readonly IDictionary<string, string[]> UserAgents = new Dictionary<string, string[]>
        {
            {
                "aol",
                new[]
                {
                    "Mozilla/5.0 (compatible; MSIE 9.0; AOL 9.7; AOLBuild 4343.19; Windows NT 6.1; WOW64; Trident/5.0; FunWebProducts)"
                }
            },
            {
                "chrome",
                new[]
                {
                    "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2228.0 Safari/537.36"
                }
            },
            {
                "firefox",
                new[]
                {
                    "Mozilla/5.0 (Windows NT x.y; Win64; x64; rv:10.0) Gecko/20100101 Firefox/10.0"
                }
            },
            {
                "internet_explorer",
                new[]
                {
                    "Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; AS; rv:11.0) like Gecko"
                }
            },
            {
                "netscape",
                new[]
                {
                    "Mozilla/5.0 (Windows; U; Win 9x 4.90; SG; rv:1.9.2.4) Gecko/20101104 Netscape/9.1.0285"
                }
            },
            {
                "opera",
                new[]
                {
                    "Opera/9.80 (X11; Linux i686; Ubuntu/14.10) Presto/2.12.388 Version/12.16"
                }
            },
            {
                "safari",
                new[]
                {
                    "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_9_3) AppleWebKit/537.75.14 (KHTML, like Gecko) Version/7.0.3 Safari/7046A194A"
                }
            }
        };

        public static readonly IEnumerable<string> UsernameFormats = new[]
        {
            "{Name.FirstName}",
            "{Name.FirstName} {Name.LastName}"
        };
    }
}
