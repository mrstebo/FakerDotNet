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
        public void IsPublic_returns_false_for_private_ip_addresses(string ip)
        {
            Assert.IsFalse(IPv4Validator.IsPublic(ip), "Apparently {0} is a public IP", ip);
        }
    }

    public class IPRangeData
    {
        public static IEnumerable PrivateIPs
        {
            get
            {
                yield return new TestCaseData("10.2.3.4");
                yield return new TestCaseData("100.64.1.2");
                yield return new TestCaseData("100.82.1.2");
                yield return new TestCaseData("100.127.1.2");
                yield return new TestCaseData("127.0.0.1");
                yield return new TestCaseData("127.1.2.3");
                yield return new TestCaseData("127.0.1.2");
                yield return new TestCaseData("169.254.1.2");
                yield return new TestCaseData("172.16.1.2");
                yield return new TestCaseData("172.24.1.2");
                yield return new TestCaseData("172.31.1.2");
                yield return new TestCaseData("192.0.0.1");
                yield return new TestCaseData("192.168.1.2");
                yield return new TestCaseData("198.18.1.2");
                yield return new TestCaseData("198.19.1.2");
            }
        }
    }
}
