using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models.Others;

namespace DataLayer.Model
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string FacultyNumber { get; set; }

        public UserRoleEnum Role { get; set; }

        public User(string firstName, string lastName, string email, string facultyNumber, UserRoleEnum role)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            FacultyNumber = facultyNumber;
            Role = role;
        }

      public User()
        {
      } 



    }
}
