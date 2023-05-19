using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SmartManagerServer.Core.Infrastructure.TypeExtensions
{
    public static class DateExtensions
    {
        public static int ToWeekOfYear(this DateTime date)
        {
            CultureInfo cultureInfo = CultureInfo.CurrentCulture;
            return cultureInfo.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
        }
    }
}
