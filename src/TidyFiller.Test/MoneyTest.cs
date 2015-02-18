using NUnit.Framework;
using System;

namespace TidyFiller.Test
{
    [TestFixture]
    public class MoneyTest
    {
        [Test]
        public void CanTestMoneyIsNull()
        {
            Money money = null;

            Assert.That(money == null, Is.True);
        }

        [Test]
        public void CanTestMoneyIsNotNull()
        {
            Money money = null;

            Assert.That(money != null, Is.False);
        }

        [Test]
        public void MoneyIsEqualIfCurrencyAndValueAreSame()
        {
            var money1 = new Money(100m, Currency.GBP);
            var money2 = new Money(100m, Currency.GBP);

            Assert.That(money1.Equals(money2), Is.True);
            Assert.That(money1 == money2, Is.True);
        }

        [Test]
        public void MoneyIsNotEqualIfCurrencyDiffers()
        {
            var money1 = new Money(100m, Currency.GBP);
            var money2 = new Money(100m, Currency.USD);

            Assert.That(money1.Equals(money2), Is.False);
            Assert.That(money1 == money2, Is.False);
        }

        [Test]
        public void MoneyIsNotEqualIfOneIsNull()
        {
            var money1 = new Money(100m, Currency.USD);
            Money money2 = null;

            Assert.That(money1.Equals(money2), Is.False);
            Assert.That(money1 == money2, Is.False);
        }

        [Test]
        public void MoneyIsNotEqualIfAreDifferentTypes()
        {
            var money1 = new Money(100m, Currency.USD);
            var integer = 123;

            Assert.That(money1.Equals(integer), Is.False);
        }

        [Test]
        public void MoneyIsNotEqualIfAreSameReference()
        {
            var money1 = new Money(100m, Currency.USD);
            var money2 = money1;

            Assert.That(money1.Equals(money2), Is.True);
            Assert.That(money1 == money2, Is.True);
        }
        
        [Test]
        public void MoneyIsNotEqualIfValueDiffers()
        {
            var money1 = new Money(100m, Currency.GBP);
            var money2 = new Money(200m, Currency.GBP);

            Assert.That(money1.Equals(money2), Is.False);
            Assert.That(money1 == money2, Is.False);
        }

        [Test]
        public void HashcodeIsSameIfCurrencyAndValueAreSame()
        {
            var hashcode1 = new Money(100m, Currency.GBP).GetHashCode();
            var hashcode2 = new Money(100m, Currency.GBP).GetHashCode();

            Assert.That(hashcode1, Is.EqualTo(hashcode2));
        }

        [Test]
        public void HashcodeAreNotSameIfCurrencyDiffers()
        {
            var hashcode1 = new Money(100m, Currency.GBP).GetHashCode();
            var hashcode2 = new Money(200m, Currency.USD).GetHashCode();

            Assert.That(hashcode1, Is.Not.EqualTo(hashcode2));
        }

        [Test]
        public void HashcodeAreNotSameIfValueDiffers()
        {
            var hashcode1 = new Money(100.01m, Currency.GBP).GetHashCode();
            var hashcode2 = new Money(100, Currency.GBP).GetHashCode();

            Assert.That(hashcode1, Is.Not.EqualTo(hashcode2));
        }

        [Test]
        public void CanNotAddIfCurrenciesDiffer()
        {
            var dollars100 = new Money(100, Currency.USD);
            var pounds100 = new Money(100, Currency.GBP);

            Assert.Throws<ConflictingCurrencyException>(() => { var addition = dollars100 + pounds100; });
        }

        [Test]
        public void CanAddValues()
        {
            var money1 = new Money(1.23, Currency.GBP);
            var money2 = new Money(100, Currency.GBP);

            Assert.That(money1 + money2, Is.EqualTo(new Money(101.23, Currency.GBP)));
        }

        [Test]
        public void CanNotSubtractIfCurrenciesDiffer()
        {
            var dollars100 = new Money(100, Currency.USD);
            var pounds100 = new Money(100, Currency.GBP);

            Assert.Throws<ConflictingCurrencyException>(() => { var addition = dollars100 - pounds100; });
        }

        [Test]
        public void CanSubtractValues()
        {
            var money1 = new Money(10, Currency.GBP);
            var money2 = new Money(10.5, Currency.GBP);

            Assert.That(money1 - money2, Is.EqualTo(new Money(-0.5, Currency.GBP)));
        }

        [Test]
        public void CanMultiplyMoney()
        {
            var result = new Money(2.55, Currency.GBP) * 2;
            Assert.That(result, Is.EqualTo(new Money(5.1, Currency.GBP)));

            result = 3 * new Money(3.55, Currency.GBP);
            Assert.That(result, Is.EqualTo(new Money(10.65, Currency.GBP)));
        }

        [TestCase(12.23, 12.22)]
        [TestCase(12.22, 12.22)]
        public void MoreThanOrEqualIsTrue(decimal value1, decimal value2)
        {
            var money1 = new Money(value1, Currency.GBP);
            var money2 = new Money(value2, Currency.GBP);

            Assert.That(money1 >= money2, Is.True);
        }

