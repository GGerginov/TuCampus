using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuCampus.Services.CoursesService
{
    interface IUsersService
    {
        void AddUser(string username, string password, string email, string facultyNumber);
        List<User> GetAllUsers();
    }
}
