using CandidateTest.Presentation.Wpf.Commands;
using CandidateTest.Presentation.Wpf.Models;
using CandidateTest.Presentation.Wpf.Services;
using System.Windows.Input;
using System.Windows.Media.Media3D;

namespace CandidateTest.Presentation.Wpf.ViewModels.TaskViewModels
{
    internal sealed class Task3ViewModel : TaskViewModel
    {
        private const string TaskName = "Task3";

        private readonly DelegateCommand startCommand;

        private Rect3D bounds;
        private bool canStart = true;
        private Point3DCollection points = new Point3DCollection();

        public Task3ViewModel(IOpenFileService openFileService,
                              IModelProvider modelProvider,
                              IMessageService messageService)
            : base(openFileService, modelProvider, messageService)
        {
            startCommand = new DelegateCommand(StartRotate);
        }

        public Rect3D Box
        {
            get => bounds;
            set => SetProperty(ref bounds, value);
        }

        public bool CanStart
        {
            get => canStart;
            set => SetProperty(ref canStart, value);
        }

        public override string Name => TaskName;

        public Point3DCollection Points
        {
            get => points;
            set => SetProperty(ref points, value);
        }

        public ICommand StartCommand => startCommand;

        private void StartRotate() => CanStart = false;
    }
}