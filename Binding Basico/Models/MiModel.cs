using App4.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace App4.Models
{
    public class MiModel: BindableBase
    {
        // Los comentarios son la lógica básica para notificarle a la interfaz de algún Cambio de implementacion de INotiFyPropertyChanged
        // Que es cambiada por BindableBase Que se optiene al crear una BasicPage

        //public event PropertyChangedEventHandler PropertyChanged;
        //public int MyProperty { get; set; } // Propiedades autoimplementada

        private String _texto1; //Variable de backStore, usado para el binding
        public String Texto1
        {
            get { return _texto1; }
            set
            {
                SetProperty(ref _texto1, value);
                //_texto1 = value;
                //RaisePropertyChanged();
            }
        }

        private String _texto2;

        public String Texto2
        {
            get { return _texto2; }
            set
            {
                SetProperty(ref _texto2, value);
                //_texto2 = value;
                //RaisePropertyChanged();
            }
        }


        //private void RaisePropertyChanged([CallerMemberName] String propertyName = "")
        //{
        //    if (PropertyChanged != null)
        //    {
        //        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //}

    }
}
