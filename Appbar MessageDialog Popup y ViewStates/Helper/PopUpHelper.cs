using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

namespace Appbar_MessageDialog_Popup_y_ViewStates.Helper
{
    public class PopUpHelper
    {
        Popup _popUp;

        public PopUpHelper()
        {
            _popUp = new Popup();
            _popUp.IsLightDismissEnabled = true;
        }

        public void show(UserControl control, Point location)
        {
            _popUp.Child = control;
            _popUp.HorizontalOffset = location.X;
            _popUp.VerticalOffset = location.Y;
            _popUp.Width = control.Width;
            _popUp.Height = control.Height;
            _popUp.IsOpen = true;
        }
    }
}
