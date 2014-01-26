using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
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

// La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=234238

namespace Context_Menu
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            txtReadOnly.ContextMenuOpening += new ContextMenuOpeningEventHandler(txtReadOnly_ContextMenuOpening);
        }

        private async void txtReadOnly_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            // True evita que algunos controladores vuelvan a controlar el evento de nuevo
            e.Handled = true;
            TextBox textBox = (TextBox)sender;

            // Nos aseguramos de haber seleccionado texto
            if (textBox.SelectionLength > 0)
            {
                // Se crea el menu y adicionamos los comandos con sus respectivas id
                var menu = new PopupMenu();
                menu.Commands.Add(new UICommand("Copiar", null, 1));

                // Se crea un rectangulo para el texto seleccionado
                Rect rect = GetTextboxSelectionRect(textBox);

                // Obtenemos de manera asincrona el comando elegido
                var comandoEscogido = await menu.ShowForSelectionAsync(rect);

                if (comandoEscogido != null)
                {
                    // Dependiendo de la cantidad de comandos que tenemos así mismo son los casos
                    switch ((int)comandoEscogido.Id)
                    {
                        case 1:
                            String textoEscogido = txtReadOnly.SelectedText;
                            
                            // Se crea un dataPackege Para poder pasarlo como parametro al ClipBoard
                            var dataPackage = new DataPackage();

                            // Modificamos el texto del dataPackage
                            dataPackage.SetText(textoEscogido);

                            // agregamos finalmente el texto al ClipBoard
                            Clipboard.SetContent(dataPackage);
                            break;
                    }
                }
            }
        }

        // Se crea el Rectangulom y su posición 
        private Rect GetTextboxSelectionRect(TextBox textbox)
        {
            Rect rectFirst, rectLast;
            if (textbox.SelectionStart == textbox.Text.Length)
            {
                rectFirst = textbox.GetRectFromCharacterIndex(textbox.SelectionStart - 1, true);
            }
            else
            {
                rectFirst = textbox.GetRectFromCharacterIndex(textbox.SelectionStart, false);
            }

            int lastIndex = textbox.SelectionStart + textbox.SelectionLength;
            if (lastIndex == textbox.Text.Length)
            {
                rectLast = textbox.GetRectFromCharacterIndex(lastIndex - 1, true);
            }
            else
            {
                rectLast = textbox.GetRectFromCharacterIndex(lastIndex, false);
            }

            GeneralTransform buttonTransform = textbox.TransformToVisual(null);
            Point point = buttonTransform.TransformPoint(new Point());

            double x, y, dx, dy;
            y = point.Y + rectFirst.Top;
            dy = rectLast.Bottom + rectFirst.Top;
            if (rectLast.Right > rectFirst.Left)
            {
                x = point.X + rectFirst.Left;
                dx = rectLast.Right - rectFirst.Left;
            }
            else
            {
                x = point.X + rectLast.Right;
                dx = rectFirst.Left - rectLast.Right;
            }

            return new Rect(x,y,dx,dy);
        }
    }
}
