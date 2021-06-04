using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cactus.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace cactus.DataAccess.Services
{
    public class UserService
    {
        public async Task<List<User>> GetUsers()
        {
            using (var dbContext = new cactusDbContext())
            {
                return await dbContext.Users.ToListAsync();
            }
        }
        public async Task<User> GetUserById(int userId)
        {
            using (var dbContext = new cactusDbContext())
            {
                return await dbContext.Users.FindAsync(userId);
            }
        }
        public  User GetUser(string email, string password)
        {
            using (var dbContext = new cactusDbContext())
            {
                return dbContext.Users.Where(u => u.email == email && u.password == password).FirstOrDefault();
            }
        }
        public async Task<User> CreateUser(User user)
        {
            using (var dbContext = new cactusDbContext())
            {
                dbContext.Users.Add(user);
                await dbContext.SaveChangesAsync();
                return user;
            }
        }

    }
}
