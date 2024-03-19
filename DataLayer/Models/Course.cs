using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Course
    {

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
