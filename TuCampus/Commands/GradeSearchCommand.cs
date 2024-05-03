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
    internal class GradeSearchCommand : CommandBase
    {
        public GradeSearchViewModel GradeSearchViewModel { get; set; }
        

        public GradeSearchCommand(GradeSearchViewModel viewModel)
        {
            GradeSearchViewModel = viewModel;
        }
 
        public override void Execute(object parameter)
        {
            GradeSearchViewModel.PerformSearch();
        }
    }
}