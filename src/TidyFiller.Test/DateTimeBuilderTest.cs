using NUnit.Framework;
using System;

namespace TidyFiller.Test
{
    [TestFixture]
    public class DateTimeBuilderTest
    {
        private static DateTime _now = DateTime.UtcNow;

        public class Extensions
        {
            [Test]
            public void ExtensionWorksForJanuary()
            {
                var date = 21.January();

                Assert.That((DateTime)date, Is.EqualTo(new DateTime(_now.Year, 1, 21)));
            }
            [Test]
            public void ExtensionWorksForJanuaryWithYear()
            {
                var date = 21.January(1981);

                Assert.That((DateTime)date, Is.EqualTo(new DateTime(1981, 1, 21)));
            }

            [Test]
            public void ExtensionWorksForFebruary()
            {
                var date = 25.February();

                Assert.That((DateTime)date, Is.EqualTo(new DateTime(_now.Year, 2, 25)));
            }
            [Test]
            public void ExtensionWorksForFebruaryWithYear()
            {
                var date = 25.February(1985);

                Assert.That((DateTime)date, Is.EqualTo(new DateTime(1985, 2, 25)));
            }

            [Test]
            public void ExtensionWorksForMarch()
            {
                var date = 1.March();

                Assert.That((DateTime)date, Is.EqualTo(new DateTime(_now.Year, 3, 1)));
            }
            [Test]
            public void ExtensionWorksForMarchWithYear()
            {
                var date = 1.March(1921);

                Assert.That((DateTime)date, Is.EqualTo(new DateTime(1921, 3, 1)));
            }

            [Test]
            public void ExtensionWorksForApril()
            {
                var date = 12.April();

                Assert.That((DateTime)date, Is.EqualTo(new DateTime(_now.Year, 4, 12)));
            }
            [Test]
            public void ExtensionWorksForAprilWithYear()
            {
                var date = 12.April(1918);

                Assert.That((DateTime)date, Is.EqualTo(new DateTime(1918, 4, 12)));
            }

            [Test]
            public void ExtensionWorksForMay()
            {
                var date = 6.May();

                Assert.That((DateTime)date, Is.EqualTo(new DateTime(_now.Year, 5, 6)));
            }
            [Test]
            public void ExtensionWorksForMayWithYear()
            {
                var date = 6.May(1835);

                Assert.That((DateTime)date, Is.EqualTo(new DateTime(1835, 5, 6)));
            }

            [Test]
            public void ExtensionWorksForJune()
            {
                var date = 16.June();

                Assert.That((DateTime)date, Is.EqualTo(new DateTime(_now.Year, 6, 16)));
            }
            [Test]
            public void ExtensionWorksForJuneWithYear()
            {
                var date = 16.June(1235);

                Assert.That((DateTime)date, Is.EqualTo(new DateTime(1235, 6, 16)));
            }

            [Test]
            public void ExtensionWorksForJuly()
            {
                var date = 6.July();

                Assert.That((DateTime)date, Is.EqualTo(new DateTime(_now.Year, 7, 6)));
            }
            [Test]
            public void ExtensionWorksForJulyWithYear()
            {
                var date = 6.July(1066);

                Assert.That((DateTime)date, Is.EqualTo(new DateTime(1066, 7, 6)));
            }

            [Test]
            public void ExtensionWorksForAugust()
            {
                var date = 9.August();

                Assert.That((DateTime)date, Is.EqualTo(new DateTime(_now.Year, 8, 9)));
            }
            [Test]
            public void ExtensionWorksForAugustWithYear()
            {
                var date = 9.August(1966);

                Assert.That((DateTime)date, Is.EqualTo(new DateTime(1966, 8, 9)));
            }

            [Test]
            public void ExtensionWorksForSeptember()
            {
                var date = 1.September();

                Assert.That((DateTime)date, Is.EqualTo(new DateTime(_now.Year, 9, 1)));
            }
            [Test]
            public void ExtensionWorksForSeptemberWithYear()
            {
                var date = 1.September(1933);

                Assert.That((DateTime)date, Is.EqualTo(new DateTime(1933, 9, 1)));
            }

