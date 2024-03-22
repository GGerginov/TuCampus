using DataLayer.DbContexts;
using DataLayer.Model;
using DataLayer.Models.Others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuCampus.Services.CoursesService
{
    class UsersService : IUsersService
    {
        public void AddUser(string username, string password, string email, string facultyNumber)
        {
            using (var ctx = new TuCampusDbContext())
            {
                ctx.Database.EnsureCreated();

                ctx.Users.Add(new User(username, password, email, facultyNumber, UserRoleEnum.Student));
                ctx.SaveChanges();
            }
        }

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
