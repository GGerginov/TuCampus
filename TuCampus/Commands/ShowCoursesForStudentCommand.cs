using DataLayer.Models;
using DataLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using TuCampus.Services.CoursesService;
using TuCampus.ViewModels.Courses;
using TuCampus.ViewModels.Users;
using TuCampus.Services;
using NavigationService = TuCampus.Services.NavigationService;

namespace TuCampus.Commands
{
    internal class ShowCoursesForStudentCommand : CommandBase
    {
        private readonly NavigationService _navigationService;
        private UserViewModel userViewModel;
        private readonly ICoursesService coursesService;

        public ShowCoursesForStudentCommand (UserViewModel userViewModel, NavigationService navigation)
        {
            this.userViewModel = userViewModel;
            this.coursesService = new CoursesService();
            _navigationService = navigation;

        }
        
        public override void Execute(object parameter)
        {
            List<Course> course = coursesService.GetCoursesByStudentId(userViewModel.Id);
            List<CourseViewModel> courseViewModels = new List<CourseViewModel>();
            foreach (var c in course)
            {
                courseViewModels.Add(new CourseViewModel(c));
            }

            ShowAllCoursesViewModel showAllCoursesViewModel = new ShowAllCoursesViewModel(userViewModel,courseViewModels,_navigationService);

            _navigationService.Navigate(showAllCoursesViewModel);
        }
    }
}
