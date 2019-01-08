namespace CandidateTest.Presentation.Wpf.Utilities.Attributes
{
    internal sealed class DependsUponPropertyAttribute : DependsUponAttribute
    {
        public DependsUponPropertyAttribute(string propertyName) : 
            base(propertyName)
        {
        }
    }
}