﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace CandidateTest.Presentation.Wpf.Views.Converters
{
    internal sealed class StringToUpperConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && value is string)
            {
                return ((string)value).ToUpper();
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}