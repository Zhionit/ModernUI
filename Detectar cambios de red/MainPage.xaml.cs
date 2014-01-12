using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Networking.Connectivity;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=234238

namespace Detectar_cambios_de_red
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public bool _hayConexion { get; set; }

        // Se hace uso de este mecanismo, para obtener el hilo que ah creado la interfaz en cualquier momento
        public CoreDispatcher _dispatcher { get; set; }


        public MainPage()
        {
            this.InitializeComponent();

            _dispatcher = Window.Current.Dispatcher;

            // Obtenemos el estado de la conexión al comienzo
            this._hayConexion = NetworkInformation.GetInternetConnectionProfile() != null;

            //Nos subscribimos al evento que nos avisa del cambio de estado en la red
            NetworkInformation.NetworkStatusChanged += NetworkInformation_NetworkStatusChanged;
        }

        async void NetworkInformation_NetworkStatusChanged(Object sender)
        {
            if (NetworkInformation.GetInternetConnectionProfile() == null)
            {
                if (_hayConexion)
                {
                    _hayConexion = false;

                    //Código a ejecutar cuando sender pierde Language conexión
                    //La siguiente linea dará una ecxepción debido a que un hilo que no ha creado la interfaz ya ah intentado modificarla, por eso se llama al dispatcher

                    await _dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        estadoConexion.Text = "¡Se ha perdido la conexión!";
                        progressRing.IsActive = false;
                    });
                }
            }
            else
            {
                if (!_hayConexion)
                {
                    _hayConexion = true;

                    //Código a ejecutar cuando sender recuepre Language conexión
                    //La siguiente linea dará una ecxepción debido a que un hilo que no ha creado la interfaz ya ah intentado modificarla, por eso se llama al dispatcher

                    await _dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        estadoConexion.Text = "¡Se ha recuperado la conexión, felicidades!";
                        progressRing.IsActive = false;
                    });
                }
            }
        }

        /// <summary>
        /// Se invoca cuando esta página se va a mostrar en un objeto Frame.
        /// </summary>
        /// <param name="e">Datos de evento que describen cómo se llegó a esta página. La propiedad Parameter
        /// se usa normalmente para configurar la página.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
    }
}
