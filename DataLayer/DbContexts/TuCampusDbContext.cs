using DataLayer.Model;
using DataLayer.Models;
using DataLayer.Models.ListModels;
using DataLayer.Models.Others;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DbContexts
{
    public class TuCampusDbContext : DbContext
    {
        public DbSet<UserCourse> UserCourses { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<CourseGradesList> CourseGradesLists { get; set; }

        public DbSet<GradeRecord> GradeRecords { get; set; }

        public DbSet<PresentList> PresentLists { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string solutionFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string databaseFile = "TuCampus.db";
            string databasePath = Path.Combine(solutionFolder, databaseFile);

            optionsBuilder.UseSqlite($"Data Source={databasePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Course>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<CourseGradesList>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<PresentList>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<GradeRecord>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();


            //var user = new User()
            //{
              //  Id = 1,
                //Username = "Admin",
               // Password = "123456",
                //Email = "demo@abv.bg",
                //FacultyNumber = "121221111",
                //Role = UserRoleEnum.Student,
           // };



            //modelBuilder.Entity<User>().HasData(user);
        }
    }
}
