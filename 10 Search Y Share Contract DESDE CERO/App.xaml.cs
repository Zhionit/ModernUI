using _10_Search_Y_Share_Contract_DESDE_CERO.Contracts;
using _10_Search_Y_Share_Contract_DESDE_CERO.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.DataTransfer;
using Windows.ApplicationModel.Search;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla Aplicación vacía está documentada en http://go.microsoft.com/fwlink/?LinkId=234227

namespace _10_Search_Y_Share_Contract_DESDE_CERO
{
    /// <summary>
    /// Proporciona un comportamiento específico de la aplicación para complementar la clase Application predeterminada.
    /// </summary>
    sealed partial class App : Application
    {
        /// <summary>
        /// Inicializa el objeto de aplicación Singleton. Esta es la primera línea de código creado
        /// ejecutado y, como tal, es el equivalente lógico de main() o WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }

        /// <summary>
        /// Se invoca cuando la aplicación la inicia normalmente el usuario final. Se usarán otros puntos
        /// de entrada cuando la aplicación se inicie para abrir un archivo específico, para mostrar
        /// resultados de la búsqueda, etc.
        /// </summary>
        /// <param name="args">Información detallada acerca de la solicitud y el proceso de inicio.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            // No repetir la inicialización de la aplicación si la ventana tiene contenido todavía,
            // solo asegurarse de que la ventana está activa.
            if (rootFrame == null)
            {
                // Crear un marco para que actúe como contexto de navegación y navegar a la primera página.
                rootFrame = new Frame();

                if (args.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Cargar el estado de la aplicación suspendida previamente
                }

                // Poner el marco en la ventana actual.
                Window.Current.Content = rootFrame;
            }

            if (rootFrame.Content == null)
            {
                // Cuando no se restaura la pila de navegación para navegar a la primera página,
                // configurar la nueva página al pasar la información requerida como parámetro
                // parámetro
                if (!rootFrame.Navigate(typeof(DataPage), args.Arguments))
                {
                    throw new Exception("Failed to create initial page");
                }
            }
            // Asegurarse de que la ventana actual está activa.
            Window.Current.Activate();
        }

