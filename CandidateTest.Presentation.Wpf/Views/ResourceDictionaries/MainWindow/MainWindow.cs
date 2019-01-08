using System.Windows;

namespace CandidateTest.Presentation.Wpf.Views.ResourceDictionaries
{
    internal sealed partial class MainWindow
    {
        private Window window;

        private void AssignWindow(object @object)
        {
            if (window == null)
            {
                window = Window.GetWindow(@object as DependencyObject);
            }
        }

        private void CloseButtonClick(object sender, RoutedEventArgs e)
        {
            AssignWindow(sender);
            window.Close();
        }

        private void MaximizeButtonClick(object sender, RoutedEventArgs e)
        {
            AssignWindow(sender);
            if (window.WindowState == WindowState.Maximized)
            {
                SystemCommands.RestoreWindow(window);
            }
            else
            {
                SystemCommands.MaximizeWindow(window);
            }
        }

        private void MinimizeButtonClick(object sender, RoutedEventArgs e)
        {
            AssignWindow(sender);
            SystemCommands.MinimizeWindow(window);
        }
    }
}