using CandidateTest.Presentation.Wpf.Models;
using CandidateTest.Presentation.Wpf.Services;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace CandidateTest.Presentation.Wpf.ViewModels.TaskViewModels
{
    internal sealed class Task4ViewModel : TaskViewModel
    {
        private const string TaskName = "Task4";

        private Rect3D? bounds;
        private Point3DCollection points;

        public Task4ViewModel(IOpenFileService openFileService,
                              IModelProvider modelProvider,
                              IMessageService messageService)
            : base(openFileService, modelProvider, messageService)
        {
        }

        public Rect3D? Box
        {
            get => bounds;
            set => SetProperty(ref bounds, value);
        }

        public override string Name => TaskName;

        public Point3DCollection Points
        {
            get => points;
            set => SetProperty(ref points, value);
        }

        protected override void Clear()
        {
            base.Clear();

            Box = null;
            Points = null;
        }

        protected override async Task LoadAsync()
        {
            await base.LoadAsync();

            Box = modelProvider.GetBounds(Model);

            if (Box.HasValue)
            {
                Points = modelProvider.GetCenterOutLines(Box.Value);
            }
        }
    }
}