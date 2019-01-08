using CandidateTest.Presentation.Wpf.Utilities.Attributes;
using CandidateTest.Presentation.Wpf.ViewModels.Factories;
using CandidateTest.Presentation.Wpf.ViewModels.TaskViewModels;
using System.Collections.Generic;

namespace CandidateTest.Presentation.Wpf.ViewModels
{
    internal sealed class MainWindowViewModel : ViewModel
    {
        private readonly IDictionary<string, TaskViewModel> taskToViewModel = new Dictionary<string, TaskViewModel>();
        private readonly IViewModelFactory viewModelFactory;

        private string selectedTask = string.Empty;

        public MainWindowViewModel(IViewModelFactory viewModelFactory)
        {
            this.viewModelFactory = viewModelFactory;
            FillDictionary();
        }

        public string SelectedTask
        {
            get => selectedTask;
            set => SetProperty(ref selectedTask, value);
        }

        [DependsUponProperty(nameof(SelectedTask))]
        public ViewModel SelectedViewModel => selectedTask != string.Empty ? taskToViewModel[selectedTask] : null;

        public IEnumerable<string> Tasks => taskToViewModel.Keys;

        private void FillDictionary()
        {
            ICollection<TaskViewModel> viewModels = new List<TaskViewModel>()
            {
                viewModelFactory.CreateTask3ViewModel(),
                viewModelFactory.CreateTask4ViewModel(),
                viewModelFactory.CreateTask5ViewModel()
            };

            foreach (var viewModel in viewModels)
            {
                taskToViewModel.Add(viewModel.Name, viewModel);
            }
        }
    }
}