using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using FakerDotNet.Tests.Helpers;
using FakerDotNet.Validators;
using NUnit.Framework;

namespace FakerDotNet.Tests.Validators
{
    [TestFixture]
    [Parallelizable]
    public class IPv4ValidatorTests
    {
        [Test]
        [TestCase("1.0.0.1")]
        [TestCase("11.0.0.0")]
        [TestCase("24.21.233.103")]
        public void IsPublic_returns_true_for_public_ip_addresses(string ip)
        {
            Assert.IsTrue(IPv4Validator.IsPublic(ip));
        }

        [Test]
        [TestCaseSource(typeof(IPRangeData), nameof(IPRangeData.PrivateIPs))]
        public void IsPublic_returns_false_for_private_ip_addresses(string startIp, string endIp)
        {
            // Take the first and last batch...otherwise it could take a really long time
            foreach (var ip in IPRangeHelper.GetRange(startIp, endIp).Take(10))
            {
                Assert.IsFalse(IPv4Validator.IsPublic(ip), "Apparently {0} is a public IP", ip);
            }
            
            foreach (var ip in IPRangeHelper.GetRange(startIp, endIp).TakeLast(10))
            {
                Assert.IsFalse(IPv4Validator.IsPublic(ip), "Apparently {0} is a public IP", ip);
            }
        }
    }

    public class IPRangeData
    {
        public static IEnumerable PrivateIPs
        {
            get
            {
                yield return new TestCaseData("10.0.0.0", "10.255.255.255");
                yield return new TestCaseData("100.64.0.0", "100.127.255.255");
                yield return new TestCaseData("127.0.0.0", "127.255.255.255");
                yield return new TestCaseData("169.254.0.0", "169.254.255.255");
                yield return new TestCaseData("172.16.0.0", "172.31.255.255");
                yield return new TestCaseData("192.0.0.0", "192.0.0.255");
                yield return new TestCaseData("192.168.0.0", "192.168.255.255");
                yield return new TestCaseData("198.18.0.0", "198.19.255.255");
            }
        }
    }
}
