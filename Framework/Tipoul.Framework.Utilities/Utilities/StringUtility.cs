namespace Tipoul.Framework.Utilities.Utilities
{
    public static class StringUtility
    {
        public static string ToEnglishNumber(string str)
        {
            string[] persian = new string[10] { "۰", "۱", "۲", "۳", "۴", "۵", "۶", "۷", "۸", "۹" };

            for (int j = 0; j < persian.Length; j++)
                str = str.Replace(persian[j], j.ToString());

            return str;
        }

        public static string ToPersianNumber(string str)
        {
            string[] persian = new string[10] { "۰", "۱", "۲", "۳", "۴", "۵", "۶", "۷", "۸", "۹" };

            for (int j = 0; j < persian.Length; j++)
                str = str.Replace(j.ToString(), persian[j]);

            return str;
        }
    }
}
