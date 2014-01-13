using Appbar_MessageDialog_Popup_y_ViewStates.Helper;
using Appbar_MessageDialog_Popup_y_ViewStates.UsersControl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página básica está documentada en http://go.microsoft.com/fwlink/?LinkId=234237

namespace Appbar_MessageDialog_Popup_y_ViewStates.ViewModels
{
    /// <summary>
    /// Página básica que proporciona características comunes a la mayoría de las aplicaciones.
    /// </summary>
    public sealed partial class TheNewPage : Appbar_MessageDialog_Popup_y_ViewStates.Common.LayoutAwarePage
    {
        public TheNewPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Rellena la página con el contenido pasado durante la navegación. Cualquier estado guardado se
        /// proporciona también al crear de nuevo una página a partir de una sesión anterior.
        /// </summary>
        /// <param name="navigationParameter">Valor de parámetro pasado a
        /// <see cref="Frame.Navigate(Type, Object)"/> cuando se solicitó inicialmente esta página.
        /// </param>
        /// <param name="pageState">Diccionario del estado mantenido por esta página durante una sesión
        /// anterior. Será null la primera vez que se visite una página.</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
        }

        /// <summary>
        /// Mantiene el estado asociado con esta página en caso de que se suspenda la aplicación o
        /// se descarte la página de la memoria caché de navegación. Los valores deben cumplir los requisitos
        /// de serialización de <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">Diccionario vacío para rellenar con un estado serializable.</param>
        protected override void SaveState(Dictionary<String, Object> pageState)
        {
        }

        private async void BtnMessageClick(object sender, RoutedEventArgs e)
        {
            // Este estilo de mensaje se usa para dar un dato muy importante, debido a que paraliza la interfaz
            var message = new MessageDialog("Hola esto es un mensaje", "Mensage");
            message.Commands.Add(new UICommand("Aceptar"));
            message.Commands.Add(new UICommand("Cancelar"));
            var result = await message.ShowAsync();

            switch (result.Label)
            {
                case "Aceptar":
                    //Todo
                    break;
                default:
                    break;
            }
        }

        PopUpHelper popHelper = new PopUpHelper();
        VolumeControl volControl = new VolumeControl();

        private void BtnVolumeClick(object sender, RoutedEventArgs e)
        {
            var boton = (Button)sender;
            var transformada = boton.TransformToVisual(Window.Current.Content);
            var location = transformada.TransformPoint(default(Point));
            location.Y -= (volControl.Height + 5);
            popHelper.show(volControl, location);
        }
    }
}
