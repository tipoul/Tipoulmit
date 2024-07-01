using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;

namespace Wallet.Hub.WebApi.Utilities
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
                string result= Convert.ToBase64String(hash.ComputeHash(Encoding.UTF8.GetBytes(text)));
                result=result.Replace("/",""); result = result.Replace("+", ""); result = result.Replace("%", ""); result = result.Replace("?", "");
                return result;
            }
        }
    }
}
