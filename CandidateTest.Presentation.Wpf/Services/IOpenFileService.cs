namespace CandidateTest.Presentation.Wpf.Services
{
    public interface IOpenFileService
    {
        string FileName { get; }
        bool OpenFileDialog();
    }
}