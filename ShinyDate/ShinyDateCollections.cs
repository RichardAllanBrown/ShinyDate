using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ShinyDate;
using ShinyDate.WorkingDays;

namespace ShinyDate.Collections
{
    public static class ShinyDateCollections
    {
        public static IEnumerable<DateTime> GetAllDaysBetween(DateTime from, DateTime to)
        {
            yield return from;

            while (from < to)
            {
                from = from.GetTomorrow();
                yield return from;
                
            }
        }

        public static IEnumerable<DateTime> GetAllWorkingDaysBetween(DateTime from, DateTime to)
        {
            return GetAllDaysBetween(from, to).Where(x => x.IsWorkday());
        }

        public static IEnumerable<DateTime> GetAllDayOfWeek(DateTime from, DateTime to, DayOfWeek day)
        {
            return GetAllDaysBetween(from, to).Where(x => x.DayOfWeek == day);
        }
    }
}
