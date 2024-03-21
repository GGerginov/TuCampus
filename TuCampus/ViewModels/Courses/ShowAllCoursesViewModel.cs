using DataLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TuCampus.Commands;
using TuCampus.ViewModels.Users;
using TuCampus.ViewModels.Welcome;

namespace TuCampus.ViewModels.Courses
{
    public class ShowAllCoursesViewModel:ViewModelBase
    {
        public UserViewModel UserViewModel { get; set; }
        public NavigationService NavigationService { get; set; }
        public List<CourseViewModel> Courses { get; set; }
        public ICommand RetundCommand { get; }

        public ShowAllCoursesViewModel(UserViewModel userViewModel, List<CourseViewModel> courses,NavigationService _navigationService)
        {
            Courses = courses;
            NavigationService = _navigationService;                 
            UserViewModel = userViewModel;
            RetundCommand = new NavigateCommand(NavigationService,new WelcomeStudentDashboardViewModel(userViewModel,NavigationService));
        }       
    }
}
