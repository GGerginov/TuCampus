using DataLayer.Model;
using DataLayer.Models.Others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuCampus.ViewModels.Users
{
    public class UserViewModel
    {
        private readonly User _user;

        public int Id => _user.Id;

        public string Username => _user.Username;
        public string Password => _user.Password;

        public string Email => _user.Email;

        public string FacultyNumber => _user.FacultyNumber;

        public UserRoleEnum Role => _user.Role;

        public bool IsAdmin => _user.Role == UserRoleEnum.Admin;

        public bool IsTeacher => _user.Role == UserRoleEnum.Teacher;

        public UserViewModel(User user)
        {
            _user = user;
        }
    }
}
