using Microsoft.AspNetCore.Mvc;

namespace Pizzeria.Controllers
{
    public class LalalaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
