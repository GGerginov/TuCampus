using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TuCampus.Commands;
using TuCampus.Services;
using DataLayer.DbContexts;
using TuCampus.Services.ListsService;
using TuCampus.ViewModels.Courses;
using TuCampus.ViewModels.Welcome;
using TuCampus.ViewModels.Grades;

namespace TuCampus.ViewModels.Users
{
    public class ListAllStudentsViewModel : ViewModelBase
    {
        public List<UserViewModel> Users { get; set; }
        public NavigationService NavigationService { get; set; }

        public ICommand ReturnCommand { get; }
        public ICommand AddNewUsersDisplay { get; }
        public ICommand ShowListDisplay { get; }
        public ICommand ShowPresentsDisplay { get; }



        public ListAllStudentsViewModel(UserViewModel userViewModel, List<UserViewModel> users, NavigationService _navigationService)
        {
            Users = users;
            NavigationService = _navigationService;
            AddNewUsersDisplay = new NavigateCommand(NavigationService, new AddNewUsersViewModel(_navigationService));
            ShowListDisplay = new NavigateCommand(NavigationService, new GradeSearchViewModel(new GradeRecordService(new TuCampusDbContext())));
            ShowPresentsDisplay = new NavigateCommand(NavigationService, new PresentListViewModel(new PresentListService(new TuCampusDbContext())));

            switch (userViewModel.Role.ToString().ToUpper())
            {
                case "ADMIN":
                    ReturnCommand = new NavigateCommand(NavigationService, new WelcomeAdminDashboardViewModel(userViewModel, NavigationService));
                    break;
                case "TEACHER":
                    ReturnCommand = new NavigateCommand(NavigationService, new WelcomeTeacherDashboardViewModel(userViewModel, NavigationService));
                    break;
                case "STUDENT":
                    ReturnCommand = new NavigateCommand(NavigationService, new WelcomeStudentDashboardViewModel(userViewModel, NavigationService));
                    break;
            }
        }   
    }
}
