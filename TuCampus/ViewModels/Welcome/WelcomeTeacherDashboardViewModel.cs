using DataLayer.Models.Others;
using DataLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TuCampus.Commands;
using TuCampus.ViewModels.Users;

namespace TuCampus.ViewModels.Welcome
{
    public class WelcomeTeacherDashboardViewModel:ViewModelBase
    {
        private readonly UserViewModel _userViewModel;

        public ICommand LogoutCommand { get; }

        public UserViewModel UserViewModel => _userViewModel;
        public ICommand ShowCourses { get; }

        public UserRoleEnum Role => _userViewModel.Role;
        public bool IsAdmin => false;
        public bool IsTeacher => true;
        public bool IsStudent => false;
        public WelcomeTeacherDashboardViewModel(UserViewModel userViewModel, NavigationService _navigationService)
        {
            _userViewModel = userViewModel;
            ShowCourses = new ShowAllCoursesCommand(_userViewModel, _navigationService);
            LogoutCommand = new NavigateCommand(_navigationService, new LoginViewModel(_navigationService));
        }
    }
}
