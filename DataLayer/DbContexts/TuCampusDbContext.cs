using DataLayer.Model;
using DataLayer.Models;
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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string solutionFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string databaseFile = "Welcome.db";
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

            var user = new User()
            {
                Id = 1,
                FirstName = "Georgi",
                LastName = "Georgiev",
                Email = "",
                FacultyNumber = "123456",
                Role = UserRoleEnum.Student
            };



            modelBuilder.Entity<User>().HasData(user);
        }
    }
}
