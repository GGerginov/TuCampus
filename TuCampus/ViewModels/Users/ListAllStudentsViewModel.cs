using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TuCampus.Commands;
using TuCampus.Services;
using TuCampus.ViewModels.Courses;
using TuCampus.ViewModels.Welcome;

namespace TuCampus.ViewModels.Users
{
    public class ListAllStudentsViewModel : ViewModelBase
    {
        public List<UserViewModel> Users { get; set; }
        public NavigationService NavigationService { get; set; }

        public ICommand ReturnCommand { get; }

        public ListAllStudentsViewModel(UserViewModel userViewModel, List<UserViewModel> users, NavigationService _navigationService)
        {
            Users = users;
            NavigationService = _navigationService;

            switch (userViewModel.Role.ToString().ToUpper())
            {
                case "ADMIN":
                    ReturnCommand = new NavigateCommand(NavigationService, new WelcomeAdminDashboardViewModel(userViewModel, NavigationService));
                    break;
                case "TEACHER":
                    ReturnCommand = new NavigateCommand(NavigationService, new WelcomeTeacherDashboardViewModel(userViewModel, NavigationService));
                    break;
                case "STUDENT":
                    ReturnCommand = new NavigateCommand(NavigationService, new WelcomeStudentDashboardViewModel(userViewModel, NavigationService));
                    break;
            }
        }   
    }
}
