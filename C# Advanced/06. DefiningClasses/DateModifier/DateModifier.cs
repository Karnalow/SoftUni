using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace DefiningClasses
{
    public class DateModifier
    {
        public long DataDiff(string date1, string date2)
        {
            DateTime firstDate = DateTime.ParseExact(date1, "yyyy MM dd", CultureInfo.InvariantCulture);
            DateTime secondDate = DateTime.ParseExact(date2, "yyyy MM dd", CultureInfo.InvariantCulture);

            double diff = secondDate.Subtract(firstDate).TotalDays;

            return (long)diff;
        }
    }
}
