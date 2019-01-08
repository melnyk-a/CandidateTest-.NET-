namespace CandidateTest.Presentation.Wpf.Utilities.Attributes
{
    internal sealed class RaiseCanExecuteDependsUponAttribute: DependsUponAttribute
    {
        public RaiseCanExecuteDependsUponAttribute(string propertyName) :
            base(propertyName)
        {
        }
    }
}