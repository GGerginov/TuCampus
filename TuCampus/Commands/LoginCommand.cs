using DataLayer.Models.Others;
using DataLayer.Services;
using DataLayer.Services.CredentialsValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuCampus.ViewModels;
using TuCampus.ViewModels.Users;
using TuCampus.ViewModels.Welcome;

namespace TuCampus.Commands
{
    public class LoginComand : CommandBase
    {
        private readonly NavigationService _navigationService;

        private readonly UserCredentialsValidatorService userCredentialsValidatorService;
        private readonly LoginViewModel _loginViewModel;


        public LoginComand(LoginViewModel loginViewModel, NavigationService navigationService)
        {
            userCredentialsValidatorService = new UserCredentialsValidatorService();
            _loginViewModel = loginViewModel;
            _navigationService = navigationService;
        }   
        public override void Execute(object parameter)
        {
            var user = userCredentialsValidatorService.GetUser(_loginViewModel.Username, _loginViewModel.Password);
            if (user != null)
            {
                var role = user.Role;
                switch (role)
                {
                    case UserRoleEnum.Student:
                        var welcomeViewModelStudent = new WelcomeStudentDashboardViewModel(new UserViewModel(user), _navigationService);
                        _navigationService.Navigate(welcomeViewModelStudent);
                        break;
                    case UserRoleEnum.Teacher:
                        var welcomeViewModelTeacher = new WelcomeTeacherDashboardViewModel(new UserViewModel(user), _navigationService);
                        _navigationService.Navigate(welcomeViewModelTeacher);
                        break;
                    case UserRoleEnum.Admin:
                        var welcomeViewModelAdmin = new WelcomeAdminDashboardViewModel(new UserViewModel(user), _navigationService);
                        _navigationService.Navigate(welcomeViewModelAdmin);
                        break;
                }   
            }
            
        }
    }
}
