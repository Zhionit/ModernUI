using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Binding_avanzado.Models;
using System.ComponentModel;
using Binding_avanzado.ViewModels;

// La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=234238

namespace Binding_avanzado
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public DefaultViewModel MyViewModel;
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Se invoca cuando esta página se va a mostrar en un objeto Frame.
        /// </summary>
        /// <param name="e">Datos de evento que describen cómo se llegó a esta página. La propiedad Parameter
        /// se usa normalmente para configurar la página.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Fueron definidos en el Xaml 

            //MyViewModel = new DefaultViewModel();
            //this.DataContext = MyViewModel;
        }

        int i = 0;
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var dataContext = (DefaultViewModel)this.DataContext;
            dataContext.DummyString = string.Format("Valor nuevo, # {0}", i++);

            dataContext.Persona1 = new Persona()
            {
                Nombre = "Persona 1",
                Descripcion = "Es la descripcion de la persona 1",
                ImgUri = new Uri("ms-appx:///Assets/Logo.png")
            };
        }
    }
}
