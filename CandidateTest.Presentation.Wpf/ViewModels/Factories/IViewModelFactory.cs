using CandidateTest.Presentation.Wpf.Models;
using CandidateTest.Presentation.Wpf.Services;
using CandidateTest.Presentation.Wpf.ViewModels.TaskViewModels;

namespace CandidateTest.Presentation.Wpf.ViewModels.Factories
{
    internal interface IViewModelFactory
    {
        ViewModel CreateMainViewModel();
        TaskViewModel CreateTask3ViewModel();
        TaskViewModel CreateTask4ViewModel();
        TaskViewModel CreateTask5ViewModel();
    }
}