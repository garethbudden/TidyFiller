using System.Collections.Generic;
using System.Linq;

namespace TidyFiller
{
    public static class MoneyExtensions
    {
        public static Money PoundsSterling(this int value)
        {
            return PoundsSterling((decimal)value);
        }
        public static Money PoundsSterling(this float value)
        {
            return PoundsSterling((decimal)value);
        }
        public static Money PoundsSterling(this decimal value)
        {
            return new Money(value, Currency.GBP);
        }

        public static Money Euros(this int value)
        {
            return Euros((decimal)value);
        }
        public static Money Euros(this float value)
        {
            return Euros((decimal)value);
        }
        public static Money Euros(this decimal value)
        {
            return new Money(value, Currency.EUR);
        }

        public static Money USDollars(this int value)
        {
            return USDollars((decimal)value);
        }
        public static Money USDollars(this float value)
        {
            return USDollars((decimal)value);
        }
        public static Money USDollars(this decimal value)
        {
            return new Money(value, Currency.USD);
        }

        public static Money Sum(this IEnumerable<Money> monies)
        {
            // todo: this seems like a bad idea - maybe always request a currency?
            if (!monies.Any())
                return null;

            Money value = null;

            foreach (var money in monies)
            {
                if (value == null)
                {
                    value = money;
                }
                else
                {
                    value += money;
                }
            }

            return value;
        }
    }
}