using DataLayer.Models;
using System.Buffers;
using System.Collections.ObjectModel;
using System.DirectoryServices;
using System.Windows.Input;
using TuCampus.Services.CoursesService;
using TuCampus.Services.ListsService;
using TuCampus.ViewModels.Grades;
using TuCampus.ViewModels.Users;

namespace TuCampus.Commands
{
    internal class PresentListSearchCommand : CommandBase
    {
        public PresentListViewModel PresentListViewModel { get; set; }
        

        public PresentListSearchCommand(PresentListViewModel viewModel)
        {
            PresentListViewModel = viewModel;
        }
 
        public override void Execute(object parameter)
        {
            PresentListViewModel.PerformSearch();
        }
    }
}