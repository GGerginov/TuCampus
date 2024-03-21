// See https://aka.ms/new-console-template for more information
using DataLayer.DbContexts;
using DataLayer.Model;
using DataLayer.Models;
using DataLayer.Models.Others;

Console.WriteLine("Hello, World!");

using(var context = new TuCampusDbContext())
{
    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();
    var newUser = new User()
    {
        Id = 100,
        Username = "Admin",
        Password = "123456",
        FacultyNumber = "121221190",
        Email = "user@abv.bg",
        Role = UserRoleEnum.Admin
    };


    context.Add<User>(newUser);
    
    context.Add<Course>((new Course()
    {
        Id = 1,
        SubjectName = "Math",
        RoomNumber = "123",
        Teacher = newUser,
        students = new List<User>() 
    }));
    context.SaveChanges();
}