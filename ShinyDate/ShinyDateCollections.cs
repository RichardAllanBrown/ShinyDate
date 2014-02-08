using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShinyDate.Collections
{
    public static class ShinyDateCollections
    {
        public static IEnumerable<DateTime> GetAllDaysBetween(DateTime from, DateTime to, bool inclusive = true)
        {
            if (inclusive)
            {
                yield return from;
            }

            from = from.GetTomorrow();

            while (from < to)
            {
                yield return from;
                from = from.GetTomorrow();
            }

            if (inclusive)
            {
                yield return from;
            }
        }
    }
}
