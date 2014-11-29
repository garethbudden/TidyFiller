using NUnit.Framework;
using TidyFiller;

namespace TidyFiller.Test
{
    [TestFixture]
    public class CurrencyTest
    {
        [TestCase("GBP", 826, "£", "S", 826, "£")]
        [TestCase("GBP", 826, "£", "GBP", 86, "£")]
        [TestCase("GBP", 826, "£", "GBP", 826, "$")]
        public void WillNotBeEqual(string code1, int number1, string symbol1, string code2, int number2, string symbol2)
        {
            var currency1 = new Currency(code1, number1, symbol1);
            var currency2 = new Currency(code2, number2, symbol2);

            Assert.That(currency1.Equals(currency2), Is.False);
            Assert.That(currency1 == currency2, Is.False);
        }

        [Test]
        public void WillBeEqual()
        {
            var currency1 = new Currency("GBP", 826, "£");
            var currency2 = new Currency("GBP", 826, "£");

            Assert.That(currency1.Equals(currency2), Is.True);
            Assert.That(currency1 == currency2, Is.True);
        }

        [Test]
        public void IsNotEqualIfOneIsNull()
        {
            var currency1 = new Currency("GBP", 826, "£");
            Currency currency2 = null;

            Assert.That(currency1.Equals(currency2), Is.False);
            Assert.That(currency1 == currency2, Is.False);
        }

        [Test]
        public void IsNotEqualIfAreDifferentTypes()
        {
            var currency1 = new Currency("GBP", 826, "£");
            var integer = 123;

            Assert.That(currency1.Equals(integer), Is.False);
        }

        [TestCase("GBP", 826, "£", "S", 826, "£")]
        [TestCase("GBP", 826, "£", "GBP", 86, "£")]
        [TestCase("GBP", 826, "£", "GBP", 826, "$")]
        public void HashCodesWillNotBeEqual(string code1, int number1, string symbol1, string code2, int number2, string symbol2)
        {
            var currency1 = new Currency(code1, number1, symbol1);
            var currency2 = new Currency(code2, number2, symbol2);

            Assert.That(currency1.Equals(currency2), Is.False);
            Assert.That(currency1 == currency2, Is.False);
        }

        [Test]
        public void HashCodesWillBeEqual()
        {
            var currency1 = new Currency("GBP", 826, "£");
            var currency2 = new Currency("GBP", 826, "£");

            Assert.That(currency1.Equals(currency2), Is.True);
            Assert.That(currency1 == currency2, Is.True);
        }

        [Test]
        public void CanImplicitlyConvertGBPCodeToCurrency()
        {
            var currency = (Currency)"GBP";

            Assert.That(currency, Is.EqualTo(Currency.GBP));
        }

        [Test]
        public void CanImplicitlyConvertUSDCodeToCurrency()
        {
            var currency = (Currency)"USD";

            Assert.That(currency, Is.EqualTo(Currency.USD));
        }

        [Test]
        public void CanImplicitlyConvertEURCodeToCurrency()
        {
            var currency = (Currency)"EUR";

            Assert.That(currency, Is.EqualTo(Currency.EUR));
        }

        [Test]
        public void CanImplicitlyConvert826CodeToGBP()
        {
            var currency = (Currency)826;

            Assert.That(currency, Is.EqualTo(Currency.GBP));
        }

        [Test]
        public void CanImplicitlyConvert840CodeToUSD()
        {
            var currency = (Currency)840;

            Assert.That(currency, Is.EqualTo(Currency.USD));
        }

        [Test]
        public void CanImplicitlyConvert978CodeToEUR()
        {
            var currency = (Currency)978;

            Assert.That(currency, Is.EqualTo(Currency.EUR));
        }
    }
}