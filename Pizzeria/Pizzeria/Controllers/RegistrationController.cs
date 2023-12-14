using Microsoft.AspNetCore.Mvc;
using Pizzeria.Models;
using Pizzeria.Services;

namespace Pizzeria.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly ApplicationDbContext _db;
        public RegistrationInfo registrationInfo { get; set; }
        public RegistrationService _registrationService { get; set; }
        public ValidService _validService { get; set; }
        public RegistrationController(ApplicationDbContext db)
        {
            _db = db;
            _registrationService = new RegistrationService(db);
            _validService = new ValidService();
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Index(RegistrationInfo registrationInfo)
        {
            if (!_validService.IsValidName(registrationInfo.WorkerName))
            {
                ModelState.AddModelError("WorkerName", "The name must adhere to certain rules.");
            }
            if (!_validService.IsValidSurname(registrationInfo.WorkerSurname))
            {
                ModelState.AddModelError("WorkerSurname", "The surname must adhere to certain rules.");
            }
            if (!_validService.IsValidPhone(registrationInfo.WorkerPhone))
            {
                ModelState.AddModelError("WorkerPhone", "Invalid data format.");
            }
            if (!_validService.IsValidEmail(registrationInfo.WorkerEmail))
            {
                ModelState.AddModelError("WorkerEmail", "Invalid data format.");
            }
            if (!_validService.IsValidName(registrationInfo.WorkerPost))
            {
                ModelState.AddModelError("WorkerPost", "The post must adhere to certain rules.");
            }
            if (!_validService.IsValidPassword(registrationInfo.WorkerPassword))
            {
                ModelState.AddModelError("WorkerPassword", "Invalid data format.");
            }
            if (!_validService.IsValidPassword(registrationInfo.WorkerDuplicatePassword))
            {
                ModelState.AddModelError("WorkerDuplicatePassword", "Passwords do not match.");
            }

            if (ModelState.IsValid)
            {
                var newWorker = new Worker
                {
                    IDWorker = _registrationService.FindIdWorker(),
                    WorkerName = char.ToUpper(registrationInfo.WorkerName[0]) + registrationInfo.WorkerName.Substring(1),
                    WorkerSurname = char.ToUpper(registrationInfo.WorkerSurname[0]) + registrationInfo.WorkerSurname.Substring(1),
                    WorkerPhone = char.ToUpper(registrationInfo.WorkerPhone[0]) + registrationInfo.WorkerPhone.Substring(1),
                    WorkerEmail = registrationInfo.WorkerEmail,
                    WorkerPost = char.ToUpper(registrationInfo.WorkerPost[0]) + registrationInfo.WorkerPost.Substring(1),
                    WorkerPassword = registrationInfo.WorkerPassword

                };
                _db.Workers.Add(newWorker);
                _db.SaveChanges();

                return Redirect("/Workers/Index");
            }

            // Если ModelState.IsValid == false, значит есть ошибки валидации
            // Возвращаем пользователя на ту же страницу с сообщением об ошибке
            return View(registrationInfo);
        }



    }
}
