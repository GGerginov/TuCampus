using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string SubjectName { get; }

        public string RoomNumber { get; }

        public User Teacher { get; }

        public Course(string subjectName, string roomNumber, User teacher)
        {
            SubjectName = subjectName;
            RoomNumber = roomNumber;
            Teacher = teacher;
        }
    }
}
