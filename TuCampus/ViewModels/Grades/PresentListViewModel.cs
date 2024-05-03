using DataLayer.Models;
using DataLayer.Models.ListModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;
using TuCampus.Commands;
using TuCampus.Services.ListsService;

namespace TuCampus.ViewModels.Grades
{
    public class PresentListViewModel : ViewModelBase,INotifyPropertyChanged
    {
        private readonly PresentListService _presentListService;
        private string _selectedField;
        private string _searchValue;
        private ObservableCollection<PresentList> _searchResults;

        public ObservableCollection<string> AvailableFields { get; set; }
        public ObservableCollection<PresentList> SearchResults
        {
            get => _searchResults;
            set
            {
                _searchResults = value;
                OnPropertyChanged();
            }
        }

        public string SelectedField
        {
            get => _selectedField;
            set
            {
                _selectedField = value;
                OnPropertyChanged();
            }
        }

        public string SearchValue
        {
            get => _searchValue;
            set
            {
                _searchValue = value;
                OnPropertyChanged();
            }
        }

        public ICommand SearchCommand { get; }

        public PresentListViewModel(PresentListService presentListService)
        {
            _presentListService = presentListService;
            List<string> properties = _presentListService.GetAllPropertyNames();
            AvailableFields = new ObservableCollection<string>(properties);
            SearchResults = new ObservableCollection<PresentList>();
            SearchCommand = new PresentListSearchCommand(this);
        }

        public async void PerformSearch()
        {
            var results = await _presentListService.GetRecordsByFieldAsync(SelectedField, SearchValue);
            SearchResults = new ObservableCollection<PresentList>(results);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}




