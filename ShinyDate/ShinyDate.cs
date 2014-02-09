using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShinyDate
{
    public static class ShinyDateExtentions
    {
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

            return lastOfNextMonth.SubtractWorkingDays(1);
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

        public static DateTime SubtractWorkingDays(this DateTime from, int daysToSubtract)
        {
            return from.AddWorkingDays(-daysToSubtract);
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
