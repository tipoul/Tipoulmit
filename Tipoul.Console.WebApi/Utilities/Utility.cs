using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;

namespace Tipoul.Console.WebApi.Utilities
{
    public class Utility
    {
        private static Random rand = new Random((int)DateTime.Now.Ticks);
        private const string Alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public static string GetTraceNumber()
        {
            var traceNumber = DateTime.Now.TimeOfDay.TotalMilliseconds.ToString().Substring(DateTime.Now.TimeOfDay.TotalMilliseconds.ToString().Length - 4);
            traceNumber += rand.Next(1000, 9999);
            traceNumber += new PersianCalendar().GetDayOfMonth(DateTime.Now).ToString().PadLeft(2, '0');
            traceNumber += rand.Next(1000, 9999);

            return traceNumber;
        }
        public static string TrackNumber(long GateWayId)
        {
            return rand.Next(1000000, 9999999) + GateWayId.ToString() + rand.Next(1000000, 9999999);
        }
        public static string GenerateToken(int length)
        {
            return GenerateToken(Alphabet, length);
        }

        public static string GenerateToken(string characters, int length)
        {
            return new string(Enumerable
              .Range(0, length)
              .Select(num => characters[rand.Next() % characters.Length])
              .ToArray());
        }

        public static string GenerateHash(string text)
        {
            using (var hash = SHA256.Create())
            {
                string result = Convert.ToBase64String(hash.ComputeHash(Encoding.UTF8.GetBytes(text)));
                result = result.Replace("/", ""); result = result.Replace("+", ""); result = result.Replace("%", ""); result = result.Replace("?", "");
                return result;
            }
        }
        public static string ConvertDate(DateTime LatinTime)
        {
            try
            {
                PersianCalendar jc = new PersianCalendar();
                DateTime thisDate = LatinTime;

                string day;
                string month;
                string year;
                string newdate = "";
                day = jc.GetDayOfMonth(thisDate).ToString();
                month = jc.GetMonth(thisDate).ToString();
                year = jc.GetYear(thisDate).ToString();
                if (int.Parse(day) < 10)
                    day = "0" + day;
                if (int.Parse(month) < 10)
                    month = "0" + month;
                newdate = year + "/" + month + "/" + day;
                return newdate;
            }
            catch { return ""; }
        }
        public static string Bankrecogntion(string CartNumber)
        {
            try
            {
                switch (CartNumber)
                {
                    case "603799":
                        return "BMI";
                        break;
                    case "603769":
                        return "BSI";
                        break;
                    case "603770":
                        return "BKI";
                        break;
                    case "589210":
                        return "BSP";
                        break;
                    case "627648":
                        return "BTS";
                        break;
                    case "505416":
                        return "GAR";
                        break;
                    case "610433":
                        return "MEL";
                        break;
                    case "627961":
                        return "BSM";
                        break;
                    case "628023":
                        return "BMK";
                        break;
                    case "627760":
                        return "PST";
                        break;
                    case "502908":
                        return "BTT";
                        break;
                    case "621986":
                        return "SAM";
                        break;
                    case "502806":
                        return "SHR";
                        break;
                    case "589463":
                        return "REF";
                        break;
                    case "627354":
                        return "TEJ";
                        break;
                    case "639347":
                        return "PAS";
                        break;
                    case "622106":
                        return "PAR";
                        break;
                    case "627412":
                        return "ENB";
                        break;
                    case "627488":
                        return "BKA";
                        break;
                    case "639346":
                        return "SIN";
                        break;
                    case "639607":
                        return "SAR";
                        break;
                    case "627381":
                        return "ANS";
                        break;
                    case "505785":
                        return "IRZ";
                        break;
                    case "606373":
                        return "MHR";
                        break;
                    case "639194":
                        return "PAR";
                        break;
                    case "627884":
                        return "PAR";
                        break;
                    case "502229":
                        return "PAS";
                        break;
                    case "636795":
                        return "CBI";
                        break;
                    case "991975":
                        return "MEL";
                        break;
                    case "636949":
                        return "HEK";
                        break;
                    case "502938":
                        return "DEY";
                        break;
                    case "502910":
                        return "BKA";
                        break;
                    case "639217":
                        return "BKV";
                        break;
                    case "639599":
                        return "GHA";
                        break;
                    case "639370":
                        return "MEH";
                        break;
                    case "505801":
                        return "KSAC";
                        break;
                    case "628157":
                        return "MET";
                        break;
                    case "207177":
                        return "BTS";
                    case "636214":
                        return "TAT";
                        break;
                    case "507677":
                        return "NOR";
                        break;
                    default:
                        return "";
                        break;
                }
            }
            catch { return ""; }
        }
        public static string GTTN()
        {
            var traceNumber = DateTime.Now.TimeOfDay.TotalMilliseconds.ToString().Substring(DateTime.Now.TimeOfDay.TotalMilliseconds.ToString().Length - 4);
            traceNumber += rand.Next(1000, 9999);
            traceNumber += new PersianCalendar().GetDayOfMonth(DateTime.Now).ToString().PadLeft(2, '0');
            traceNumber += rand.Next(1000, 9999);

            return traceNumber;
        }
    }
}
