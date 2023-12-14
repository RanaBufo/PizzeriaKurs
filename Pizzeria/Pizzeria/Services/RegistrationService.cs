using Pizzeria.Models;

namespace Pizzeria.Services
{
    public class RegistrationService
    {
        private readonly ApplicationDbContext _db;
        public RegistrationService(ApplicationDbContext db)
        {
            _db = db;
        }

        public string FindIdWorker()
        {
            List<Worker> workers = _db.Workers.ToList();
            string maxId;
            if (workers.Count > 0)
            {
                maxId = "WR" + (int.Parse(workers[^1].IDWorker.Substring(2)) + 1).ToString();
            }
            else  maxId = "WR1";
            return maxId;
        }

        public void AddWorker(RegistrationInfo registrationInfo)
        {
            var newWorker = new Worker
            {
                IDWorker = FindIdWorker(),
                WorkerName = char.ToUpper(registrationInfo.WorkerName[0]) + registrationInfo.WorkerName.Substring(1),
                WorkerSurname = char.ToUpper(registrationInfo.WorkerSurname[0]) + registrationInfo.WorkerSurname.Substring(1),
                WorkerPhone = char.ToUpper(registrationInfo.WorkerPhone[0]) + registrationInfo.WorkerPhone.Substring(1),
                WorkerEmail = registrationInfo.WorkerEmail,
                WorkerPost = char.ToUpper(registrationInfo.WorkerPost[0]) + registrationInfo.WorkerPost.Substring(1),
                WorkerPassword = registrationInfo.WorkerPassword

            };
            _db.Workers.Add(newWorker);
            _db.SaveChanges();
        }

    }
}
 