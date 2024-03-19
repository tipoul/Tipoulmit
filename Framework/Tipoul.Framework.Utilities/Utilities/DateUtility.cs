using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipoul.Framework.Utilities.Utilities
{
    public static class DateUtility
    {
        public static long ToTotalMilliseconds(this DateTime dateTime)
        {
            var zeroDate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Local);
            return ((long)dateTime.Date.ToLocalTime().Date.Subtract(zeroDate).TotalSeconds) * 1000;
        }

        public static string GetShamsyDayName(DateTime date)
        {
            switch (date.DayOfWeek)
            {
                case DayOfWeek.Saturday:
                    return "شنبه";
                case DayOfWeek.Sunday:
                    return "یکشنبه";
                case DayOfWeek.Monday:
                    return "دوشنبه";
                case DayOfWeek.Tuesday:
                    return "سه شنبه";
                case DayOfWeek.Wednesday:
                    return "چهارشنبه";
                case DayOfWeek.Thursday:
                    return "پنج شنبه";
                case DayOfWeek.Friday:
                    return "جمعه";
                default:
                    throw new ArgumentException(nameof(date.DayOfWeek));
            }
        }

        public static string GetMonthName(DateTime date)
        {
            var month = new PersianCalendar().GetMonth(date);

            switch (month)
            {
                case 1:
                    return "فروردین";
                case 2:
                    return "اردیبهشت";
                case 3:
                    return "خرداد";
                case 4:
                    return "تیر";
                case 5:
                    return "مرداد";
                case 6:
                    return "شهریور";
                case 7:
                    return "مهر";
                case 8:
                    return "آبان";
                case 9:
                    return "آذر";
                case 10:
                    return "دی";
                case 11:
                    return "بهمن";
                case 12:
                    return "اسفند";
                default:
                    throw new ArgumentOutOfRangeException(nameof(date.Month));
            }
        }
    }
}
