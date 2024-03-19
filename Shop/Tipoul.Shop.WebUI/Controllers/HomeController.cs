using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Tipoul.Shop.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private static readonly Random rand = new Random(DateTime.Now.Millisecond);

        [HttpGet("/iranzamin")]
        public IActionResult Iranzamin()
        {
            return View();
        }

        [HttpPost("/iranzamin")]
        public IActionResult Iranzamin([FromServices] IWebHostEnvironment webHostEnvironment, [FromForm] string[] products)
        {
            var path = webHostEnvironment.ContentRootPath + "/orders/iranzamin/";

            var fileName = DateTime.Now.ToFileTime().ToString();

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            System.IO.File.AppendAllLines(path + fileName + ".txt", products);

            var amount = products.Sum(f => int.Parse(f.Split('-')[0]));

            amount *= 213;

            return Redirect("https://tipoul.com/iranzamin/" + rand.Next(1000, 9999) + "/" + fileName + "/" + amount);
        }

        [HttpGet("/irallstar")]
        public IActionResult Irallstar()
        {
            return View();
        }

        [HttpPost("/irallstar")]
        public IActionResult Irallstar([FromServices] IWebHostEnvironment webHostEnvironment, [FromForm] string[] products)
        {
            var path = webHostEnvironment.ContentRootPath + "/orders/irallstar/";

            var fileName = DateTime.Now.ToFileTime().ToString();

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            System.IO.File.AppendAllLines(path + fileName + ".txt", products);

            var amount = products.Sum(f => int.Parse(f.Split('-')[0]));

            amount *= 213;

            return Redirect("https://tipoul.com/irallstar/" + rand.Next(1000, 9999) + "/" + fileName + "/" + amount);
        }
    }
}
