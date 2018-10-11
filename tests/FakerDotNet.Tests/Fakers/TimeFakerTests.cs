using System;
using System.Linq;
using FakerDotNet.Fakers;
using FakerDotNet.Tests.Helpers;
using FakerDotNet.Wrappers;
using NUnit.Framework;

namespace FakerDotNet.Tests.Fakers
{
    [TestFixture]
    [Parallelizable]
    public class TimeFakerTests
    {
        [SetUp]
        public void SetUp()
        {
            _randomWrapper = new RandomWrapper();
            _timeFaker = new TimeFaker(_randomWrapper);
        }

        private IRandomWrapper _randomWrapper;
        private ITimeFaker _timeFaker;
        
        [Test]
        public void Between_handles_string_dates()
        {
            100.Times(() =>
            {
                var result = DateTime.MinValue;

                Assert.DoesNotThrow(() => result = _timeFaker.Between("2017-01-01", "2017-01-10"));

                Assert.GreaterOrEqual(result, new DateTime(2017, 1, 1));
                Assert.LessOrEqual(result, new DateTime(2017, 1, 10));
            });
        }

        [Test]
        public void Between_returns_a_date_time_between_two_dates()
        {
            100.Times(() =>
            {
                var from = new DateTime(2017, 1, 1);
                var to = new DateTime(2017, 1, 10);

                var result = _timeFaker.Between(from, to);

                Assert.GreaterOrEqual(result, from);
                Assert.LessOrEqual(result, to);
            });
        }

        [Test]
        public void Between_returns_a_date_time_with_time()
        {
            var from = new DateTime(2017, 1, 1);
            var to = new DateTime(2017, 1, 10);

            var result = _timeFaker.Between(from, to);

            Assert.That(new[] { result.Hour, result.Minute, result.Second, result.Millisecond}.Sum() > 0);
        }

        [Test]
        [TestCase(TimePeriod.All, 0, 23)]
        [TestCase(TimePeriod.Day, 9, 17)]
        [TestCase(TimePeriod.Night, 18, 23)]
        [TestCase(TimePeriod.Morning, 6, 11)]
        [TestCase(TimePeriod.Afternoon, 12, 17)]
        [TestCase(TimePeriod.Evening, 17, 21)]
        [TestCase(TimePeriod.Midnight, 0, 4)]
        [TestCase(TimePeriod.Between, 0, 23)]
        public void Between_returns_time_in_specified_period(TimePeriod timePeriod, int minHour, int maxHour)
        {
            100.Times(() =>
            {
                var from = new DateTime(2017, 1, 1);
                var to = new DateTime(2017, 1, 10);

                var result = _timeFaker.Between(from, to, timePeriod);

                Assert.GreaterOrEqual(result.Hour, minHour);
                Assert.LessOrEqual(result.Hour, maxHour);
            });
        }

        [Test]
        public void Between_returns_only_date_when_period_is_between()
        {
            100.Times(() =>
            {
                var from = new DateTime(2017, 1, 1);
                var to = new DateTime(2017, 1, 10);

                var result = _timeFaker.Between(from, to, TimePeriod.Between);

                Assert.AreEqual(0, result.Hour);
                Assert.AreEqual(0, result.Minute);
                Assert.AreEqual(0, result.Second);
                Assert.AreEqual(0, result.Millisecond);
            });
        }

        [Test]
        public void Forward_returns_a_date_time_in_the_future()
        {
            100.Times(() =>
            {
                var from = DateTime.UtcNow.Date;
                var to = DateTime.UtcNow.AddDays(365).Date;
                
                var result = _timeFaker.Forward();

                Assert.Greater(result, from);
                Assert.LessOrEqual(result, to);
            });
        }

        [Test]
        [TestCase(5)]
        [TestCase(10)]
        [TestCase(500)]
        [TestCase(1042)]
        public void Forward_returns_a_date_time_no_greater_than_the_specified_number_of_days(int days)
        {
            100.Times(() =>
            {
                var from = DateTime.UtcNow.Date;
                var to = DateTime.UtcNow.AddDays(days).Date;
                
                var result = _timeFaker.Forward(days);

                Assert.Greater(result, from);
                Assert.LessOrEqual(result, to);
            });
        }
        
        [Test]
        public void Forward_returns_a_date_time_with_time()
        {    
            var result = _timeFaker.Forward();

            Assert.That(new[] { result.Hour, result.Minute, result.Second, result.Millisecond}.Sum() > 0);
        }

        [Test]
        [TestCase(TimePeriod.All, 0, 23)]
        [TestCase(TimePeriod.Day, 9, 17)]
        [TestCase(TimePeriod.Night, 18, 23)]
        [TestCase(TimePeriod.Morning, 6, 11)]
        [TestCase(TimePeriod.Afternoon, 12, 17)]
        [TestCase(TimePeriod.Evening, 17, 21)]
        [TestCase(TimePeriod.Midnight, 0, 4)]
        [TestCase(TimePeriod.Between, 0, 23)]
        public void Forward_returns_time_in_specified_period(TimePeriod timePeriod, int minHour, int maxHour)
        {
            100.Times(() =>
            {
                var result = _timeFaker.Forward(10, timePeriod);

                Assert.GreaterOrEqual(result.Hour, minHour);
                Assert.LessOrEqual(result.Hour, maxHour);
            });
        }

        [Test]
        public void Backward_returns_a_date_time_in_the_past()
        {
            100.Times(() =>
            {
                var from = DateTime.UtcNow.AddDays(-365).Date;
                var to = DateTime.UtcNow.Date;
                
                var result = _timeFaker.Backward();

                Assert.GreaterOrEqual(result, from);
                Assert.Less(result, to);
            });
        }

        [Test]
        [TestCase(5)]
        [TestCase(10)]
        [TestCase(500)]
        [TestCase(1042)]
        public void Backward_returns_a_date_time_no_less_than_the_specified_number_of_days(int days)
        {
            100.Times(() =>
            {
                var from = DateTime.UtcNow.AddDays(-days).Date;
                var to = DateTime.UtcNow.Date;
                
                var result = _timeFaker.Backward(days);

                Assert.GreaterOrEqual(result, from);
                Assert.Less(result, to);
            });
        }
        
        [Test]
        public void Backward_returns_a_date_time_with_time()
        {    
            var result = _timeFaker.Backward();

            Assert.That(new[] { result.Hour, result.Minute, result.Second, result.Millisecond}.Sum() > 0);
        }
        
        [Test]
        [TestCase(TimePeriod.All, 0, 23)]
        [TestCase(TimePeriod.Day, 9, 17)]
        [TestCase(TimePeriod.Night, 18, 23)]
        [TestCase(TimePeriod.Morning, 6, 11)]
        [TestCase(TimePeriod.Afternoon, 12, 17)]
        [TestCase(TimePeriod.Evening, 17, 21)]
        [TestCase(TimePeriod.Midnight, 0, 4)]
        public void Backward_returns_time_in_specified_period(TimePeriod timePeriod, int minHour, int maxHour)
        {
            100.Times(() =>
            {
                var result = _timeFaker.Backward(10, timePeriod);

                Assert.GreaterOrEqual(result.Hour, minHour);
                Assert.LessOrEqual(result.Hour, maxHour);
            });
        }
    }
}
