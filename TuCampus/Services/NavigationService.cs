using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuCampus.Stores;
using TuCampus.ViewModels;

namespace DataLayer.Services
{
    public class NavigationService
    {
        private readonly NavigationStore _navigationStore;
        
        public NavigationService(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            
        }

        public void Navigate(ViewModelBase viewModel)
        {
            _navigationStore.CurrentViewModel = viewModel;
        }
       // public void Navigate()
        //{
          //  _navigationStore.CurrentViewModel = _createViewModel();
        //}
    }
}
