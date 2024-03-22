using System.Windows.Input;
using TuCampus.Services.CoursesService;
using TuCampus.ViewModels.Users;

namespace TuCampus.Commands
{
    internal class AddNewUserCommand : CommandBase
    {
        public AddNewUsersViewModel AddNewUsersViewModel { get; set; }
        public IUsersService UsersService { get; set; }

        public AddNewUserCommand(AddNewUsersViewModel addNewUsersViewModel)
        {
            AddNewUsersViewModel = addNewUsersViewModel;
            UsersService = new UsersService();
        }
 
        public override void Execute(object parameter)
        {
            UsersService.AddUser(AddNewUsersViewModel.Username, AddNewUsersViewModel.Password, AddNewUsersViewModel.Email, AddNewUsersViewModel.FacultyNumber);

        }
    }
}