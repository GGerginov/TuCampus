using DataLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using TuCampus.ViewModels.Users;

namespace TuCampus.ViewModels.Courses
{
    public class ShowAllCoursesViewModel:ViewModelBase
    {
        public UserViewModel UserViewModel { get; set; }
        public NavigationService NavigationService { get; set; }
        public List<CourseViewModel> Courses { get; set; }

        public ShowAllCoursesViewModel(UserViewModel userViewModel, List<CourseViewModel> courses,NavigationService _navigationService)
        {
            Courses = courses;
            NavigationService = _navigationService;                 
            UserViewModel = userViewModel;
        }       
    }
}
