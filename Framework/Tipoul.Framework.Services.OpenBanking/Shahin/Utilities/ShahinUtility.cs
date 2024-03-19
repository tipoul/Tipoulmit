using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Tipoul.Framework.Services.OpenBanking.Shahin.Utilities
{
    public static class ShahinUtility
    {
        public static long MillisecondsTimestamp()
        {
            DateTime baseDate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return (long)(DateTime.Now.ToUniversalTime() - baseDate).TotalMilliseconds;
        }
        public static byte[] ToHash256(string text)
        {
            Encoding enc = Encoding.UTF8;
            using var hash = SHA256.Create();
            return hash.ComputeHash(enc.GetBytes(text));
        }
        public static string ToHex(byte[] bytes)
        {
            var hashBuilder = new StringBuilder();
            foreach (var b in bytes)
                hashBuilder.Append(b.ToString("X2"));
            return hashBuilder.ToString();
        }
        public static string ToHmacSHA256(byte[] salt, string plaintext)
        {
            string result = "";
            var enc = Encoding.Default;
            byte[] baText2BeHashed = enc.GetBytes(plaintext);
            System.Security.Cryptography.HMACSHA256 hasher = new HMACSHA256(salt);
            byte[] baHashedText = hasher.ComputeHash(baText2BeHashed);
            result = string.Join("", baHashedText.ToList().Select(b => b.ToString("x2")).ToArray());
            return result;
        }
        public static string CalcOBHSignature(string HTTPRequestMethod, string ApiUrl, HttpRequestHeaders RequestHeaders,
            string RequestPayload, string Shahin_UserName, string Shahin_Password)
        {
            RequestPayload = RequestPayload.Replace("\"", "");
            RequestPayload = RequestPayload.Replace(":", "=");
            string CanonicalURI = new Uri(ApiUrl).AbsolutePath;
            Dictionary<string, string> headers = new Dictionary<string, string>();
            foreach (var item in RequestHeaders)
            {
                headers.Add(item.Key.ToLower(), ((string[])item.Value)[0].Trim());
            }
            var sortedHeaders = from entry in headers orderby entry.Key ascending select entry;
            string CanonicalHeaders = "";
            string SignedHeaders = "";
            foreach (var item in sortedHeaders)
            {
                CanonicalHeaders += item.Key.ToLower() + ":" + item.Value.Trim() + "\n";
                SignedHeaders += item.Key.ToLower();
                if (sortedHeaders.ToList().IndexOf(item) < sortedHeaders.Count() - 1)
                    SignedHeaders += ";";
            }
            string payloadHash = ToHex(ToHash256(RequestPayload));
            string canonicalRequest = HTTPRequestMethod.ToUpper() + "\n"
                                        + CanonicalURI + '\n'
                                        + CanonicalHeaders + '\n'
                                        + SignedHeaders + '\n'
                                        + payloadHash;
            string stringToSign = ToHex(ToHash256(canonicalRequest));
            byte[] key = ToHash256(DateTime.Now.Year + Shahin_UserName + Shahin_Password);
            HMACSHA256 hmac = new HMACSHA256(key);
            string signature = ToHex(hmac.ComputeHash(Encoding.UTF8.GetBytes(stringToSign)));
            return "OBH1-HMAC-SHA256;SignedHeaders=" + SignedHeaders.Replace(";", ",") + ";Signature=" + signature;
        }
    }
}
