using DataLayer.Services;
using DataLayer.Services.CredentialsValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuCampus.ViewModels;
using TuCampus.ViewModels.Users;

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
                var welcomeViewModel= new WelcomeDashboardViewModel(new UserViewModel(user),_navigationService);

                _navigationService.Navigate(welcomeViewModel);
            }
            
        }
    }
}
