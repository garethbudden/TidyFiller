using System;

namespace TidyFiller
{
    public static class DateTimeBuilderExtensions
    {
        public static DateTimeBuilder January(this int day)
        {
            return January(day, DateTime.UtcNow.Year);
        }
        public static DateTimeBuilder January(this int day, int year)
        {
            return new DateTimeBuilder().Day(day).Month(1).Year(year);
        }

        public static DateTimeBuilder February(this int day)
        {
            return February(day, DateTime.UtcNow.Year);
        }
        public static DateTimeBuilder February(this int day, int year)
        {
            return new DateTimeBuilder().Day(day).Month(2).Year(year);
        }

        public static DateTimeBuilder March(this int day)
        {
            return March(day, DateTime.UtcNow.Year);
        }
        public static DateTimeBuilder March(this int day, int year)
        {
            return new DateTimeBuilder().Day(day).Month(3).Year(year);
        }

        public static DateTimeBuilder April(this int day)
        {
            return April(day, DateTime.UtcNow.Year);
        }
        public static DateTimeBuilder April(this int day, int year)
        {
            return new DateTimeBuilder().Day(day).Month(4).Year(year);
        }

        public static DateTimeBuilder May(this int day)
        {
            return May(day, DateTime.UtcNow.Year);
        }
        public static DateTimeBuilder May(this int day, int year)
        {
            return new DateTimeBuilder().Day(day).Month(5).Year(year);
        }

        public static DateTimeBuilder June(this int day)
        {
            return June(day, DateTime.UtcNow.Year);
        }
        public static DateTimeBuilder June(this int day, int year)
        {
            return new DateTimeBuilder().Day(day).Month(6).Year(year);
        }

        public static DateTimeBuilder July(this int day)
        {
            return July(day, DateTime.UtcNow.Year);
        }
        public static DateTimeBuilder July(this int day, int year)
        {
            return new DateTimeBuilder().Day(day).Month(7).Year(year);
        }

        public static DateTimeBuilder August(this int day)
        {
            return August(day, DateTime.UtcNow.Year);
        }
        public static DateTimeBuilder August(this int day, int year)
        {
            return new DateTimeBuilder().Day(day).Month(8).Year(year);
        }

        public static DateTimeBuilder September(this int day)
        {
            return September(day, DateTime.UtcNow.Year);
        }
        public static DateTimeBuilder September(this int day, int year)
        {
            return new DateTimeBuilder().Day(day).Month(9).Year(year);
        }

        public static DateTimeBuilder October(this int day)
        {
            return October(day, DateTime.UtcNow.Year);
        }
        public static DateTimeBuilder October(this int day, int year)
        {
            return new DateTimeBuilder().Day(day).Month(10).Year(year);
        }

        public static DateTimeBuilder November(this int day)
        {
            return November(day, DateTime.UtcNow.Year);
        }
        public static DateTimeBuilder November(this int day, int year)
        {
            return new DateTimeBuilder().Day(day).Month(11).Year(year);
        }

        public static DateTimeBuilder December(this int day)
        {
            return December(day, DateTime.UtcNow.Year);
        }
        public static DateTimeBuilder December(this int day, int year)
        {
            return new DateTimeBuilder().Day(day).Month(12).Year(year);
        }
    }
}