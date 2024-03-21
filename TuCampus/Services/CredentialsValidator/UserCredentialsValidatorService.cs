using DataLayer.DbContexts;
using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Services.CredentialsValidator
{
    public class UserCredentialsValidatorService : ICredentialsValidatorService
    {
        public User GetUser(string username, string password)
        {
            using (var ctx = new TuCampusDbContext())
            {
                var user = ctx.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
                return user;
            }
        }
    }
}