        /// <summary>
        /// Se invoca al suspender la ejecución de la aplicación. El estado de la aplicación se guarda
        /// sin saber si la aplicación se terminará o se reanudará con el contenido
        /// de la memoria aún intacto.
        /// </summary>
        /// <param name="sender">Origen de la solicitud de suspensión.</param>
        /// <param name="e">Detalles sobre la solicitud de suspensión.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Guardar el estado de la aplicación y detener toda actividad en segundo plano
            deferral.Complete();
        }

        protected override void OnWindowCreated(WindowCreatedEventArgs args)
        {
            // Se usa para que cada vez que se cree la ventana se le cree un controlador de evento para la busqueda
            SearchPane.GetForCurrentView().QuerySubmitted += App_QuerySubmitted;

            // Share Charm Funcionality
            DataTransferManager.GetForCurrentView().DataRequested += DataPage_dataRequest;

            base.OnWindowCreated(args);
        }

        void DataPage_dataRequest(DataTransferManager sender, DataRequestedEventArgs args)
        {
            var properties = args.Request.Data.Properties;
            var request = args.Request;

            //TextSharingHandler(properties, request);
            //LinkSharingHandler(properties, request);
            //ImageSharingHandler(properties, request);
            //FileSharingHandler(properties, request);
            HtmlSharingHandler(properties, request);
        }

        private void HtmlSharingHandler(DataPackagePropertySet properties, DataRequest request)
        {
            properties.Title = "Compartiendo un documento de html5 desde el Share Charm";
            properties.Description = "Se supone que estoy compartiendo la descirpcion con el Share Charm";

            var localImagePath = "ms-appx:///Assets/Logo.png";
            string htmlContent = @"<p> hola esto es un <strong> parrafo de HTML </strong> :) </p>
<p>Y esto es una imagen: <img source='"+ localImagePath +"'/></p>";
            var htmlFormatString = HtmlFormatHelper.CreateHtmlFormat(htmlContent);

            request.Data.ResourceMap[localImagePath] = RandomAccessStreamReference.CreateFromUri(new Uri(localImagePath));
            request.Data.SetHtmlFormat(htmlFormatString);
        }

        private async void FileSharingHandler(DataPackagePropertySet properties, DataRequest request)
        {
            properties.Title = "Compartiendo un conjunto de archivos desde el Share Charm";
            properties.Description = "Se supone que estoy compartiendo la descirpcion con el Share Charm";

            var deferral = request.GetDeferral();

            try
            {
                var sampleFile = await Package.Current.InstalledLocation.GetFileAsync(@"Assets\casilleros.xlsx"); // Archivo no existe

                var sampleFile2 = await Package.Current.InstalledLocation.GetFileAsync(@"Assets\Logo.png");

                var storageFilesList = new List<IStorageItem>();
                storageFilesList.Add(sampleFile);
                request.Data.SetStorageItems(storageFilesList);
            }
            finally
            {
                deferral.Complete();
            }
        }

        private async void ImageSharingHandler(DataPackagePropertySet properties, DataRequest request)
        {

            properties.Title = "Compartiendo una imagen desde el Share Charm";
            properties.Description = "Se supone que estoy compartiendo la descirpcion con el Share Charm";

            // TODO Deferral espera abierta en el sistema 

            // TODO Cuando se esten cargando cosas de manera asincrona debemos llamar el deferrel
            // TODO para que el sistema espere a la carga de los archivos antes de disparar el proceso completo.

            var deferral = request.GetDeferral();

            // Ctrl + k + s, genera el envoltorio de try
            try
            {
                var thumbFile = await Package.Current.InstalledLocation.GetFileAsync(@"Assets\Logo.png");
                properties.Thumbnail = RandomAccessStreamReference.CreateFromFile(thumbFile);

                var imageFile = await Package.Current.InstalledLocation.GetFileAsync(@"Assets\Logo.png");
                request.Data.SetBitmap(RandomAccessStreamReference.CreateFromFile(imageFile));
            }
            finally
            {
                deferral.Complete();
            }
        }

        private void LinkSharingHandler(DataPackagePropertySet properties, DataRequest request)
        {
            properties.Title = "Compartiendo un link desde el Share Charm";
            properties.Description = "Se supone que estoy compartiendo la descirpcion con el Share Charm";

            request.Data.SetUri(new Uri("http://www.google.com"));
        }

        private void TextSharingHandler(DataPackagePropertySet properties, DataRequest request)
        {
            properties.Title = "Compartiendo texto desde el Share Charm";
            properties.Description = "Se supone que estoy compartiendo la descirpcion con el Share Charm";

            request.Data.SetText("Hola Mundo desde Share Charm");
        }

        protected override void OnSearchActivated(SearchActivatedEventArgs args)
        {
            InitializeSearch(args.QueryText);
        }

        void App_QuerySubmitted(SearchPane sender, SearchPaneQuerySubmittedEventArgs args)
        {
            InitializeSearch(args.QueryText);
        }

        protected override void OnShareTargetActivated(ShareTargetActivatedEventArgs args)
        {
            var rootFrame = Window.Current.Content as Frame;

            if (rootFrame == null)
            {
                rootFrame = new Frame();
                Window.Current.Content = rootFrame;
            }

            rootFrame.Navigate(typeof(SharePage), args);
            Window.Current.Activate();
        }

        private static void InitializeSearch(String queryText)
        {
            var rootFrame = Window.Current.Content as Frame;

            if (rootFrame == null)
            {
                rootFrame = new Frame();
                Window.Current.Content = rootFrame;
            }

            rootFrame.Navigate(typeof(SearchPage), queryText);
            Window.Current.Activate();
        }
    }
}
