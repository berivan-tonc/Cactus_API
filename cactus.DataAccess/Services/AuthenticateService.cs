using cactus.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace cactus.DataAccess.Services
{


    public class AuthenticateService
    {
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications

        public async Task<User> Authenticate(string email, string password)
        {
         //   var user = await Task.Run(() => _users.SingleOrDefault(x => x.Username == username && x.Password == password));

            using (var dbContext = new cactusDbContext())
            {
                //var user =  dbContext.Users.Where(u => u.email == email && u.password == password).SingleOrDefault();
                var user = await Task.Run(() => dbContext.Users.Where(u => u.email == email && u.password == password).SingleOrDefault());
                // return null if user not found
                if (user == null)
                    return null;

                // authentication successful so return user details without password
                // return user.WithoutPassword();
                return user;
            }
        }

    }
}
