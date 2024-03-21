using DataLayer.Models;
using DataLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuCampus.Services.CoursesService;
using TuCampus.ViewModels.Courses;
using TuCampus.ViewModels.Users;

namespace TuCampus.Commands
{
    internal class ShowAllCoursesCommand : CommandBase
    {
        private readonly NavigationService _navigationService;
        private UserViewModel userViewModel;
        private readonly ICoursesService coursesService;

        public ShowAllCoursesCommand(UserViewModel userViewModel,NavigationService navigationService)
        {
            this.userViewModel = userViewModel;
            coursesService = new CoursesService();
            _navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            List<Course> course = coursesService.GetCourses();
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
