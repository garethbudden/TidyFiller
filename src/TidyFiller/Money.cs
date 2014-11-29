using System;
using System.Globalization;
using System.Linq;

namespace TidyFiller
{
    public class Money
    {
        private decimal _value;
        private Currency _currency;

        public Money(double value, Currency currency)
            : this((decimal)value, currency) { }
        public Money(long value, Currency currency)
            : this((decimal)value, currency) { }
        public Money(decimal value, Currency currency)
        {
            if (currency == null) throw new ArgumentNullException("currency");

            _value = value;
            _currency = currency;
        }

        public static Money operator +(Money money1, Money money2)
        {
            if (money1 == null) throw new ArgumentNullException("money1");
            if (money2 == null) throw new ArgumentNullException("money2");

            AssertAreSameCurrency(money1, money2);

            return new Money(money1._value + money2._value, money1._currency);
        }

        public static Money operator -(Money money1, Money money2)
        {
            if (money1 == null) throw new ArgumentNullException("money1");
            if (money2 == null) throw new ArgumentNullException("money2");

            AssertAreSameCurrency(money1, money2);

            return new Money(money1._value - money2._value, money1._currency);
        }

        public static Money operator *(int multiplier, Money money)
        {
            return money * multiplier;
        }

        public static Money operator *(Money money, int multiplier)
        {
            if (money == null) throw new ArgumentNullException("money");

            return new Money(money._value * multiplier, money._currency);
        }

        public static bool operator >(Money thisMoney, Money that)
        {
            if (thisMoney == null) throw new ArgumentNullException("thisMoney");
            if (that == null) throw new ArgumentNullException("that");

            AssertAreSameCurrency(thisMoney, that);

            return thisMoney._value > that._value;
        }

        public static bool operator >=(Money thisMoney, Money that)
        {
            if (thisMoney == null) throw new ArgumentNullException("thisMoney");
            if (that == null) throw new ArgumentNullException("that");

            AssertAreSameCurrency(thisMoney, that);

            return thisMoney._value >= that._value;
        }

        public static bool operator <(Money thisMoney, Money that)
        {
            if (thisMoney == null) throw new ArgumentNullException("thisMoney");
            if (that == null) throw new ArgumentNullException("that");

            AssertAreSameCurrency(thisMoney, that);

            return thisMoney._value < that._value;
        }

        public static bool operator <=(Money thisMoney, Money that)
        {
            if (thisMoney == null) throw new ArgumentNullException("thisMoney");
            if (that == null) throw new ArgumentNullException("that");

            AssertAreSameCurrency(thisMoney, that);

            return thisMoney._value <= that._value;
        }

        public static bool operator ==(Money money1, Money money2)
        {
            if (ReferenceEquals(money1, money2))
                return true;

            if (((object)money1 == null) || ((object)money2 == null))
                return false;

            return money1._currency.Equals(money2._currency)
                && money1._value.Equals(money2._value);
        }

        public static bool operator !=(Money money1, Money money2)
        {
            return !(money1 == money2);
        }
        
        public Money AtZero
        {
            get { return new Money(0, _currency); }
        }

        public Money[] DistributeEvenly(int count, int remainderTo)
        {
            if (remainderTo < 0 || remainderTo >= count)
                throw new ArgumentOutOfRangeException("remainderTo", String.Format("remainderTo can not be less than 0 OR more than or equal to count.{0} remainderTo: {1}{0}count value {2}", 
                                                                                    Environment.NewLine, remainderTo, count));

            var monies = new Money[count];
            var value = _currency.ApplyRounding(_value / count);
            var remainder = _value - (value*count);

            for (int i = 0; i < count; i++)
            {
                if(i == remainderTo)
                    monies[i] = new Money(value+remainder, _currency);
                else
                    monies[i] = new Money(value, _currency);
            }

            return monies;
        }

        public Money NudgeRoundingUp()
        {
            return new Money(_value + _currency.GetPenny(), _currency);
        }
        
        public Money NudgeRoundingDown()
        {
            return new Money(_value - _currency.GetPenny(), _currency);
        }
        
        public bool IsWithinRoundingError(Money value)
        {
            if (value == null) throw new ArgumentNullException("value");

            return this == value
                || NudgeRoundingUp() == value
                || NudgeRoundingDown() == value;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Money))
                return false;

            return this == (Money)obj;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (_value.GetHashCode() ^ _currency.GetHashCode()) * 31;
            }
        }

        public override string ToString()
        {
            return ToString(CultureInfo.CurrentCulture);
        }

        public string ToString(CultureInfo cultureInfo)
        {
            return _currency.Format(_value, cultureInfo);
        }

        private static void AssertAreSameCurrency(Money thisMoney, Money thatMoney)
        {
            if (thisMoney._currency != thatMoney._currency)
                throw new ConflictingCurrencyException(String.Format("Can not add, {0}, and {1}, because they are different currencies", thisMoney, thatMoney));
        }
    }
}