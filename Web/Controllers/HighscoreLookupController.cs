using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class HighscoreLookupController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Process()
        {
            return View();
        }
    }
}