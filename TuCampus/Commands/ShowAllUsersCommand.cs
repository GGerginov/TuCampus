using DataLayer.Model;
using DataLayer.Models;
using DataLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuCampus.Services;
using TuCampus.Services.CoursesService;
using TuCampus.ViewModels.Courses;
using TuCampus.ViewModels.Users;
using TuCampus.Views;

namespace TuCampus.Commands
{
    internal class ShowAllUsersCommand : CommandBase
    {
        private readonly NavigationService _navigationService;
        private UserViewModel userViewModel;
        private readonly IUsersService usersService;

        public ShowAllUsersCommand(UserViewModel userViewModel,NavigationService navigationService)
        {
            this.userViewModel = userViewModel;
            usersService = new UsersService();
            _navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            List<User> users = usersService.GetAllUsers();

            List<UserViewModel> userViewModels = new List<UserViewModel>();
            foreach (var c in users)
            {
                userViewModels.Add(new UserViewModel(c));
            }

            ListAllStudentsViewModel listAllStudentsViewModel = new ListAllStudentsViewModel(userViewModel, userViewModels, _navigationService);

   

            _navigationService.Navigate(listAllStudentsViewModel);
        }
    }
}
