using CandidateTest.Presentation.Wpf.ViewModels.Factories;
using System.Windows;

namespace CandidateTest.Presentation.Wpf.Views
{
    internal partial class MainWindowView : Window
    {
        public MainWindowView(IViewModelFactory viewModelFactory)
        {
            InitializeComponent();
            DataContext = viewModelFactory.CreateMainViewModel();
        }
    }
}