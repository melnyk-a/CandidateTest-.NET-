using CandidateTest.Presentation.Wpf.Commands;
using CandidateTest.Presentation.Wpf.Models;
using CandidateTest.Presentation.Wpf.Services;
using CandidateTest.Presentation.Wpf.Utilities.Attributes;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CandidateTest.Presentation.Wpf.ViewModels.TaskViewModels
{
    internal sealed class Task5ViewModel : TaskViewModel
    {
        private const string TaskName = "Task5";

        private readonly DelegateCommand startCommand;
        private readonly DelegateCommand stopCommand;

        private bool canStart = true;

        public Task5ViewModel(IOpenFileService openFileService,
                              IModelProvider modelProvider,
                              IMessageService messageService)
            : base(openFileService, modelProvider, messageService)
        {
            startCommand = new DelegateCommand(Start, () => CanStart);
            stopCommand = new DelegateCommand(Stop, () => CanStop);
        }

        [DependsUponProperty(nameof(CanClear))]
        public bool CanStart
        {
            get => canStart;
            set => SetProperty(ref canStart, value);
        }

        [DependsUponProperty(nameof(CanStart))]
        public bool CanStop => !CanStart;

        public override string Name => TaskName;

        [RaiseCanExecuteDependsUpon(nameof(CanStop))]
        public ICommand StartCommand => startCommand;

        [RaiseCanExecuteDependsUpon(nameof(CanStart))]
        public ICommand StopCommand => stopCommand;

        protected override void Clear()
        {
            base.Clear();
            CanStart = true;
        }

        protected override async Task LoadAsync()
        {
            await base.LoadAsync();
            CanStart = true;
        }

        private void Start()
        {
            if (CanClear)
            {
                CanStart = false;
            }
        }

        private void Stop() => CanStart = true;
    }
}