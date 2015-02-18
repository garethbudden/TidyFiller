using System;
using System.Globalization;

namespace TidyFiller
{
    public class Currency
    {
        private string _code;
        private int _number;
        private string _currencySymbol;
        private int _decimalPlaces  = 2;
        private decimal _pennyValue = 0.01m;

        public Currency(string code, int number, string symbol)
        {
            if (code == null) throw new ArgumentNullException("code");
            if (symbol == null) throw new ArgumentNullException("symbol");

            _code = code;
            _number = number;
            _currencySymbol = symbol;
        }

        public static readonly Currency GBP = new Currency("GBP", 826, "£");
        public static readonly Currency USD = new Currency("USD", 840, "$");
        public static readonly Currency EUR = new Currency("EUR", 978, "€");

        public static bool operator ==(Currency thisCurrency, Currency thatCurrency)
        {
            if (ReferenceEquals(thisCurrency, thatCurrency))
                return true;

            if (((object)thisCurrency == null) || ((object)thatCurrency == null))
                return false;

            return thisCurrency._code.Equals(thatCurrency._code)
                && thisCurrency._currencySymbol.Equals(thatCurrency._currencySymbol)
                && thisCurrency._number.Equals(thatCurrency._number);
        }
        public static bool operator !=(Currency thisCurrency, Currency thatCurrency)
        {
            return !(thisCurrency == thatCurrency);
        }

        public static explicit operator Currency(string code)
        {
            switch (code)
            {
                case "GBP": return Currency.GBP;
                case "USD": return Currency.USD;
                case "EUR": return Currency.EUR;
                default :
                    throw new InvalidCastException(string.Format("Unable to cast {0}, into a known currency", code));
            }
        }
        public static explicit operator Currency(int number)
        {
            switch (number)
            {
                case 826: return Currency.GBP;
                case 840: return Currency.USD;
                case 978: return Currency.EUR;
                default:
                    throw new InvalidCastException(string.Format("Unable to cast {0}, into a known currency", number));
            }
        }

        public static bool CanParse(string code)
        {
            switch (code)
            {
                case "GBP":
                case "USD":
                case "EUR": return true;
                default:
                    return false;
            }
        }

        public string Format(decimal value, CultureInfo cultureInfo)
        {
            var format = (NumberFormatInfo)cultureInfo.NumberFormat.Clone();
            format.CurrencySymbol = _currencySymbol;

            return value.ToString("C", format);
        }

        public decimal ApplyRounding(decimal value)
        {
            return Math.Round(value, _decimalPlaces, MidpointRounding.ToEven);
        }

        public decimal GetPenny()
        {
            return _pennyValue;
        }

        public override bool Equals(object obj)
        {
            var cast = obj as Currency;

            return this == cast;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (_code.GetHashCode() * 31) 
                    ^ (_number.GetHashCode() * 31) 
                    ^ (_currencySymbol.GetHashCode() * 31);
            }
        }

        public override string ToString()
        {
            return _code;
        }
    }
}