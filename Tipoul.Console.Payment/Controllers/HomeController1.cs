using Microsoft.AspNetCore.Mvc;

namespace Tipoul.Console.Payment.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
