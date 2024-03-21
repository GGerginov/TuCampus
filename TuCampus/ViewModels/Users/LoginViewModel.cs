using DataLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TuCampus.Commands;
using TuCampus.Stores;

namespace TuCampus.ViewModels.Users
{
    public class LoginViewModel : ViewModelBase
    {

        public string Username { get; set; }
        public string Password { get; set; }
        public ICommand LoginCommand { get; }
        public LoginViewModel(NavigationService navigationService)
        {
            LoginCommand = new LoginComand(this, navigationService);
        }

        public void Login()
        { }


    }
}
