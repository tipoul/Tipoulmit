using Microsoft.AspNetCore.Mvc;

namespace Tipoul.UserPanel.WebUI.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
