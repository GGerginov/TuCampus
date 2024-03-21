using DataLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuCampus.Services;
using TuCampus.Stores;
using TuCampus.ViewModels;

namespace TuCampus.Commands
{
    public class NavigateCommand : CommandBase
    {
        private readonly NavigationService _navigationService;
        public ViewModelBase ViewModel { get; set; }

        public NavigateCommand(NavigationService navigationService,ViewModelBase viewModel)
        {
            _navigationService = navigationService;
            ViewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            _navigationService.Navigate(ViewModel);
        }
    }
}
