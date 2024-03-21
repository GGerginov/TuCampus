using DataLayer.Models.Others;
using DataLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TuCampus.Commands;
using TuCampus.Services;
using TuCampus.ViewModels.Users;

namespace TuCampus.ViewModels.Welcome
{
    public class WelcomeStudentDashboardViewModel : ViewModelBase
    {
        private readonly UserViewModel _userViewModel;

        public UserViewModel UserViewModel => _userViewModel;
        public ICommand LogoutCommand { get; }

        public ICommand ShowMyCourses { get; }
        public UserRoleEnum Role => _userViewModel.Role;

        public bool IsAdmin => false;
        public bool IsTeacher => false; 
        public bool IsStudent => true;



        public WelcomeStudentDashboardViewModel(UserViewModel userViewModel, NavigationService _navigationService)
        {
            LogoutCommand = new NavigateCommand(_navigationService, new LoginViewModel(_navigationService));
            _userViewModel = userViewModel;
            ShowMyCourses = new ShowCoursesForStudentCommand(_userViewModel, _navigationService);
        }
    }
}
