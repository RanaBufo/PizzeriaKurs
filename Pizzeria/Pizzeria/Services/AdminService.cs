using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pizzeria.Models;

namespace Pizzeria.Services
{
    public class AdminService
    {
        private readonly ApplicationDbContext _db;
        public AdminService(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<object> FindByEmailAsync(string email)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.UserEmail == email);

            return user;
        }
    }
}