        [Test]
        public void MoreThanOrEqualToIsFalse()
        {
            var money1 = new Money(-0.01, Currency.GBP);
            var money2 = new Money(0, Currency.GBP);

            Assert.That(money1 >= money2, Is.False);
        }

        [Test]
        public void MoreThanOrEqualToCanNotCompareMixedCurrencies()
        {
            var money1 = new Money(-0.01, Currency.GBP);
            var money2 = new Money(0, Currency.EUR);

            Assert.Throws<ConflictingCurrencyException>(() =>
            {
                var result = money1 >= money2;
            });
        }

        [Test]
        public void MoreThanTrue()
        {
            var money1 = new Money(1.02, Currency.GBP);
            var money2 = new Money(1.01, Currency.GBP);

            Assert.That(money1 > money2, Is.True);
        }

        [TestCase(1.41, 1.41)]
        [TestCase(1.41, 1.42)]
        public void MoreThanIsFalse(decimal value1, decimal value2)
        {
            var money1 = new Money(value1, Currency.GBP);
            var money2 = new Money(value2, Currency.GBP);

            Assert.That(money1 > money2, Is.False);
        }

        [Test]
        public void MoreThanCanNotCompareMixedCurrencies()
        {
            var money1 = new Money(0.01, Currency.GBP);
            var money2 = new Money(0.1, Currency.EUR);

            Assert.Throws<ConflictingCurrencyException>(() =>
            {
                var result = money1 > money2;
            });
        }

        [TestCase(12.22, 12.23)]
        [TestCase(12.22, 12.22)]
        public void LessThanOrEqualIsTrue(decimal value1, decimal value2)
        {
            var money1 = new Money(value1, Currency.GBP);
            var money2 = new Money(value2, Currency.GBP);

            Assert.That(money1 <= money2, Is.True);
        }

        [Test]
        public void LessThanOrEqualToIsFalse()
        {
            var money1 = new Money(0.01, Currency.GBP);
            var money2 = new Money(-0.01, Currency.GBP);

            Assert.That(money1 <= money2, Is.False);
        }

        [Test]
        public void LessThanOrEqualToCanNotCompareMixedCurrencies()
        {
            var money1 = new Money(-0.01, Currency.GBP);
            var money2 = new Money(0, Currency.EUR);

            Assert.Throws<ConflictingCurrencyException>(() =>
            {
                var result = money1 <= money2;
            });
        }

        [Test]
        public void LessThanTrue()
        {
            var money1 = new Money(1.01, Currency.GBP);
            var money2 = new Money(1.02, Currency.GBP);

            Assert.That(money1 < money2, Is.True);
        }

        [TestCase(1.41, 1.41)]
        [TestCase(1.42, 1.41)]
        public void LessThanIsFalse(decimal value1, decimal value2)
        {
            var money1 = new Money(value1, Currency.GBP);
            var money2 = new Money(value2, Currency.GBP);

            Assert.That(money1 < money2, Is.False);
        }

        [Test]
        public void LessThanCanNotCompareMixedCurrencies()
        {
            var money1 = new Money(0.01, Currency.GBP);
            var money2 = new Money(0.1, Currency.EUR);

            Assert.Throws<ConflictingCurrencyException>(() =>
            {
                var result = money1 < money2;
            });
        }

        public class DistributeEvenly
        {
            [Test]
            public void WillSplitMoneyForCountValue()
            {
                var money = new Money(100, Currency.GBP);

                var split = money.DistributeEvenly(5, 0);

                Assert.That(split, Has.Length.EqualTo(5));
                Assert.That(split[0], Is.EqualTo(new Money(20, Currency.GBP)));
                Assert.That(split[1], Is.EqualTo(new Money(20, Currency.GBP)));
                Assert.That(split[2], Is.EqualTo(new Money(20, Currency.GBP)));
                Assert.That(split[3], Is.EqualTo(new Money(20, Currency.GBP)));
                Assert.That(split[4], Is.EqualTo(new Money(20, Currency.GBP)));
            }

            [Test]
            public void IfSplitEndsWithRemainderWillAssign()
            {
                var money = new Money(100, Currency.GBP);

                var split = money.DistributeEvenly(3, 1);

                Assert.That(split, Has.Length.EqualTo(3));
                Assert.That(split[0], Is.EqualTo(new Money(33.33, Currency.GBP)));
                Assert.That(split[1], Is.EqualTo(new Money(33.34, Currency.GBP)));
                Assert.That(split[2], Is.EqualTo(new Money(33.33, Currency.GBP)));
            }

            [Test]
            public void IfRemainderToIsHigherThanAvailableWillFail()
            {
                var money = new Money(100, Currency.GBP);

                Assert.Throws<ArgumentOutOfRangeException>(() => { 
                    money.DistributeEvenly(5, 5);
                });
                Assert.Throws<ArgumentOutOfRangeException>(() =>
                {
                    money.DistributeEvenly(5, 6);
                });
            }

