using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShinyDate.Collections;
using System.Linq;

namespace ShinyDate_Test
{
    [TestClass]
    public class ShinyDateCollections_Test
    {
        [TestMethod]
        public void GetAllDaysBetween_Inclusive()
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
        public void GetAllDaysBetween_Exclusive()
        {
            var expectedDates = new List<DateTime>
            {
                new DateTime(2014, 2, 9),
                new DateTime(2014, 2, 10),
                new DateTime(2014, 2, 11),
                new DateTime(2014, 2, 12),
                new DateTime(2014, 2, 13)
            };

            var result = ShinyDateCollections.GetAllDaysBetween(new DateTime(2014, 2, 8), new DateTime(2014, 2, 14), inclusive: false).ToList();

            CollectionAssert.AreEquivalent(expectedDates, result);
        }
    }
}
