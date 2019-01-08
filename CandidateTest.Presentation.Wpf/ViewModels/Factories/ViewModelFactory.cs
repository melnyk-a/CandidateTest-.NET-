using CandidateTest.Presentation.Wpf.Models;
using CandidateTest.Presentation.Wpf.Services;
using CandidateTest.Presentation.Wpf.ViewModels.TaskViewModels;

namespace CandidateTest.Presentation.Wpf.ViewModels.Factories
{
    internal sealed class ViewModelFactory : IViewModelFactory
    {
        private readonly IMessageService messageService;
        private readonly IModelProvider modelProvider;
        private readonly IOpenFileService openFileService;

        public ViewModelFactory(IOpenFileService openFileService, 
                                IModelProvider modelProvider, 
                                IMessageService messageService)
        {
            this.messageService = messageService;
            this.modelProvider = modelProvider;
            this.openFileService = openFileService;
        }

        public ViewModel CreateMainViewModel()
        {
            return new MainWindowViewModel(this);
        }

        public TaskViewModel CreateTask3ViewModel()
        {
            return new Task3ViewModel(openFileService, modelProvider, messageService);
        }

        public TaskViewModel CreateTask4ViewModel()
        {
            return new Task4ViewModel(openFileService, modelProvider, messageService);
        }

        public TaskViewModel CreateTask5ViewModel()
        {
            return new Task5ViewModel(openFileService, modelProvider, messageService);
        }
    }
}