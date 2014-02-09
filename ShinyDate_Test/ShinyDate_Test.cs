using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ShinyDate;

namespace ShinyDate_Test
{
    [TestClass]
    public class ShinyDate_Test
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

            var result = testDate.GetFirstOfNextMonth(DayOfWeek.Thursday);

            Assert.AreEqual(new DateTime(2014, 3, 6), result);
        }

        [TestMethod]
        public void GetFirstOfNextMonth_SpecificDayIsFirst()
        {
            var result = new DateTime(2014, 2, 8).GetFirstOfNextMonth(DayOfWeek.Saturday);

            Assert.AreEqual(new DateTime(2014, 3, 1), result);
        }

        [TestMethod]
        public void GetOccurrenceOfNextMonth_WithinRange_LookingForward()
        {
            var result = new DateTime(2014, 2, 8).GetOccurrenceOfNextMonth(DayOfWeek.Tuesday, Occurrence.Third);

            Assert.AreEqual(new DateTime(2014, 3, 18), result);
        }

        [TestMethod]
        public void GetOccurrenceOfNextMonth_WithinRange_LookingBackward()
        {
            var result = new DateTime(2014, 2, 8).GetOccurrenceOfNextMonth(DayOfWeek.Friday, Occurrence.SecondFromLast);

            Assert.AreEqual(new DateTime(2014, 3, 21), result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetOccurrenceOfNextMonth_OutsideRangeForward_ThrowsException()
        {
            var result = new DateTime(2014, 1, 20).GetOccurrenceOfNextMonth(DayOfWeek.Sunday, Occurrence.Fifth);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetOccurrenceOfNextMonth_OutsideRangeBackward_ThrowsException()
        {
            var result = new DateTime(2014, 1, 20).GetOccurrenceOfNextMonth(DayOfWeek.Sunday, Occurrence.FifthFromLast);
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
        public void GetNearest_IsToday()
        {
            var result = new DateTime(2014, 2, 8).GetNearest(DayOfWeek.Saturday);

            Assert.AreEqual(new DateTime(2014, 2, 8), result);
        }

        [TestMethod]
        public void GetNearest_InFuture()
        {
            var result = new DateTime(2014, 2, 8).GetNearest(DayOfWeek.Sunday);

            Assert.AreEqual(new DateTime(2014, 2, 9), result);
        }

        [TestMethod]
        public void GetNearest_InPast()
        {
            var result = new DateTime(2014, 2, 8).GetNearest(DayOfWeek.Thursday);

            Assert.AreEqual(new DateTime(2014, 2, 6), result);
        }

        [TestMethod]
        public void GetNearestOccurrence_IsToday()
        {
            var result = new DateTime(2014, 2, 8).GetNearestOccurrence(DayOfWeek.Saturday, Occurrence.Second);

            Assert.AreEqual(new DateTime(2014, 2, 8), result);
        }

        [TestMethod]
        public void GetNearestOccurrence_InFuture()
        {
            var result = new DateTime(2014, 2, 8).GetNearestOccurrence(DayOfWeek.Tuesday, Occurrence.Second);

            Assert.AreEqual(new DateTime(2014, 2, 11), result);
        }

        [TestMethod]
        public void GetNearestOccurrence_InPast()
        {
            var result = new DateTime(2014, 2, 8).GetNearestOccurrence(DayOfWeek.Tuesday, Occurrence.First);

            Assert.AreEqual(new DateTime(2014, 2, 4), result);
        }

        [TestMethod]
        public void AddWeeks_PositiveNumber()
        {
            var result = new DateTime(2013, 2, 8).AddWeeks(4);

            Assert.AreEqual(new DateTime(2013, 3, 8), result);
        }

        [TestMethod]
        public void GetMonthOfYear_Jan()
        {
            Assert.AreEqual(MonthOfYear.January, new DateTime(2014, 1, 12).MonthOfYear());
        }

        [TestMethod]
        public void GetMonthOfYear_Dec()
        {
            Assert.AreEqual(MonthOfYear.December, new DateTime(2014, 12, 25).MonthOfYear());
        }

        [TestMethod]
        public void IsInLeapYear_NotDivisibleBy4()
        {
            Assert.IsFalse(new DateTime(2014, 2, 4).IsInLeapYear());
        }

        [TestMethod]
        public void IsInLeapYear_DivisibleBy4NotBy100()
        {
            Assert.IsTrue(new DateTime(2004, 2, 4).IsInLeapYear());
        }

        [TestMethod]
        public void IsInLeapYear_DivisibleBy4And100And400()
        {
            Assert.IsTrue(new DateTime(2000, 2, 4).IsInLeapYear());
        }

        [TestMethod]
        public void IsInLeapYear_DivisibleBy4And100NotBy400()
        {
            Assert.IsFalse(new DateTime(2100, 2, 4).IsInLeapYear());
        }

        [TestMethod]
        public void IsOccurrenceOf_True()
        {
            Assert.IsTrue(new DateTime(2014, 2, 8).IsOccurrenceOf(DayOfWeek.Saturday, Occurrence.Second));
        }

        [TestMethod]
        public void IsOccurrenceOf_False()
        {
            Assert.IsFalse(new DateTime(2014, 2, 8).IsOccurrenceOf(DayOfWeek.Saturday, Occurrence.Last));
        }

        [TestMethod]
        public void IsOccurrenceOf_ImpossibleOcc()
        {
            Assert.IsFalse(new DateTime(2014, 2, 8).IsOccurrenceOf(DayOfWeek.Saturday, Occurrence.Fifth));
        }

        [TestMethod]
        public void IsOccurrenceOf_WrongDay()
        {
            Assert.IsFalse(new DateTime(2014, 2, 8).IsOccurrenceOf(DayOfWeek.Tuesday, Occurrence.Second));
        }
    }
}
