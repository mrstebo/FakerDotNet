using System;
using System.Linq;
using System.Text.RegularExpressions;
using FakerDotNet.Fakers;
using FakerDotNet.Tests.Helpers;
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
            _randomWrapper = new RandomWrapper();
            _numberFaker = new NumberFaker(_randomWrapper);
        }

        private IRandomWrapper _randomWrapper;
        private INumberFaker _numberFaker;

        [Test]
        public void Between_returns_number_between_min_and_max()
        {
            100.Times(() =>
            {
                var result = _numberFaker.Between(0, 100);

                Assert.GreaterOrEqual(result, 0);
                Assert.LessOrEqual(result, 100);
            });
        }

        [Test]
        public void Decimal_returns_number_with_five_left_digits_and_two_right_digits_by_default()
        {
            100.Times(() =>
            {
                var result = _numberFaker.Decimal();

                Assert.That(Regex.IsMatch(result, @"^\d{5}\.\d{2}$"));
            });
        }

        [Test]
        public void Decimal_with_left_digits_returns_decimal_with_specified_number_of_left_digits()
        {
            100.Times(() =>
            {
                var result = _numberFaker.Decimal(3);

                Assert.That(Regex.IsMatch(result, @"^\d{3}\.\d{2}$"));
            });
        }

        [Test]
        public void Decimal_with_right_digits_returns_decimal_with_specified_number_of_right_digits()
        {
            100.Times(() =>
            {
                var result = _numberFaker.Decimal(5, 6);

                Assert.That(Regex.IsMatch(result, @"^\d{5}\.\d{6}$"));
            });
        }

        [Test]
        public void Digit_returns_a_single_digit()
        {
            100.Times(() =>
            {
                var result = _numberFaker.Digit();

                Assert.That(Regex.IsMatch(result, @"^[0-9]$"));
            });
        }

        [Test]
        public void Hexadecimal_returns_a_hex_string_with_six_digits_by_default()
        {
            100.Times(() =>
            {
                var result = _numberFaker.Hexadecimal();

                Assert.That(Regex.IsMatch(result, @"^[a-f0-9]{6}$"));
            });
        }

        [Test]
        [TestCase(3)]
        [TestCase(5)]
        [TestCase(10)]
        [TestCase(18)]
        public void Hexadecimal_with_digits_returns_hex_string_with_number_of_digits(int digits)
        {
            100.Times(() =>
            {
                var result = _numberFaker.Hexadecimal(digits);

                Assert.That(Regex.IsMatch(result, $@"^[a-f0-9]{{{digits}}}$"));
            });
        }

        [Test]
        public void Negative_returns_negative_number()
        {
            100.Times(() =>
            {
                var result = _numberFaker.Negative();

                Assert.GreaterOrEqual(result, -5000D);
                Assert.LessOrEqual(result, -1D);
            });
        }

        [Test]
        public void NonZeroDigit_returns_a_non_zero_digit()
        {
            100.Times(() =>
            {
                var result = _numberFaker.NonZeroDigit();

                Assert.AreNotEqual("0", result);
                Assert.That(Regex.IsMatch(result, @"^[1-9]$"));
            });
        }

        [Test]
        public void Normal_returns_a_double_within_a_delta_range()
        {
            const int iterations = 10000;
            var values = iterations.Times(() => _numberFaker.Normal(150, 100)).ToArray();
            var mean = values.Sum() / iterations;
            var variance = values.Aggregate(0D, (r, v) => r + Math.Pow(v - mean, 2) / (iterations - 1));
            var standardDeviation = Math.Sqrt(variance);

            Assert.AreEqual(150, mean, 5.0);
            Assert.AreEqual(100, standardDeviation, 3.0);
        }

        [Test]
        public void Number_returns_a_number_with_ten_digits_by_default()
        {
            100.Times(() =>
            {
                var result = _numberFaker.Number();

                Assert.That(Regex.IsMatch(result, @"^[1-9]\d{9}$"), $"Result did not match: {result}");
            });
        }

        [Test]
        [TestCase(5)]
        [TestCase(20)]
        public void Number_with_multiple_digits_never_starts_with_zero(int digit)
        {
            100.Times(() =>
            {
                var result = _numberFaker.Number(digit);

                Assert.That(Regex.IsMatch(result, $@"^[1-9]\d{{{digit - 1}}}$"), $"Result did not match: {result}");
            });
        }

        [Test]
        public void Number_with_single_digit_can_be_from_zero_to_nine()
        {
            100.Times(() =>
            {
                var result = _numberFaker.Number(1);

                Assert.That(Regex.IsMatch(result, @"^[0-9]$"));
            });
        }

        [Test]
        public void Positive_returns_positive_number()
        {
            100.Times(() =>
            {
                var result = _numberFaker.Positive();

                Assert.GreaterOrEqual(result, 1D);
                Assert.LessOrEqual(result, 5000D);
            });
        }

        [Test]
        public void Within_returns_number_within_range()
        {
            100.Times(() =>
            {
                var result = _numberFaker.Within(new Range<double>(-100, 100));

                Assert.GreaterOrEqual(result, -100);
                Assert.LessOrEqual(result, 100);
            });
        }
    }
}
