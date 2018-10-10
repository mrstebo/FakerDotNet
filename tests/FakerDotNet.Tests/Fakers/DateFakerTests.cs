using System;
using FakerDotNet.Fakers;
using FakerDotNet.Tests.Helpers;
using FakerDotNet.Wrappers;
using NUnit.Framework;

namespace FakerDotNet.Tests.Fakers
{
    [TestFixture]
    [Parallelizable]
    public class DateFakerTests
    {
        [SetUp]
        public void SetUp()
        {
            _randomWrapper = new RandomWrapper();
            _dateFaker = new DateFaker(_randomWrapper);
        }

        private IRandomWrapper _randomWrapper;
        private IDateFaker _dateFaker;

        [Test]
        public void Between_handles_string_dates()
        {
            100.Times(() =>
            {
                var result = DateTime.MinValue;

                Assert.DoesNotThrow(() => result = _dateFaker.Between("2017-01-01", "2017-01-10"));

                Assert.GreaterOrEqual(result, new DateTime(2017, 1, 1));
                Assert.LessOrEqual(result, new DateTime(2017, 1, 10));
            });
        }

        [Test]
        public void Between_returns_a_date_between_two_dates()
        {
            100.Times(() =>
            {
                var from = new DateTime(2017, 1, 1);
                var to = new DateTime(2017, 1, 10);

                var result = _dateFaker.Between(from, to);

                Assert.GreaterOrEqual(result, from);
                Assert.LessOrEqual(result, to);
            });
        }

        [Test]
        public void Between_returns_a_date_with_no_time()
        {
            var from = new DateTime(2017, 1, 1);
            var to = new DateTime(2017, 1, 10);

            var result = _dateFaker.Between(from, to);

            Assert.AreEqual(0, result.Hour);
            Assert.AreEqual(0, result.Minute);
            Assert.AreEqual(0, result.Second);
            Assert.AreEqual(0, result.Millisecond);
        }

        [Test]
        public void BetweenExcept_handles_string_dates()
        {
            100.Times(() =>
            {
                var result = DateTime.MinValue;

                Assert.DoesNotThrow(() => result = _dateFaker.BetweenExcept("2017-01-01", "2017-01-10", "2017-01-02"));

                Assert.GreaterOrEqual(result, new DateTime(2017, 1, 1));
                Assert.LessOrEqual(result, new DateTime(2017, 1, 10));
                Assert.AreNotEqual(new DateTime(2017, 1, 2), result);
            });
        }

        [Test]
        public void BetweenExcept_returns_a_date_between_two_dates_except_for_the_excepted_date()
        {
            100.Times(() =>
            {
                var from = new DateTime(2017, 1, 1);
                var to = new DateTime(2017, 1, 10);
                var except = new DateTime(2017, 1, 2);

                var result = _dateFaker.BetweenExcept(from, to, except);

                Assert.GreaterOrEqual(result, from);
                Assert.LessOrEqual(result, to);
                Assert.AreNotEqual(except, result);
            });
        }
        
        [Test]
        public void BetweenExcept_returns_a_date_with_no_time()
        {
            var from = new DateTime(2017, 1, 1);
            var to = new DateTime(2017, 1, 10);
            var except = new DateTime(2017, 1, 2);

            var result = _dateFaker.BetweenExcept(from, to, except);

            Assert.AreEqual(0, result.Hour);
            Assert.AreEqual(0, result.Minute);
            Assert.AreEqual(0, result.Second);
            Assert.AreEqual(0, result.Millisecond);
        }

        [Test]
        public void BetweenExcept_throws_ArgumentException_if_from_to_and_except_are_equal()
        {
            var from = new DateTime(2017, 1, 1);
            var to = new DateTime(2017, 1, 1);
            var except = new DateTime(2017, 1, 1);

            var ex = Assert.Throws<ArgumentException>(() => _dateFaker.BetweenExcept(from, to, except));

            Assert.AreEqual("From date, to date and excepted date must not be the same", ex.Message);
        }

