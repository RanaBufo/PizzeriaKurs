using Microsoft.AspNetCore.Mvc.ModelBinding;
using Pizzeria.Models;

namespace Pizzeria.Services
{
    public class ValidModelService
    {
        private ValidService _validService = new ValidService();

        public ValidModelService()
        {
            
        }

        public bool ValidWorkerModel(Worker worker, ModelStateDictionary modelState)
        {
            bool index = true;
            
                if (worker.WorkerName!= null && !_validService.IsValidName(worker.WorkerName))
                {
                    modelState.AddModelError("WorkerName", "The name must adhere to certain rules.");
                    index = false;
                }
                if (worker.WorkerSurname != null && !_validService.IsValidSurname(worker.WorkerSurname))
                {
                    modelState.AddModelError("WorkerSurname", "The surname must adhere to certain rules.");
                    index = false;
                }
                if (worker.WorkerName != null && worker.WorkerPhone != null && !_validService.IsValidPhone(worker.WorkerPhone))
                {
                    modelState.AddModelError("WorkerPhone", "Invalid data format.");
                    index = false;
                }
                if (worker.WorkerEmail != null && !_validService.IsValidEmail(worker.WorkerEmail))
                {
                    modelState.AddModelError("WorkerEmail", "Invalid data format.");
                    index = false;
                }
                if (worker.WorkerPost != null && !_validService.IsValidPost(worker.WorkerPost))
                {
                    modelState.AddModelError("WorkerPost", "The post must adhere to certain rules.");
                    index = false;
                }
                if (worker.WorkerPost != null && !_validService.IsValidPassword(worker.WorkerPassword))
                {
                    modelState.AddModelError("WorkerPost", "Invalid data format");
                    index = false;
                }
            


            return index;
           
        }
        public bool ValidRegistrationInfoModel(RegistrationInfo registrationInfo, ModelStateDictionary modelState)
        {
            bool index = true;

            if (registrationInfo.WorkerName != null && !_validService.IsValidName(registrationInfo.WorkerName))
            {
                modelState.AddModelError("WorkerName", "The name must adhere to certain rules.");
                index = false;
            }
            if (registrationInfo.WorkerSurname != null && !_validService.IsValidSurname(registrationInfo.WorkerSurname))
            {
                modelState.AddModelError("WorkerSurname", "The surname must adhere to certain rules.");
                index = false;
            }
            if (registrationInfo.WorkerName != null && registrationInfo.WorkerPhone != null && !_validService.IsValidPhone(registrationInfo.WorkerPhone))
            {
                modelState.AddModelError("WorkerPhone", "Invalid data format.");
                index = false;
            }
            if (registrationInfo.WorkerEmail != null && !_validService.IsValidEmail(registrationInfo.WorkerEmail))
            {
                modelState.AddModelError("WorkerEmail", "Invalid data format.");
                index = false;
            }
            if (registrationInfo.WorkerPost != null && !_validService.IsValidPost(registrationInfo.WorkerPost))
            {
                modelState.AddModelError("WorkerPost", "The post must adhere to certain rules.");
                index = false;
            }
            if (registrationInfo.WorkerPost != null && !_validService.IsValidPassword(registrationInfo.WorkerPassword))
            {
                modelState.AddModelError("WorkerPost", "Invalid data format");
                index = false;
            }
            if (!_validService.IsValidPassword(registrationInfo.WorkerDuplicatePassword))
            {
                modelState.AddModelError("WorkerDuplicatePassword", "Passwords do not match.");
                index = false;
            }


            return index;

        }
    }
}