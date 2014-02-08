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
            yield return from;

            while (from < to)
            {
                from = from.GetTomorrow();
                yield return from;
            }
        }
    }
}
