using System;
using Windows.UI.Xaml.Data;

namespace _10_Search_Y_Share_Contract_DESDE_CERO.Common
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
