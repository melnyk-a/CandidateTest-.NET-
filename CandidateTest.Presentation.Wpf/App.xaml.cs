using CandidateTest.Presentation.Wpf.Models;
using CandidateTest.Presentation.Wpf.Services;
using CandidateTest.Presentation.Wpf.ViewModels.Factories;
using CandidateTest.Presentation.Wpf.Views;
using System.Windows;

namespace CandidateTest.Presentation.Wpf
{
    public partial class App : Application
    {
        private const string Filter = "Object files (*.obj)|*.obj|All files (*.*)|*.*";
        private const string InitialDirectory = @"..\..\3dModels\";

        private MainWindowView mainWindow;

        public App()
        {
            InitializeComponent();
            SetupCompositionRoot();
        }

        private void SetupCompositionRoot()
        {
            IOpenFileService openFileService = new OpenFileService(Filter, InitialDirectory);
            IModelProvider modelProvider = new ModelProvider();
            IMessageService messageService = new MessageService();

            var viewModelFactory = new ViewModelFactory(openFileService, modelProvider, messageService);
            mainWindow = new MainWindowView(viewModelFactory);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            mainWindow.Show();
        }
    }
}