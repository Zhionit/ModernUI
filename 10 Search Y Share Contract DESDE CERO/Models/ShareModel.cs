using _10_Search_Y_Share_Contract_DESDE_CERO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace _10_Search_Y_Share_Contract_DESDE_CERO.Models
{
    public class ShareModel:BindableBase
    {
        private String _imageTitle;
        public String ImageTitle
        {
            get { return _imageTitle; }
            set { SetProperty(ref _imageTitle, value); }
        }

        private BitmapImage _imageBitmap;
        public BitmapImage ImageBitmap
        {
            get { return _imageBitmap; }
            set { SetProperty(ref _imageBitmap, value); }
        }

        public ShareModel()
        {
            _imageBitmap = new BitmapImage();
        }

    }
}
