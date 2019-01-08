using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CandidateTest.Presentation.Wpf.ViewModels.Controls
{
    internal sealed class PathButton : Button
    {
        public static readonly DependencyProperty IsHighlightedProperty = DependencyProperty.Register(
            "IsHighlighted",
            typeof(bool),
            typeof(PathButton),
            new PropertyMetadata(false)
        );

        public static readonly DependencyProperty PathDataProperty = DependencyProperty.Register(
            "PathData",
            typeof(Geometry),
            typeof(PathButton),
            new PropertyMetadata(null)
        );

        public bool IsHighlighted
        {
            get { return (bool)GetValue(IsHighlightedProperty); }
            set { SetValue(IsHighlightedProperty, value); }
        }

        public Geometry PathData
        {
            get => (Geometry)GetValue(PathDataProperty);
            set => SetValue(PathDataProperty, value);
        }
    }
}