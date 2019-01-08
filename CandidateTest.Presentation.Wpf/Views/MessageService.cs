using CandidateTest.Presentation.Wpf.Services;
using System.Windows;

namespace CandidateTest.Presentation.Wpf.Views
{
    internal sealed class MessageService : IMessageService
    {
        private const string ErrorTitle = "Error";

        public void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, ErrorTitle, MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}