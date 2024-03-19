using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Tipoul.Athentication.Agent.Services;

namespace Tipoul.AdminPanel.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private const string SessionKey = "LoginRedirectUrl";

        private readonly IConfiguration configuration;

        public LoginController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // [AllowAnonymous]
        public IActionResult Index(string redirectUrl)
        {
           
            if (string.IsNullOrWhiteSpace(redirectUrl))
                redirectUrl = "/";

            HttpContext.Session.SetString(SessionKey, redirectUrl);

            return Redirect($"{configuration["AthenticationUrl"]}/login?redirectUrl={Request.Scheme}://{Request.Host}/login");
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Index([FromServices] AthenticationProvider athenticationProvider, [FromForm] string token)
        {
            athenticationProvider.SetToken(token);

            var redirectUrl = HttpContext.Session.GetString(SessionKey);

            return Redirect(redirectUrl ?? "/");
        }
    }
}
