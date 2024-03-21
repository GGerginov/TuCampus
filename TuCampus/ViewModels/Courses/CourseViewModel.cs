using DataLayer.Model;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuCampus.ViewModels.Courses
{
    public class CourseViewModel
    {
        private readonly Course _course;

        public int Id => _course.Id;

        public string SubjectName => _course.SubjectName;

        public string RoomNumber => _course.RoomNumber;

        public User Teacher => _course.Teacher;

        public List<User> students => _course.students;

        public CourseViewModel(Course course)
        {
            _course = course;
        }
    }
}
