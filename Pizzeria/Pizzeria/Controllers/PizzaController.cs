using Microsoft.AspNetCore.Mvc;
using Pizzeria.Models;

namespace Pizzeria.Controllers
{
    public class PizzaController : Controller
    {
        private readonly ApplicationDbContext _db;
        public PizzaController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Pizza> objCategoryList = _db.Pizzas;
            return View(objCategoryList);
        }
    }
}