            [Test]
            public void IfRemainderToIsLessThanZeroWillFail()
            {
                var money = new Money(100, Currency.GBP);

                Assert.Throws<ArgumentOutOfRangeException>(() =>
                {
                    money.DistributeEvenly(5, -1);
                });
            }

            [Test]
            public void IfCountIsLessThanZeroWillFail()
            {
                var money = new Money(100, Currency.GBP);

                Assert.Throws<ArgumentOutOfRangeException>(() =>
                {
                    money.DistributeEvenly(-1, 0);
                });
            }
        }

        public class IsWithinRoundingError
        {
            [Test]
            public void IfIsSameValueWillReturnTrue()
            {
                var thisMoney = new Money(100, Currency.GBP);
                var compare = new Money(100, Currency.GBP);

                Assert.That(thisMoney.IsWithinRoundingError(compare), Is.True);
            }

            [Test]
            public void IfIsPennyLessWillReturnTrue()
            {
                var thisMoney = new Money(100, Currency.GBP);
                var compare = new Money(100 - Currency.GBP.GetPenny(), Currency.GBP);

                Assert.That(thisMoney.IsWithinRoundingError(compare), Is.True);
            }

            [Test]
            public void IfIsPennyMoreWillReturnTrue()
            {
                var thisMoney = new Money(100, Currency.GBP);
                var compare = new Money(100 + Currency.GBP.GetPenny(), Currency.GBP);

                Assert.That(thisMoney.IsWithinRoundingError(compare), Is.True);
            }

            [Test]
            public void IfIs2PenceMoreWillReturnFalse()
            {
                var thisMoney = new Money(100, Currency.GBP);
                var compare = new Money(100 + (Currency.GBP.GetPenny() * 2m), Currency.GBP);

                Assert.That(thisMoney.IsWithinRoundingError(compare), Is.False);
            }

            [Test]
            public void IfIs2PenceLessWillReturnFalse()
            {
                var thisMoney = new Money(100, Currency.GBP);
                var compare = new Money(100 - (Currency.GBP.GetPenny() * 2m), Currency.GBP);

                Assert.That(thisMoney.IsWithinRoundingError(compare), Is.False);
            }
        }

        [Test]
        public void CanNudgeRoundingUpByPennyValueOnCurrency()
        {
            var value = 100 + Currency.GBP.GetPenny();
            var expected = new Money(value, Currency.GBP);

            var original = new Money(100, Currency.GBP);

            Assert.That(original.NudgeRoundingUp(), Is.EqualTo(expected));
        }

        [Test]
        public void CanNudgeRoundingDownByPennyValueOnCurrency()
        {
            var value = 100 - Currency.GBP.GetPenny();
            var expected = new Money(value, Currency.GBP);

            var original = new Money(100, Currency.GBP);

            Assert.That(original.NudgeRoundingDown(), Is.EqualTo(expected));
        }

        [Test]
        public void ToStringWithCodeWillReturnCorrectFormat()
        {
            var value = new Money(12.33, Currency.USD);

            Assert.That(value.ToStringWithCode(), Is.EqualTo("12.33 USD"));
        }

        [Test]
        public void ToStringWithCodeWillReturnCorrectFormatWithAllDecimalPlaces()
        {
            var value = new Money(12.3333333333333, Currency.USD);

            Assert.That(value.ToStringWithCode(), Is.EqualTo("12.3333333333333 USD"));
        }

        [Test]
        public void WhenRoundingIfNoDecimalWillNotCauseProblem() 
        {
            var value = new Money(12, Currency.EUR);

            Assert.That(value.Round(), Is.EqualTo(new Money(12, Currency.EUR)));
        }

        [Test]
        public void WhenRoundingIfDecimalIsNotWithinIssueWillNotCauseProblem()
        {
            var value = new Money(12.09, Currency.EUR);

            Assert.That(value.Round(), Is.EqualTo(new Money(12.09, Currency.EUR)));
        }

        [Test]
        public void WhenRoundingCanApplyRounding()
        {
            var value = new Money(12.3333333333334, Currency.EUR);

            Assert.That(value.Round(), Is.EqualTo(new Money(12.33, Currency.EUR)));
        }

        [TestCase("12.45GBP")]
        [TestCase("GBP 12.45")]
        [TestCase("12.45")]
        [TestCase("GBP")]
        [TestCase("GBP12.45")]
        [TestCase("$12.45")]
        [TestCase("")]
        [TestCase(" ")]
        public void WillThrowFormatException(string format)
        {
            var exception = Assert.Throws<FormatException>(() => Money.Parse(format));

            Assert.That(exception.Message, Is.EqualTo(string.Format("Can not parse \"{0}\" into a Money class.", format)));
        }

        [Test]
        public void CanParseNull()
        {
            Assert.That(Money.Parse(null), Is.Null);
        }
        
        [Test]
        public void CanParse()
        {
            Assert.That(Money.Parse("32.88 USD"), Is.EqualTo(new Money(32.88, Currency.USD)));
        }

        [Test]
        public void CanParseIfPadded()
        {
            Assert.That(Money.Parse(" 32.88 GBP "), Is.EqualTo(new Money(32.88, Currency.GBP)));
        }
    }
}