using CandidateTest.Presentation.Wpf.Commands;
using CandidateTest.Presentation.Wpf.Models;
using CandidateTest.Presentation.Wpf.Services;
using CandidateTest.Presentation.Wpf.Utilities.Attributes;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Media3D;

namespace CandidateTest.Presentation.Wpf.ViewModels.TaskViewModels
{
    internal abstract class TaskViewModel : ViewModel
    {
        private readonly DelegateCommand clearCommand;
        private readonly AsyncDelegateCommand loadCommand;
        private readonly IMessageService messageService;
        protected readonly IModelProvider modelProvider;
        private readonly IOpenFileService openFileService;

        private Model3D model;

        public TaskViewModel(IOpenFileService openFileService,
                             IModelProvider modelProvider,
                             IMessageService messageService)
        {
            this.messageService = messageService;
            this.modelProvider = modelProvider;
            this.openFileService = openFileService;

            clearCommand = new DelegateCommand(Clear, () => CanClear);
            loadCommand = new AsyncDelegateCommand(LoadAsync);
        }

        [DependsUponProperty(nameof(Model))]
        public bool CanClear => Model != null;

        [RaiseCanExecuteDependsUpon(nameof(CanClear))]
        public ICommand ClearCommand => clearCommand;

        public ICommand LoadCommand => loadCommand;

        public Model3D Model
        {
            get => model;
            set => SetProperty(ref model, value);
        }

        public abstract string Name { get; }

        protected virtual void Clear() => Model = null;

        protected virtual async Task LoadAsync()
        {
            if (openFileService.OpenFileDialog())
            {
                try
                {
                    Model = await modelProvider.LoadModelAsync(openFileService.FileName);
                }
                catch (LoadException e)
                {
                    messageService.ShowErrorMessage(e.Message);
                }
            }
        }
    }
}