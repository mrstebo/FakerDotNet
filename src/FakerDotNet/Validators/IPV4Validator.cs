using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace FakerDotNet.Validators
{
    internal static class IPV4Validator
    {
        private static readonly string[] ReservedIpPatterns =
        {
            // 0.0.0.0      - 0.255.255.255
            @"^0\.",
            // 192.0.2.0    - 192.0.2.255
            @"^192\.0\.2\.",
            // 192.88.99.0  - 192.88.99.255
            @"^192\.88\.99\.",
            // 198.51.100.0 - 198.51.100.255
            @"^198\.51\.100\.",
            // 203.0.113.0  - 203.0.113.255
            @"^203\.0\.113\.",
            // 224.0.0.0    - 239.255.255.255
            @"^(22[4-9]|23\d)\.",
            // 240.0.0.0    - 255.255.255.254  and  255.255.255.255
            @"^(24\d|25[0-5])\."
        };
        
        private static readonly string[] PrivateIpPatterns =
        {
            // 10.0.0.0    - 10.255.255.255
            @"^10\.",
            // 100.64.0.0  - 100.127.255.255
            @"^100\.(6[4-9]|[7-9]\d|1[0-1]\d|12[0-7])\.",
            // 127.0.0.0   - 127.255.255.255
            @"^127\.",
            // 169.254.0.0 - 169.254.255.255
            @"^169\.254\.",
            // 172.16.0.0  - 172.31.255.255
            @"^172\.(1[6-9]|2\d|3[0-1])\.",
            // 192.0.0.0   - 192.0.0.255
            @"^192\.0\.0\.",
            // 192.168.0.0 - 192.168.255.255
            @"^192\.168\.",
            // 198.18.0.0  - 198.19.255.255
            @"^198\.(1[8-9])\."
        };

        public static bool IsPublic(string ip)
        {
            return IsIpAddress(ip) && ReservedIpPatterns
                .Concat(PrivateIpPatterns)
                .Select(x => new Regex(x))
                .All(x => !x.IsMatch(ip));
        }

        public static bool IsPrivate(string ip)
        {
            return IsIpAddress(ip) && PrivateIpPatterns
                .Select(x => new Regex(x))
                .Any(x => x.IsMatch(ip));
        }

        private static bool IsIpAddress(string ip)
        {
            return IPAddress.TryParse(ip, out _);
        }
    }
}
