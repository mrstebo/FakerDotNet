using FakeItEasy;
using FakerDotNet.Fakers;
using FakerDotNet.Wrappers;
using NUnit.Framework;

namespace FakerDotNet.Tests.Fakers
{
    [TestFixture]
    [Parallelizable]
    public class NumberFakerTests
    {
        [SetUp]
        public void SetUp()
        {
            _randomWrapper = A.Fake<IRandomWrapper>();
            _numberFaker = new NumberFaker(_randomWrapper);
        }

        private IRandomWrapper _randomWrapper;
        private INumberFaker _numberFaker;

        [Test]
        public void Number_returns_a_number_with_ten_digits_by_default()
        {
            A.CallTo(() => _randomWrapper.Next(1, 9)).Returns(1);
            A.CallTo(() => _randomWrapper.Next(0, 9)).Returns(0);
            
            Assert.AreEqual(1000000000, _numberFaker.Number());
        }

        [Test]
        [TestCase(1, 0)]
        [TestCase(2, 10)]
        [TestCase(5, 10000)]
        [TestCase(8, 10000000)]
        public void Number_with_digits_returns_number_with_specified_number_of_digits(int digits, long expected)
        {
            A.CallTo(() => _randomWrapper.Next(1, 9)).Returns(1);
            A.CallTo(() => _randomWrapper.Next(0, 9)).Returns(0);
            
            Assert.AreEqual(expected, _numberFaker.Number(digits));
        }

        [Test]
        public void Decimal_returns_number_with_five_left_digits_and_two_right_digits_by_default()
        {
            A.CallTo(() => _randomWrapper.Next(1, 9)).Returns(1);
            A.CallTo(() => _randomWrapper.Next(0, 9)).Returns(9);
            
            Assert.AreEqual(19999.19, _numberFaker.Decimal());
        }

        [Test]
        public void Decimal_with_left_digits_returns_decimal_with_specified_number_of_left_digits()
        {
            A.CallTo(() => _randomWrapper.Next(1, 9)).Returns(1);
            A.CallTo(() => _randomWrapper.Next(0, 9)).Returns(9);
            
            Assert.AreEqual(199.19, _numberFaker.Decimal(3));
        }
        
        [Test]
        public void Decimal_with_right_digits_returns_decimal_with_specified_number_of_right_digits()
        {
            A.CallTo(() => _randomWrapper.Next(1, 9)).Returns(1);
            A.CallTo(() => _randomWrapper.Next(0, 9)).Returns(9);
            
            Assert.AreEqual(19999.199999, _numberFaker.Decimal(5, 6));
        }
    }
}
