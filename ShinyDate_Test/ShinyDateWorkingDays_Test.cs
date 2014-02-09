using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShinyDate.WorkingDays;

namespace ShinyDate_Test
{
    [TestClass]
    public class ShinyDateWorkingDays_Test
    {
        [TestMethod]
        public void GetNextWorkingDay_MidWeek()
        {
            var result = new DateTime(2014, 2, 5).GetNextWorkingDay();

            Assert.AreEqual(new DateTime(2014, 2, 6), result);
        }

        [TestMethod]
        public void GetNextWorkignDay_Weekend()
        {
            var result = new DateTime(2014, 2, 8).GetNextWorkingDay();

            Assert.AreEqual(new DateTime(2014, 2, 10), result);
        }

        [TestMethod]
        public void GetFirstWorkingDayOfNextMonth_FirstDayIsNotWorkingDay()
        {
            var result = new DateTime(2014, 2, 8).GetFirstWorkingDayOfNextMonth();

            Assert.AreEqual(new DateTime(2014, 3, 3), result);
        }

        [TestMethod]
        public void GetFirstWorkingDayOfNextMonth_FirstDayIsWorkingDay()
        {
            var result = new DateTime(2014, 3, 8).GetFirstWorkingDayOfNextMonth();

            Assert.AreEqual(new DateTime(2014, 4, 1), result);
        }

        [TestMethod]
        public void GetLastWorkingDayOfMonth_LastIsWorkingDay()
        {
            var result = new DateTime(2014, 2, 8).GetLastWorkingDayOfNextMonth();

            Assert.AreEqual(new DateTime(2014, 3, 31), result);
        }

        [TestMethod]
        public void GetLastWorkingDayOfMonth_LastIsNotWorkingDay()
        {
            var result = new DateTime(2014, 4, 8).GetLastWorkingDayOfNextMonth();

            Assert.AreEqual(new DateTime(2014, 5, 30), result);
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
        public void CheckIfDateIsNotWorkday()
        {
            Assert.IsTrue(new DateTime(2014, 2, 8).IsNotWorkDay());
            Assert.IsTrue(new DateTime(2014, 2, 9).IsNotWorkDay());
            Assert.IsFalse(new DateTime(2014, 2, 10).IsNotWorkDay());
            Assert.IsFalse(new DateTime(2014, 2, 7).IsNotWorkDay());
        }

        [TestMethod]
        public void CheckIfDateIsWorkday()
        {
            Assert.IsFalse(new DateTime(2014, 2, 8).IsWorkday());
            Assert.IsFalse(new DateTime(2014, 2, 9).IsWorkday());
            Assert.IsTrue(new DateTime(2014, 2, 10).IsWorkday());
            Assert.IsTrue(new DateTime(2014, 2, 7).IsWorkday());
        }
    }
}
