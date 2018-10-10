using System;
using FakerDotNet.Wrappers;

namespace FakerDotNet.Fakers
{
    public interface IDateFaker
    {
        DateTime Between(string from, string to);
        DateTime Between(DateTime from, DateTime to);
        DateTime BetweenExcept(string from, string to, string except);
        DateTime BetweenExcept(DateTime from, DateTime to, DateTime except);
        DateTime Forward(int days = 365);
        DateTime Backward(int days = 365);
        DateTime Birthday(int minAge = 18, int maxAge = 65);
    }
    
    internal class DateFaker : IDateFaker
    {
        private readonly IRandomWrapper _randomWrapper;

        public DateFaker()
            : this(new RandomWrapper())
        {
        }

        internal DateFaker(IRandomWrapper randomWrapper)
        {
            _randomWrapper = randomWrapper;
        }
        
        public DateTime Between(string from, string to)
        {
            return Between(DateTime.Parse(from), DateTime.Parse(to));
        }

        public DateTime Between(DateTime from, DateTime to)
        {
            return from.AddDays(_randomWrapper.Next(0, to.Subtract(from).Days));
        }

        public DateTime BetweenExcept(string from, string to, string except)
        {
            return BetweenExcept(DateTime.Parse(from), DateTime.Parse(to), DateTime.Parse(except));
        }

        public DateTime BetweenExcept(DateTime from, DateTime to, DateTime except)
        {
            if (from.Equals(to) && to.Equals(except))
                throw new ArgumentException("From date, to date and excepted date must not be the same");
            
            DateTime result;
            
            do
            {
                result = from.Date.AddDays(_randomWrapper.Next(0, to.Subtract(from).Days));
            } while (result.Equals(except.Date));

            return result;
        }

        public DateTime Forward(int days = 365)
        {
            var from = DateTime.UtcNow.Date.AddDays(1);
            var to = DateTime.UtcNow.Date.AddDays(days);

            return Between(from, to);
        }

        public DateTime Backward(int days = 365)
        {
            var from = DateTime.UtcNow.Date.AddDays(-days);
            var to = DateTime.UtcNow.Date.AddDays(-1);

            return Between(from, to);
        }

        public DateTime Birthday(int minAge = 18, int maxAge = 65)
        {
            var now = DateTime.UtcNow;
            var from = new DateTime(now.Year - maxAge);
            var to = new DateTime(now.Year - minAge);

            return Between(from, to);
        }
    }
}
