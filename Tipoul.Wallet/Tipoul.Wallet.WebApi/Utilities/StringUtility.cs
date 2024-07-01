using System.Text;

namespace Tipoul.Wallet.WebApi.Utilities
{
    public static class StringUtility
    {
        public static string Zip(string str)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(str));
        }

        public static string Unzip(string str)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(str));
        }
    }
}
