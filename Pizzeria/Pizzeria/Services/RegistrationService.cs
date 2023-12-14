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

    }
}
 