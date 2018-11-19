using System.Collections.Generic;
using System.Net;

namespace FakerDotNet.Tests.Helpers
{
    internal static class IPRangeHelper
    {
        public static IEnumerable<string> GetRange(string startIp, string endIp)
        {
            var start = IPAddress.Parse(startIp).GetAddressBytes();
            var end = IPAddress.Parse(endIp).GetAddressBytes();

            for (var octet1 = start[0]; octet1 <= end[0]; octet1++)
            {
                for (var octet2 = start[1]; octet2 <= end[1]; octet2++)
                {
                    for (var octet3 = start[2]; octet3 <= end[2]; octet3++)
                    {
                        for (var octet4 = start[3]; octet4 <= end[3]; octet4++)
                        {
                            yield return $"{octet1}.{octet2}.{octet3}.{octet4}";
                        }
                    }
                }
            }
        }
    }
}
