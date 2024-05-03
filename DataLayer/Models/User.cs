using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models.Others;
using DataLayer.Models;
using DataLayer.Models.ListModels;

namespace DataLayer.Model
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
       
        public string Username { get; set; }
        public string Password { get; set; }

        public string Email { get; set; }

        public string FacultyNumber { get; set; }
        public List<PresentList> OrganizedPresentLists { get; set; }

        public UserRoleEnum Role { get; set; }

        public User(string userName,string password ,string email, string facultyNumber, UserRoleEnum role)
        {   
            Username = userName;
            Password = password;
            Email = email;
            FacultyNumber = facultyNumber;
            Role = role;
        }

      public User()
        {
      } 



    }
}
