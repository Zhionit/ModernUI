﻿using System;
using Windows.UI.Xaml.Data;

namespace Appbar_MessageDialog_Popup_y_ViewStates.Common
{
    /// <summary>
    /// Convertidor de valores que cambia true a false y viceversa.
    /// </summary>
    public sealed class BooleanNegationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return !(value is bool && (bool)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return !(value is bool && (bool)value);
        }
    }
}
