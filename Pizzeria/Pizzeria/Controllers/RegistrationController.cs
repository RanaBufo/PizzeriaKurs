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
        public ValidModelService _validModelService { get; set; }
        public RegistrationController(ApplicationDbContext db)
        {
            _db = db;
            _registrationService = new RegistrationService(db);
            _validModelService = new ValidModelService();
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Index(RegistrationInfo registrationInfo)
        {
            if (!_validModelService.ValidRegistrationInfoModel(registrationInfo, ModelState))
            {
                return View(registrationInfo);
            }


            _registrationService.AddWorker(registrationInfo);
                  
            return Redirect("/Workers/Index");
            
            
        }



    }
}
