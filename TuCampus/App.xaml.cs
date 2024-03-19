using DataLayer.Services;
using System.Configuration;
using System.Data;
using System.Windows;
using TuCampus.Stores;
using TuCampus.ViewModels;

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
            _navigationStore.CurrentViewModel = CreateLoginViewModel();
            var mainViewModel = new MainViewModel(_navigationStore);
           
            mainWindow.DataContext = mainViewModel;
            mainWindow.Show();
        }

        private LoginViewModel CreateLoginViewModel()
        {
            return new LoginViewModel(new NavigationService(_navigationStore, CreateWelcomeDashboardViewModel));
        }

        private WelcomeDashboardViewModel CreateWelcomeDashboardViewModel()
        {
            return new WelcomeDashboardViewModel();
        }
    }



}
