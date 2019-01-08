using CandidateTest.Presentation.Wpf.Commands;
using CandidateTest.Presentation.Wpf.Utilities.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace CandidateTest.Presentation.Wpf.ViewModels
{
    internal abstract class ViewModel : INotifyPropertyChanged
    {
        public ViewModel()
        {
            Type currentType = GetType();
            PropertyInfo[] properties = currentType.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                HandlePropertiesAttributes(property);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void HandleDependsUpponProperties(PropertyInfo appliedProperty)
        {
            IEnumerable<DependsUponPropertyAttribute> attributes = appliedProperty.GetCustomAttributes<DependsUponPropertyAttribute>();
            foreach (DependsUponPropertyAttribute attribute in attributes)
            {
                PropertyChanged += (sender, e) =>
                {
                    if (e.PropertyName == attribute.PropertyName)
                    {
                        OnPropertyChanged(new PropertyChangedEventArgs(appliedProperty.Name));
                    }
                };
            }
        }

        private void HandlePropertiesAttributes(PropertyInfo appliedProperty)
        {
            HandleDependsUpponProperties(appliedProperty);
            HandleRaiseCanExecuteDependsUpponProperties(appliedProperty);
        }

        private void HandleRaiseCanExecuteDependsUpponProperties(PropertyInfo appliedProperty)
        {
            RaiseCanExecuteDependsUponAttribute attribute = appliedProperty.GetCustomAttribute<RaiseCanExecuteDependsUponAttribute>();
            if (attribute != null)
            {
                PropertyChanged += (sender, e) =>
                {
                    if (e.PropertyName == attribute.PropertyName)
                    {
                        Command command = (Command)appliedProperty.GetValue(this);
                        command.RaiseCanExecuteChanged();
                    }
                };
            }
        }

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }

        protected void SetProperty<T>(ref T oldValue, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!(oldValue?.Equals(newValue)) ?? newValue != null)
            {
                oldValue = newValue;
                OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}