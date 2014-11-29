using System;

namespace TidyFiller
{
    public class DateTimeBuilder
    {
        private int _day = 1;
        private int _month = 1;
        private int _year = 1;
        private int _hours;
        private int _minutes;
        private int _seconds;
        private int _milliseconds;

        public static implicit operator DateTime (DateTimeBuilder builder)
        {
            return builder.Build();
        }

        public DateTimeBuilder Day(int day)
        {
            _day = day;
            return this;
        }
        public DateTimeBuilder Month(int month)
        {
            _month = month;
            return this;
        }
        public DateTimeBuilder Year(int year)
        {
            _year = year;
            return this;
        }

        public DateTimeBuilder Date(int day, int month, int year)
        {
            _day = day;
            _month = month;
            _year = year;
            return this;
        }

        public DateTimeBuilder At(int hours, int minutes)
        {
            return At(hours, minutes, 0);
        }
        public DateTimeBuilder At(int hours, int minutes, int seconds)
        {
            return At(hours, minutes, seconds, 0);
        }
        public DateTimeBuilder At(int hours, int minutes, int seconds, int milliseconds)
        {
            _hours = hours;
            _minutes = minutes;
            _seconds = seconds;
            _milliseconds = milliseconds;
            return this;
        }

        public DateTimeBuilder JustBeforeMidnight()
        {
            _hours = 23;
            _minutes = 59;
            _seconds = 59;
            _milliseconds = 999;

            return this;
        }

        public DateTimeBuilder AtStartOfDay()
        {
            _hours = 0;
            _minutes = 0;
            _seconds = 0;
            _milliseconds = 0;
            return this;
        }

        public DateTime Build()
        {
            return new DateTime(_year, _month, _day, _hours, _minutes, _seconds, _milliseconds);
        }
    }
}
