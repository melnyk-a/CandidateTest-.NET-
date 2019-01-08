using CandidateTest.Presentation.Wpf.Services;
using Microsoft.Win32;
using System.IO;

namespace CandidateTest.Presentation.Wpf.Views
{
    internal sealed class OpenFileService : IOpenFileService
    {
        private readonly OpenFileDialog openFileDialog = new OpenFileDialog();

        public OpenFileService()
            : this(string.Empty, string.Empty)
        {
        }

        public OpenFileService(string filter)
           : this(filter, string.Empty)
        {
        }

        public OpenFileService(string filter, string initialDirectory)
        {
            openFileDialog.Filter = filter;
            if (initialDirectory != string.Empty)
            {
                openFileDialog.InitialDirectory = Path.GetFullPath(initialDirectory);
            }
        }

        public string FileName => openFileDialog.FileName;

        public bool OpenFileDialog() => openFileDialog.ShowDialog() == true;
    }
}