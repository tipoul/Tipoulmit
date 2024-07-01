using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using Tipoul.Console.Payment.Models;
using Tipoul.Console.WebApi.Data;
using Tipoul.Shaparak.Services.Data;

namespace Tipoul.Console.Payment.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private ConsoleContext _consolecontext;
        public HomeController(ConsoleContext consolecontext, IConfiguration iConfig, IHttpContextAccessor contextAccessor)
        {
            _consolecontext = consolecontext;
            _contextAccessor = contextAccessor;
        }
        //https://localhost:7218/home/start/?token=mina
        [HttpGet]
        public async Task start([FromQuery] string  token)
        {
          
            string IPGToken = "";
            var Objs = _consolecontext.Request.FirstOrDefault(r=>r.HashedToken== token);
            if (Objs != null)
            {
                IPGToken = Objs.IPGToken;
                var responseBody =
              "<html>" +
              "   <body onload='document.forms[0].submit()'>" +
              $"       <form method='post' action='{"https://bpm.shaparak.ir/pgwchannel/startpay.mellat"}'>" +
              $"       <input type='hidden' name='RefId' value='{IPGToken}' />" +
           "        </form" +
           "   </body>" +
              "</html>";

                await _contextAccessor.HttpContext.Response.WriteAsync(responseBody);
            }
           

        }
    }
}