using Microsoft.AspNetCore.Mvc;
using Pizzeria.Models;
using Pizzeria.Services;
using System.Collections.Generic;

namespace Pizzeria.Controllers
{
    public class WorkersController : Controller
    {
        private readonly ApplicationDbContext _db;

        public WorkersController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Worker> objCategoryList = _db.Workers;
            return View(objCategoryList);
        }

        
    }
}
