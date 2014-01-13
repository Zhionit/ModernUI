using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Appbar_MessageDialog_Popup_y_ViewStates.Converters
{
    public class Bool2VisibilityConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var boolean = (bool)value;

            return boolean ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            var visibilidad = (Visibility)value;

            return visibilidad == Visibility.Collapsed ? false : true;
        }
    }
}
