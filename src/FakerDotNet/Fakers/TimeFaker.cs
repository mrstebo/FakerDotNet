using System;
using System.Data;
using FakerDotNet.Wrappers;

namespace FakerDotNet.Fakers
{
    public interface ITimeFaker
    {
        DateTime Between(string from, string to, TimePeriod timePeriod = TimePeriod.All);
        DateTime Between(DateTime from, DateTime to, TimePeriod timePeriod = TimePeriod.All);
        DateTime Forward(int days = 365, TimePeriod timePeriod = TimePeriod.All);
        DateTime Backward(int days = 365, TimePeriod timePeriod = TimePeriod.All);
    }
    
    internal class TimeFaker : ITimeFaker
    {   
        private readonly IRandomWrapper _randomWrapper;

        public TimeFaker()
            : this(new RandomWrapper())
        {
        }
        
        internal TimeFaker(IRandomWrapper randomWrapper)
        {
            _randomWrapper = randomWrapper;
        }

        public DateTime Between(string from, string to, TimePeriod timePeriod = TimePeriod.All)
        {
            return Between(DateTime.Parse(from), DateTime.Parse(to), timePeriod);
        }

        public DateTime Between(DateTime from, DateTime to, TimePeriod timePeriod = TimePeriod.All)
        {
            var date = from.AddDays(_randomWrapper.Next(0, to.Subtract(from).Days));
            var range = RangeFor(timePeriod);

            return timePeriod == TimePeriod.Between
                ? date.Date
                : new DateTime(
                    date.Year,
                    date.Month,
                    date.Day,
                    _randomWrapper.Next(range.Minimum, range.Maximum),
                    _randomWrapper.Next(0, 59),
                    _randomWrapper.Next(0, 59)
                );
        }

        public DateTime Forward(int days = 365, TimePeriod timePeriod = TimePeriod.All)
        {
            var from = DateTime.UtcNow.Date.AddDays(1);
            var to = DateTime.UtcNow.Date.AddDays(days);

            return Between(from, to, timePeriod);
        }

        public DateTime Backward(int days = 365, TimePeriod timePeriod = TimePeriod.All)
        {
            var from = DateTime.UtcNow.Date.AddDays(-days);
            var to = DateTime.UtcNow.Date.AddDays(-1);

            return Between(from, to, timePeriod);
        }

        private static Range<int> RangeFor(TimePeriod timePeriod)
        {
            switch (timePeriod)
            {
                case TimePeriod.Day: 
                    return new Range<int>(9, 17);
                
                case TimePeriod.Night: 
                    return new Range<int>(18, 23);
                
                case TimePeriod.Morning: 
                    return new Range<int>(6, 11);
                
                case TimePeriod.Afternoon: 
                    return new Range<int>(12, 17);
                
                case TimePeriod.Evening: 
                    return new Range<int>(17, 21);
                
                case TimePeriod.Midnight: 
                    return new Range<int>(0, 4);
                
                default:
                    return new Range<int>(0, 23);
            }
        }
    }
}
