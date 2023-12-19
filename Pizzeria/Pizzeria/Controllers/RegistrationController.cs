using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;
using Pizzeria.Models;
using Pizzeria.Services;

namespace Pizzeria.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly EmailMassageService _emailMassageService;
        public RegistrationInfo registrationInfo { get; set; }
        public ValidModelService _validModelService { get; set; }

        public RegistrationService _registrationService { get; set; }
        public RegistrationController(ApplicationDbContext db)
        {
            _db = db;
            _registrationService = new RegistrationService(db);
            _validModelService = new ValidModelService(db);
             _emailMassageService = new EmailMassageService();
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [ActionName("NewIndex")]
        public IActionResult Index(RegistrationInfo registrationInfo)
        {
            if (!_validModelService.ValidRegistrationInfoModel(registrationInfo, ModelState))
            {
                return View("Index",registrationInfo);
            }

            _emailMassageService.SendEmail(registrationInfo.WorkerEmail, registrationInfo.WorkerName, "Ура!!", "Поздравляю вас приняли на работу!");
            _registrationService.AddWorker(registrationInfo);
            
            return Redirect("/Workers/Index");
            
            
        }



    }
}
