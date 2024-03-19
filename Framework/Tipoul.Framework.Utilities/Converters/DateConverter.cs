using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tipoul.Framework.Utilities.Utilities;

namespace Tipoul.Framework.Utilities.Converters
{
    public static class DateConverter
    {
        private static PersianCalendar? persianCalendar;

        public static DateTime ToGerigorian(string date)
        {
            return DateTime.Parse(StringUtility.ToEnglishNumber(date), new CultureInfo("fa-IR"));
        }

        public static string ToShamsy(DateTime? dateTime, bool includeTime = false)
        {
            if (!dateTime.HasValue || dateTime.Value.Year <= 622 || dateTime.Value.Year > 9999)
                return "";

            PersianCalendar pc = GetPersianCalendar();

            return $"{pc.GetYear(dateTime.Value)}/{pc.GetMonth(dateTime.Value)}/{pc.GetDayOfMonth(dateTime.Value)}"
                + (includeTime ? $" {dateTime.Value.Hour.ToString().PadLeft(2, '0')}:{dateTime.Value.Minute.ToString().PadLeft(2, '0')}:{dateTime.Value.Second.ToString().PadLeft(2, '0')}" : string.Empty);
        }

        public static string ToShamsy(DateTime dateTime, string format)
        {
            PersianCalendar pc = GetPersianCalendar();

            format = format
                .Replace("yyyy", pc.GetYear(dateTime).ToString())
                .Replace("MM", pc.GetMonth(dateTime).ToString())
                .Replace("dd", pc.GetDayOfMonth(dateTime).ToString());

            return format;
        }

        public static string ToAccurateShamsy(DateTime dateTime)
        {
            PersianCalendar pc = GetPersianCalendar();

            return $"{pc.GetYear(dateTime)}/{pc.GetMonth(dateTime)}/{pc.GetDayOfMonth(dateTime)} {dateTime.Hour}:{dateTime.Minute}:{dateTime.Second}.{dateTime.Millisecond}";
        }

        private static PersianCalendar GetPersianCalendar()
        {
            if (persianCalendar == null)
                persianCalendar = new PersianCalendar();

            return persianCalendar;
        }
        public static string GetCurrentPersianDate()
        {
            PersianCalendar pc = GetPersianCalendar();
            DateTime date = new DateTime();
            date = DateTime.Parse(DateTime.Now.ToShortDateString());
            int year = pc.GetYear(date);
            int month = pc.GetMonth(date);
            int day = pc.GetDayOfMonth(date);
            string str = string.Format("{0}/{1}/{2}", year.ToString().PadLeft(4, '0'), month.ToString().PadLeft(2, '0'), day.ToString().PadLeft(2, '0'));
            return str;
        }
    }
}
