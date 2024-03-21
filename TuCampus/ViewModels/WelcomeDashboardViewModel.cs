using DataLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TuCampus.Commands;
using TuCampus.ViewModels.Users;

namespace TuCampus.ViewModels
{
    public class WelcomeDashboardViewModel : ViewModelBase
    {
        private readonly UserViewModel _userViewModel;
  
        public UserViewModel UserViewModel => _userViewModel;

        public ICommand ShowCourses { get; }

        public WelcomeDashboardViewModel(UserViewModel userViewModel,NavigationService _navigationService)
        {
            _userViewModel = userViewModel;
            ShowCourses = new ShowAllCoursesCommand(_userViewModel,_navigationService);
        }
    }
}
