using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pizzeria.Models;
using Pizzeria.Services;

namespace Pizzeria.Controllers
{
    public class EditWorkerController : Controller
    {
        private readonly ApplicationDbContext _db;
        static WorkerDbService _workerDbService { get; set; }
        public ValidService _validService { get; set; }
        public ValidModelService _validModelService { get; set; }
        public EditWorkerController(ApplicationDbContext db)
        {
            _db = db;
            _validService = new ValidService();
            _workerDbService = new WorkerDbService(_db);
            _validModelService = new ValidModelService();
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult ToEditWorker(string workerId)
        {
            var workerToEdit = _workerDbService.GetWorker(workerId);
            return View("Index", workerToEdit);
        }

        [HttpPost]
        [ActionName("ToEditWorkerByObject")]
        public IActionResult ToEditWorker(Worker worker)
        {
            if (!_validModelService.ValidWorkerModel(worker, ModelState))
            {
                return View("Index", worker);
            }
            
               var workerToEdit = _db.Workers.Find(worker.IDWorker);
                workerToEdit.WorkerName = worker.WorkerName;
                workerToEdit.WorkerSurname = worker.WorkerSurname;
                workerToEdit.WorkerPhone = worker.WorkerPhone;
                workerToEdit.WorkerPost = worker.WorkerPost;
                workerToEdit.WorkerEmail = worker.WorkerEmail;
                _db.SaveChanges();
                return Redirect("/Workers/Index");
            
            
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
            return Redirect("/Workers/Index");
        }
    }
}
