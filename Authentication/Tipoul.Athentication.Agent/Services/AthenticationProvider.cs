using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using Tipoul.Athentication.Agent.Models;
using Tipoul.Athentication.Agent.Utility;

namespace Tipoul.Athentication.Agent.Services
{
    public class AthenticationProvider
    {
        private const string TokenSessionKey = "AthenticationTokenKey";

        private readonly IConfiguration configuration;

        private readonly IHttpContextAccessor httpContextAccessor;

        public AthenticationProvider(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            this.configuration = configuration;
            this.httpContextAccessor = httpContextAccessor;
        }

        public void SetToken(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
                throw new ArgumentNullException(nameof(token));

            httpContextAccessor.HttpContext.Session.SetString(TokenSessionKey, token);
            httpContextAccessor.HttpContext.Response.Cookies.Append(TokenSessionKey, token, new CookieOptions { MaxAge = TimeSpan.FromDays(1) });
        }

        public void ClearToken()
        {
            httpContextAccessor.HttpContext.Session.Remove(TokenSessionKey);
            httpContextAccessor.HttpContext.Response.Cookies.Delete(TokenSessionKey);
        }

        public bool HasToken()
        {
            return httpContextAccessor.HttpContext.Session.GetString(TokenSessionKey) != null || httpContextAccessor.HttpContext.Request.Cookies.ContainsKey(TokenSessionKey);
        }

        public User? GetUser()
        {
            return JsonSerializer.Deserialize<User>(StringUtility.Unzip(httpContextAccessor.HttpContext.Session.GetString(TokenSessionKey) ?? httpContextAccessor.HttpContext.Request.Cookies[TokenSessionKey]));
        }
    }
}
