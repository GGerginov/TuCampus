using System.Windows.Input;
using TuCampus.Commands;
using TuCampus.Services;

namespace TuCampus.ViewModels.Users
{
    public class AddNewUsersViewModel : ViewModelBase
    {

        public string Username { get; set; }
        public string Password { get; set; }

        public string Email { get; set; }

        public string FacultyNumber { get; set; }

        public ICommand AddNewUserCommand { get; }

        private NavigationService navigationService;

        public AddNewUsersViewModel(NavigationService navigationService)
        {
            AddNewUserCommand = new AddNewUserCommand(this);
            
            this.navigationService = navigationService;
        }
    }
}