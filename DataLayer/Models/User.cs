using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models.Others;

namespace DataLayer.Model
{
    public class User
    {
        public string FirstName { get; }

        public string LastName { get; }

        public string Email { get; }

        public string FacultyNumber { get; }

        public UserRoleEnum Role { get; }

        public User(string firstName, string lastName, string email, string facultyNumber, UserRoleEnum role)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            FacultyNumber = facultyNumber;
            Role = role;
        }   
    }
}
