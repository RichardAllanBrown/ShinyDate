using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShinyDate
{
    public enum MonthOfYear
    {
        January = 1,
        February = 2,
        March = 3,
        April = 4,
        May = 5,
        June = 6,
        July = 7,
        August = 8,
        September = 9,
        October = 10,
        November = 11,
        December = 12
    }

    public enum Occurrence
    {
        FifthFromLast = -5,
        ForthFromLast = -4,
        ThirdFromLast = -3,
        SecondFromLast = -2,
        Last = -1,
        First = 1,
        Second = 2,
        Third = 3,
        Forth = 4,
        Fifth = 5,
    }

    public static class ShinyDateExtentions
    {
        private static int DAYS_IN_WEEK = 7;

        public static DateTime GetTomorrow(this DateTime from)
        {
            return from.AddDays(1);
        }

        public static DateTime GetYesterday(this DateTime from)
        {
            return from.AddDays(-1);
        }

        public static DateTime GetNext(this DateTime from, DayOfWeek day)
        {
            int daysDifference = day - from.DayOfWeek;
            int daysUntilNext = daysDifference;

            if (daysDifference <= 0)
            {
                daysUntilNext += 7;
            }

            return from.AddDays(daysUntilNext);
        }

        public static DateTime GetNextWorkingDay(this DateTime from)
        {
            return from.AddWorkingDays(1);
        }

        public static DateTime GetPrevious(this DateTime from, DayOfWeek day)
        {
            int daysToSubtract = -7;

            if (from.DayOfWeek == day)
            {
                daysToSubtract -= 7;
            }

            return from.GetNext(day).AddDays(daysToSubtract);
        }

        public static DateTime GetPreviousWorkingDay(this DateTime from)
        {
            return from.AddWorkingDays(-1);
        }

        public static DateTime GetFirstOfNextMonth(this DateTime from)
        {
            return from.AddMonths(1).AddDays(1 - from.Day);
        }

        public static DateTime GetFirstOfNextMonth(this DateTime from, DayOfWeek day)
        {
            var firstOfNextMonth = from.GetFirstOfNextMonth();

            if (firstOfNextMonth.DayOfWeek == day)
            {
                return firstOfNextMonth;
            }

            return firstOfNextMonth.GetNext(day);
        }

        public static DateTime GetOccurrenceOfNextMonth(this DateTime from, DayOfWeek day, Occurrence occurance)
        {
            DateTime relevantMonthEnd;

            if (occurance > 0)
            {
                relevantMonthEnd = from.GetFirstOfNextMonth(day);
                occurance -= 1;
            }
            else
            {
                relevantMonthEnd = from.GetLastOfNextMonth(day);
                occurance += 1;
            }

            MonthOfYear monthToScan = relevantMonthEnd.MonthOfYear();
            DateTime foundDate = relevantMonthEnd.AddWeeks((int)occurance);

            if (foundDate.MonthOfYear() == monthToScan)
            {
                return foundDate;
            }

            string errorMessage = String.Format("Cannot get the {0} {1} of {2}", occurance, day, monthToScan);
            throw new ArgumentOutOfRangeException(errorMessage);
        }

        public static DateTime GetFirstWorkingDayOfNextMonth(this DateTime from)
        {
            var firstOfNextMonth = from.GetFirstOfNextMonth();

            if (firstOfNextMonth.IsWeekday())
            {
                return firstOfNextMonth;
            }

            return firstOfNextMonth.AddWorkingDays(1);
        }

        public static DateTime GetLastOfNextMonth(this DateTime from)
        {
            return from.AddMonths(2).AddDays(-from.Day);
        }

        public static DateTime GetLastOfNextMonth(this DateTime from, DayOfWeek day)
        {
            var lastDayOfNextMonth = from.GetLastOfNextMonth();

            if (lastDayOfNextMonth.DayOfWeek == day)
            {
                return lastDayOfNextMonth;
            }

            return lastDayOfNextMonth.GetPrevious(day);
        }

        public static DateTime GetLastWorkingDayOfNextMonth(this DateTime from)
        {
            var lastOfNextMonth = from.GetLastOfNextMonth();

            if (lastOfNextMonth.IsWeekday())
            {
                return lastOfNextMonth;
            }

            return lastOfNextMonth.GetPreviousWorkingDay();
        }

        public static DateTime AddWorkingDays(this DateTime from, int daysToAdd)
        {
            var temporalDirection = Math.Sign(daysToAdd);
            var workingDays = Math.Abs(daysToAdd);

            while (0 < workingDays)
            {
                from = from.AddDays(temporalDirection);

                if (from.IsWeekday())
                {
                    workingDays -= 1;
                }
            }

            return from;
        }

        public static DateTime AddWeeks(this DateTime from, int weeksToAdd)
        {
            return from.AddDays(weeksToAdd * DAYS_IN_WEEK);
        }

        public static MonthOfYear MonthOfYear(this DateTime of)
        {
            return (MonthOfYear)of.Month;
        }

        public static bool IsWeekend(this DateTime dateToCheck)
        {
            return dateToCheck.DayOfWeek == DayOfWeek.Saturday || dateToCheck.DayOfWeek == DayOfWeek.Sunday;
        }

        public static bool IsWeekday(this DateTime dateToCheck)
        {
            return !dateToCheck.IsWeekend();
        }
    }
}
