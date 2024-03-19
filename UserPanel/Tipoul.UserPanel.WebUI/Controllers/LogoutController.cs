using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Tipoul.Athentication.Agent.Services;

namespace Tipoul.UserPanel.WebUI.Controllers
{
    public class LogoutController : Controller
    {
        public IActionResult Index([FromServices]AthenticationProvider athenticationProvider)
        {
            athenticationProvider.ClearToken();

            return Redirect("/");
        }
    }
}
