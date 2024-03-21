using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuCampus.ViewModels;

namespace TuCampus.Services.CoursesService
{
    public interface ICoursesService
    {
        List<Course> GetCourses();

        List<Course> GetCoursesByStudentId(int studentId);
    }
}
