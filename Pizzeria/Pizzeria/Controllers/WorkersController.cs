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

        [HttpPost]
        public IActionResult DeleteWorker(string workerId)
        {
            if (!string.IsNullOrEmpty(workerId))
            {
                var workerToDelete = _db.Workers.Find(workerId);
                if (workerToDelete != null)
                {
                    _db.Workers.Remove(workerToDelete);
                    _db.SaveChanges();
                }
            }
            else
            {
                // В случае отсутствия работника с указанным ID, возможно, вы захотите вернуть ошибку
                return BadRequest("Worker not found");
            }

            // Если deleteAction не задан, выполните другие действия (если необходимо)
            // ...

            // После выполнения других действий перенаправьтесь обратно на страницу с таблицей
            return RedirectToAction("Index");
        }
    }
}
