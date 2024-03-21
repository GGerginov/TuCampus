using DataLayer.Services;
using System.Configuration;
using System.Data;
using System.Windows;
using TuCampus.Services;
using TuCampus.Stores;
using TuCampus.ViewModels;
using TuCampus.ViewModels.Users;

namespace TuCampus
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore _navigationStore;


        public App()
        {
            _navigationStore = new NavigationStore();
        }


        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var mainWindow = new MainWindow();
            
            var navigationService = new NavigationService(_navigationStore);
            var loginViewModel = new LoginViewModel(navigationService);
            _navigationStore.CurrentViewModel = loginViewModel;
            //navigationService = new NavigationService(_navigationStore);


            var mainViewModel = new MainViewModel(_navigationStore);
           
            mainWindow.DataContext = mainViewModel;
            mainWindow.Show();
        }

      
    }



}
