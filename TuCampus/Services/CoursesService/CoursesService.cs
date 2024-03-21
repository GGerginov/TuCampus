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
    }
}
