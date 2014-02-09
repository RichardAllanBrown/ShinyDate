using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ShinyDate;

namespace ShinyDate.WorkingDays
{
    public static class ShinyDateWorkingDays
    {
        public static DateTime GetNextWorkingDay(this DateTime from)
        {
            return from.AddWorkingDays(1);
        }

        public static DateTime GetPreviousWorkingDay(this DateTime from)
        {
            return from.AddWorkingDays(-1);
        }

        public static DateTime GetFirstWorkingDayOfNextMonth(this DateTime from)
        {
            var firstOfNextMonth = from.GetFirstOfNextMonth();

            if (firstOfNextMonth.IsWorkday())
            {
                return firstOfNextMonth;
            }

            return firstOfNextMonth.AddWorkingDays(1);
        }

        public static DateTime GetLastWorkingDayOfNextMonth(this DateTime from)
        {
            var lastOfNextMonth = from.GetLastOfNextMonth();

            if (lastOfNextMonth.IsWorkday())
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

                if (from.IsWorkday())
                {
                    workingDays -= 1;
                }
            }

            return from;
        }

        public static bool IsNotWorkDay(this DateTime dateToCheck)
        {
            return dateToCheck.DayOfWeek == DayOfWeek.Saturday || dateToCheck.DayOfWeek == DayOfWeek.Sunday;
        }

        public static bool IsWorkday(this DateTime dateToCheck)
        {
            return !dateToCheck.IsNotWorkDay();
        }
    }
}
