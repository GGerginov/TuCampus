using DataLayer.Models;
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
    public class GradeSearchViewModel : ViewModelBase,INotifyPropertyChanged
    {
        private readonly GradeRecordService _gradeRecordService;
        private string _selectedField;
        private string _searchValue;
        private ObservableCollection<GradeRecord> _searchResults;

        public ObservableCollection<string> AvailableFields { get; set; }
        public ObservableCollection<GradeRecord> SearchResults
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

        public GradeSearchViewModel(GradeRecordService gradeRecordService)
        {
            _gradeRecordService = gradeRecordService;
            List<string> properties = _gradeRecordService.GetAllPropertyNames();
            AvailableFields = new ObservableCollection<string>(properties);
            SearchResults = new ObservableCollection<GradeRecord>();
            SearchCommand = new GradeSearchCommand(this);
        }

        public async void PerformSearch()
        {
            var results = await _gradeRecordService.GetRecordsByFieldAsync(SelectedField, SearchValue);
            SearchResults = new ObservableCollection<GradeRecord>(results);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}




