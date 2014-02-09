using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

using ShinyDate.Collections;

namespace ShinyDate_Test
{
    [TestClass]
    public class ShinyDateCollections_Test
    {
        [TestMethod]
        public void GetAllDaysBetween_GetsCorrectDays()
        {
            var expectedDates = new List<DateTime>
            {
                new DateTime(2014, 2, 8),
                new DateTime(2014, 2, 9),
                new DateTime(2014, 2, 10),
                new DateTime(2014, 2, 11),
                new DateTime(2014, 2, 12),
                new DateTime(2014, 2, 13),
                new DateTime(2014, 2, 14)
            };

            var result = ShinyDateCollections.GetAllDaysBetween(new DateTime(2014, 2, 8), new DateTime(2014, 2, 14)).ToList();

            CollectionAssert.AreEquivalent(expectedDates, result);
        }

        [TestMethod]
        public void GetAllWorkingDaysBetween_GetsCorrectDays()
        {
            var expectedDates = new List<DateTime>
            {
                new DateTime(2014, 2, 10),
                new DateTime(2014, 2, 11),
                new DateTime(2014, 2, 12),
                new DateTime(2014, 2, 13),
                new DateTime(2014, 2, 14),
                new DateTime(2014, 2, 17)
            };

            var result = ShinyDateCollections.GetAllWorkingDaysBetween(new DateTime(2014, 2, 8), new DateTime(2014, 2, 17)).ToList();

            CollectionAssert.AreEquivalent(expectedDates, result);
        }

        [TestMethod]
        public void GetAllDayOfWeek_GetsCorrectDays()
        {
            var expectedDates = new List<DateTime>
            {
                new DateTime(2014, 2, 5),
                new DateTime(2014, 2, 12),
                new DateTime(2014, 2, 19),
                new DateTime(2014, 2, 26)
            };

            var result = ShinyDateCollections.GetAllDayOfWeek(new DateTime(2014, 2, 4), new DateTime(2014, 2, 27), DayOfWeek.Wednesday).ToList();

            CollectionAssert.AreEquivalent(expectedDates, result);
        }

        [TestMethod]
        public void GetAllOccs_GetsCorrectDays()
        {
            var expectedDates = new List<DateTime>
            {
                new DateTime(2014, 2, 11),
                new DateTime(2014, 3, 11),
                new DateTime(2014, 4, 8),
                new DateTime(2014, 5, 13)
            };

            var result = ShinyDateCollections.GetAllOccurrences(new DateTime(2014, 2, 1), new DateTime(2014, 6, 6), DayOfWeek.Tuesday, ShinyDate.Occurrence.Second).ToList();

            CollectionAssert.AreEquivalent(expectedDates, result);
        }
    }
}
