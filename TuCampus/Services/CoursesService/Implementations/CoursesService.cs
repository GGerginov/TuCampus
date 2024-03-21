using DataLayer.DbContexts;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuCampus.Services.CoursesService
{
    public class CoursesService : ICoursesService
    {
     
        public List<Course> GetCourses()
        {
            using (var ctx = new TuCampusDbContext())
            {
                ctx.Database.EnsureCreated();
                var courses = ctx.Courses.ToList();
                return courses;
            }

        }

        public List<Course> GetCoursesByStudentId(int studentId)
        {
            using (var ctx = new TuCampusDbContext())
            {
                ctx.Database.EnsureCreated();
                var courses = from uc in ctx.UserCourses
                              join c in ctx.Courses on uc.CourseId equals c.Id
                              where uc.UserId == studentId
                              select c;
                return courses.ToList();
            }
        }
    }
}