            [Test]
            public void ExtensionWorksForOctober()
            {
                var date = 19.October();

                Assert.That((DateTime)date, Is.EqualTo(new DateTime(_now.Year, 10, 19)));
            }
            [Test]
            public void ExtensionWorksForOctoberWithYear()
            {
                var date = 19.October(1953);

                Assert.That((DateTime)date, Is.EqualTo(new DateTime(1953, 10, 19)));
            }

            [Test]
            public void ExtensionWorksForNovember()
            {
                var date = 4.November();

                Assert.That((DateTime)date, Is.EqualTo(new DateTime(_now.Year, 11, 4)));
            }
            [Test]
            public void ExtensionWorksForNovemberWithYear()
            {
                var date = 4.November(1974);

                Assert.That((DateTime)date, Is.EqualTo(new DateTime(1974, 11, 4)));
            }

            [Test]
            public void ExtensionWorksForDecember()
            {
                var date = 25.December();

                Assert.That((DateTime)date, Is.EqualTo(new DateTime(_now.Year, 12, 25)));
            }
            [Test]
            public void ExtensionWorksForDecemberWithYear()
            {
                var date = 25.December(2008);

                Assert.That((DateTime)date, Is.EqualTo(new DateTime(2008, 12, 25)));
            }
        }

        [Test]
        public void SettingNothingWillBeEqualToDefaultDateTime()
        {
            Assert.That(new DateTimeBuilder().Build(), Is.EqualTo(new DateTime()));
        }

        [Test]
        public void CanAddDay()
        {
            var date = new DateTimeBuilder().Day(2).Build();

            Assert.That(date, Is.EqualTo(new DateTime(1, 1, 2)));
        }

        [Test]
        public void CanAddMonth()
        {
            var date = new DateTimeBuilder().Month(12).Build();

            Assert.That(date, Is.EqualTo(new DateTime(1, 12, 1)));
        }

        [Test]
        public void CanAddYear()
        {
            var date = new DateTimeBuilder().Year(1210).Build();

            Assert.That(date, Is.EqualTo(new DateTime(1210, 1, 1)));
        }

        [Test]
        public void CanAddTimeForHoursAndMinutes()
        {
            var date = new DateTimeBuilder()
                .Day(2)
                .Month(12)
                .Year(1210)
                .At(16, 35)
                .Build();

            Assert.That(date, Is.EqualTo(new DateTime(1210, 12, 2, 16, 35, 0, 0)));
        }

        [Test]
        public void CanAddTimeForHoursMinutesAndSeconds()
        {
            var date = new DateTimeBuilder()
                .Day(2)
                .Month(12)
                .Year(1210)
                .At(16, 35, 12)
                .Build();

            Assert.That(date, Is.EqualTo(new DateTime(1210, 12, 2, 16, 35, 12, 0)));
        }

        [Test]
        public void CanAddTimeForHoursMinutesSecondsAndMilliseconds()
        {
            var date = new DateTimeBuilder()
                .Day(2)
                .Month(12)
                .Year(1210)
                .At(16, 35, 12, 876)
                .Build();

            Assert.That(date, Is.EqualTo(new DateTime(1210, 12, 2, 16, 35, 12, 876)));
        }

        [Test]
        public void CanSetTimeToJustBeforeMidnight()
        {
            var date = new DateTimeBuilder()
                .Day(16).Month(3).Year(2012)
                .JustBeforeMidnight()
                .Build();

            var expected = new DateTime(2012, 3, 16, 23, 59, 59, 999);

            Assert.That(date, Is.EqualTo(expected));
        }

        [Test]
        public void CanSetTimeToStartOfDay()
        {
            var date = new DateTimeBuilder()
                .Day(16).Month(3).Year(2012)
                .AtStartOfDay()
                .Build();

            var expected = new DateTime(2012, 3, 16);

            Assert.That(date, Is.EqualTo(expected));
        }
    }
}