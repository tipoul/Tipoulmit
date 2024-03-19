using System.Collections.Generic;

namespace Tipoul.Framework.Services.Shahin.Models
{
    public class GetTokenResult
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public List<string> scope { get; set; }
        public string bank { get; set; }
        public List<string> accounts { get; set; }
        public long mount { get; set; }
        public string user_name { get; set; }
        public string jti { get; set; }
        public long iat { get; set; }
        public long nbf { get; set; }
        public string iss { get; set; }
    }
}
