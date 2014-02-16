using Acceso_Storage_WinAzure_con_REST.Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace Acceso_Storage_WinAzure_con_REST
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            var file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/Logo.scale-100.png"));
            var stream = await file.OpenStreamForReadAsync(); 
            var blobUpLoader = new BlockBlobStorage(txtBxUserName.Text , pasBx.Password);
            var respuesta = await blobUpLoader.UploadAsync("Imagenes/Logo_cale_100.png", stream, mimetype:"image/jpeg");
        }
    }
}