        [Test]
        public void Forward_returns_a_date_in_the_future()
        {
            100.Times(() =>
            {
                var from = DateTime.UtcNow.Date;
                var to = DateTime.UtcNow.AddDays(365).Date;
                
                var result = _dateFaker.Forward();

                Assert.Greater(result, from);
                Assert.LessOrEqual(result, to);
            });
        }

        [Test]
        [TestCase(5)]
        [TestCase(10)]
        [TestCase(500)]
        [TestCase(1042)]
        public void Forward_returns_a_date_no_greater_than_the_specified_number_of_days(int days)
        {
            100.Times(() =>
            {
                var from = DateTime.UtcNow.Date;
                var to = DateTime.UtcNow.AddDays(days).Date;
                
                var result = _dateFaker.Forward(days);

                Assert.Greater(result, from);
                Assert.LessOrEqual(result, to);
            });
        }
        
        [Test]
        public void Forward_returns_a_date_with_no_time()
        {    
            var result = _dateFaker.Forward();

            Assert.AreEqual(0, result.Hour);
            Assert.AreEqual(0, result.Minute);
            Assert.AreEqual(0, result.Second);
            Assert.AreEqual(0, result.Millisecond);
        }

        [Test]
        public void Backward_returns_a_date_in_the_past()
        {
            100.Times(() =>
            {
                var from = DateTime.UtcNow.AddDays(-365).Date;
                var to = DateTime.UtcNow.Date;
                
                var result = _dateFaker.Backward();

                Assert.GreaterOrEqual(result, from);
                Assert.Less(result, to);
            });
        }

        [Test]
        [TestCase(5)]
        [TestCase(10)]
        [TestCase(500)]
        [TestCase(1042)]
        public void Backward_returns_a_date_no_less_than_the_specified_number_of_days(int days)
        {
            100.Times(() =>
            {
                var from = DateTime.UtcNow.AddDays(-days).Date;
                var to = DateTime.UtcNow.Date;
                
                var result = _dateFaker.Backward(days);

                Assert.GreaterOrEqual(result, from);
                Assert.Less(result, to);
            });
        }
        
        [Test]
        public void Backward_returns_a_date_with_no_time()
        {    
            var result = _dateFaker.Backward();

            Assert.AreEqual(0, result.Hour);
            Assert.AreEqual(0, result.Minute);
            Assert.AreEqual(0, result.Second);
            Assert.AreEqual(0, result.Millisecond);
        }

        [Test]
        public void Birthday_returns_a_date_between_two_ages()
        {
            100.Times(() =>
            {
                var now = DateTime.UtcNow;
                var from = new DateTime(now.Year - 65);
                var to = new DateTime(now.Year - 18);
                
                var result = _dateFaker.Birthday();

                Assert.GreaterOrEqual(result, from);
                Assert.LessOrEqual(result, to);
            });
        }

        [Test]
        [TestCase(5, 10)]
        [TestCase(24, 32)]
        [TestCase(100, 102)]
        public void Birthday_returns_a_date_between_two_specified_ages(int minAge, int maxAge)
        {
            100.Times(() =>
            {
                var now = DateTime.UtcNow;
                var from = new DateTime(now.Year - maxAge);
                var to = new DateTime(now.Year - minAge);
                
                var result = _dateFaker.Birthday(minAge, maxAge);

                Assert.GreaterOrEqual(result, from);
                Assert.LessOrEqual(result, to);
            });
        }
        
        [Test]
        public void Birthday_returns_a_date_with_no_time()
        {    
            var result = _dateFaker.Birthday();

            Assert.AreEqual(0, result.Hour);
            Assert.AreEqual(0, result.Minute);
            Assert.AreEqual(0, result.Second);
            Assert.AreEqual(0, result.Millisecond);
        }
    }
}
