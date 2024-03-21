using DataLayer.DbContexts;
using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuCampus.Services.CoursesService
{
    class UsersService : IUsersService
    {
        public List<User> GetAllUsers()
        {
            using (var ctx = new TuCampusDbContext())
            {
                ctx.Database.EnsureCreated();
                var users = ctx.Users.ToList();
                return users;
            }
        }
    }
}
