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

        public static DateTime GetPrevious(this DateTime from, DayOfWeek day)
        {
            int daysToSubtract = -7;

            if (from.DayOfWeek == day)
            {
                daysToSubtract -= 7;
            }

            return from.GetNext(day).AddDays(daysToSubtract);
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

        public static DateTime GetOccurrenceOfNextMonth(this DateTime from, DayOfWeek day, Occurrence occurrence)
        {
            DateTime relevantMonthEnd;

            if (occurrence > 0)
            {
                relevantMonthEnd = from.GetFirstOfNextMonth(day);
                occurrence -= 1;
            }
            else
            {
                relevantMonthEnd = from.GetLastOfNextMonth(day);
                occurrence += 1;
            }

            MonthOfYear monthToScan = relevantMonthEnd.MonthOfYear();
            DateTime foundDate = relevantMonthEnd.AddWeeks((int)occurrence);

            if (foundDate.MonthOfYear() == monthToScan)
            {
                return foundDate;
            }

            string errorMessage = String.Format("Cannot get the {0} {1} of {2}", occurrence, day, monthToScan);
            throw new ArgumentOutOfRangeException(errorMessage);
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

        public static DateTime GetNearest(this DateTime from, DayOfWeek day)
        {
            if (from.DayOfWeek == day)
            {
                return from;
            }

            var nextSuitableDate = from.GetNext(day);
            var previousSuitableDate = from.GetPrevious(day);

            return CalculateClosest(previousSuitableDate, from, nextSuitableDate);
        }

        private static DateTime CalculateClosest(DateTime pastMatchDate, DateTime comparator, DateTime futureMatchDate)
        {
            if (futureMatchDate - comparator > comparator - pastMatchDate)
            {
                return pastMatchDate;
            }

            return futureMatchDate;
        }

        public static DateTime GetNearestOccurrence(this DateTime from, DayOfWeek day, Occurrence occurrence)
        {
            var nextSuitableDate = from.GetOccurrenceOfNextMonth(day, occurrence);
            var previousSuitableDate = from.AddMonths(-1).GetOccurrenceOfNextMonth(day, occurrence);

            return CalculateClosest(previousSuitableDate, from, nextSuitableDate);
        }

        public static DateTime AddWeeks(this DateTime from, double weeksToAdd)
        {
            return from.AddDays(weeksToAdd * DAYS_IN_WEEK);
        }

        public static MonthOfYear MonthOfYear(this DateTime of)
        {
            return (MonthOfYear)of.Month;
        }

        public static bool IsInLeapYear(this DateTime date)
        {
            int year = date.Year;

            if (year % 4 != 0)
            {
                return false;
            }

            if (year % 100 != 0)
            {
                return true;
            }

            if (year % 400 == 0)
            {
                return true;
            }

            return false;
        }

        public static bool IsOccurrenceOf(this DateTime date, DayOfWeek day, Occurrence occurrence)
        {
            if (day != date.DayOfWeek)
            {
                return false;
            }

            try
            {
                var compare = date.AddMonths(-1).GetOccurrenceOfNextMonth(day, occurrence);
                return compare.Date == date.Date;
            }
            catch
            {
                return false;
            }
        }
    }
}
