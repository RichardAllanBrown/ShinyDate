using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShinyDate;

namespace ShinyDate_Test
{
    [TestClass]
    public class ShinyDateExtensions_Test
    {
        [TestMethod]
        public void GetNextDay()
        {
            DateTime testDate = new DateTime(2014, 2, 8);

            var result = testDate.GetTomorrow();

            Assert.AreEqual(new DateTime(2014, 2, 9), result);
        }

        [TestMethod]
        public void GetYesterday()
        {
            DateTime testDate = new DateTime(2014, 2, 8);

            var result = testDate.GetYesterday();

            Assert.AreEqual(new DateTime(2014, 2, 7), result);
        }

        [TestMethod]
        public void GetNextSpecificDayOfWeek_SameDay()
        {
            DateTime testDate = new DateTime(2014, 2, 8);

            var result = testDate.GetNext(DayOfWeek.Saturday);

            Assert.AreEqual(new DateTime(2014, 2, 15), result);
        }

        [TestMethod]
        public void GetNextSpecificDayOfWeek_EnumWrap()
        {
            DateTime testDate = new DateTime(2014, 2, 8);

            var result = testDate.GetNext(DayOfWeek.Monday);

            Assert.AreEqual(new DateTime(2014, 2, 10), result);
        }

        [TestMethod]
        public void GetNextSpecificDayOfWeek_SimpleCase()
        {
            DateTime testDate = new DateTime(2014, 2, 7);

            var result = testDate.GetNext(DayOfWeek.Saturday);

            Assert.AreEqual(new DateTime(2014, 2, 8), result);
        }

        [TestMethod]
        public void GetPreviousSpecificDayOfWeek_SameDay()
        {
            DateTime testDate = new DateTime(2014, 2, 7);

            var result = testDate.GetPrevious(DayOfWeek.Saturday);

            Assert.AreEqual(new DateTime(2014, 2, 1), result);
        }

        [TestMethod]
        public void GetPreviousSpecificDayOfWeek_SimpleCase()
        {
            DateTime testDate = new DateTime(2014, 2, 7);

            var result = testDate.GetPrevious(DayOfWeek.Thursday);

            Assert.AreEqual(new DateTime(2014, 2, 6), result);
        }

        [TestMethod]
        public void GetFirstOfNextMonth()
        {
            DateTime testDate = new DateTime(2014, 2, 8);

            var result = testDate.GetFirstOfNextMonth();

            Assert.AreEqual(new DateTime(2014, 3, 1), result);
        }

        [TestMethod]
        public void GetFirstOfNextMonth_SpecificDay()
        {
            DateTime testDate = new DateTime(2014, 2, 8);

            var result = testDate.GetFirstOfNextOfMonth(DayOfWeek.Thursday);

            Assert.AreEqual(new DateTime(2014, 3, 6), result);
        }

        [TestMethod]
        public void GetLastOfNextMonth()
        {
            DateTime testDate = new DateTime(2014, 2, 8);

            var result = testDate.GetLastOfNextMonth();

            Assert.AreEqual(new DateTime(2014, 3, 31), result);
        }

        [TestMethod]
        public void GetLastOfNextMonth_SpecificDay()
        {
            DateTime testDate = new DateTime(2014, 2, 8);

            var result = testDate.GetLastOfNextMonth(DayOfWeek.Friday);

            Assert.AreEqual(new DateTime(2014, 3, 28), result);
        }

        [TestMethod]
        public void GetLastOfNextMonth_SpecificDayIsLastDay()
        {
            DateTime testDate = new DateTime(2014, 2, 8);

            var result = testDate.GetLastOfNextMonth(DayOfWeek.Monday);

            Assert.AreEqual(new DateTime(2014, 3, 31), result);
        }

        [TestMethod]
        public void AddWorkingDays_ZeroDays()
        {
            DateTime testDate = new DateTime(2014, 2, 8);

            var result = testDate.AddWorkingDays(0);

            Assert.AreEqual(testDate, result);
        }

        [TestMethod]
        public void AddWorkingDays_MultipleDays()
        {
            DateTime testDate = new DateTime(2014, 2, 8);

            var result = testDate.AddWorkingDays(25);

            Assert.AreEqual(new DateTime(2014, 3, 14), result);
        }

        [TestMethod]
        public void SubtractWorkingDays_MultipleDays()
        {
            DateTime testDate = new DateTime(2014, 2, 8);

            var result = testDate.SubtractWorkingDays(12);

            Assert.AreEqual(new DateTime(2014, 1, 23), result);
        }

        [TestMethod]
        public void GetMonthOfYear_Jan()
        {
            Assert.AreEqual(MonthOfYear.January, new DateTime(2014, 1, 12).GetMonthOfYear());
        }

        [TestMethod]
        public void GetMonthOfYear_Dec()
        {
            Assert.AreEqual(MonthOfYear.December, new DateTime(2014, 12, 25).GetMonthOfYear());
        }

        [TestMethod]
        public void CheckIfDateIsWeekend()
        {
            Assert.IsTrue(new DateTime(2014, 2, 8).IsWeekend());
            Assert.IsTrue(new DateTime(2014, 2, 9).IsWeekend());
            Assert.IsFalse(new DateTime(2014, 2, 10).IsWeekend());
            Assert.IsFalse(new DateTime(2014, 2, 7).IsWeekend());
        }

        [TestMethod]
        public void CheckIfDateIsWeekday()
        {
            Assert.IsFalse(new DateTime(2014, 2, 8).IsWeekday());
            Assert.IsFalse(new DateTime(2014, 2, 9).IsWeekday());
            Assert.IsTrue(new DateTime(2014, 2, 10).IsWeekday());
            Assert.IsTrue(new DateTime(2014, 2, 7).IsWeekday());
        }
    }
}
