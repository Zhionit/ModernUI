using Binding_avanzado.Common;
using Binding_avanzado.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binding_avanzado.ViewModels
{
    public class DefaultViewModel: BindableBase
    {

        private String _dummyString;
        public String DummyString
        {
            get { return _dummyString; }
            set { SetProperty(ref _dummyString, value); }
        }
        
        private Persona _persona1;
        public Persona Persona1
        {
            get { return _persona1; }
            set { SetProperty(ref _persona1, value); }
        }

        private Persona _persona2;
        public Persona Persona2
        {
            get { return _persona2; }
            set { SetProperty(ref _persona2, value); }
        }

        private Persona _persona3;
        public Persona Persona3
        {
            get { return _persona3; }
            set { _persona3 = value; }
        }

        private Persona _persona4;
        public Persona Persona4
        {
            get { return _persona4; }
            set { _persona4 = value; }
        }

        private Persona _persona5;
        public Persona Persona5
        {
            get { return _persona5; }
            set { _persona5 = value; }
        }
        

        public DefaultViewModel()
        {

            DummyString = "Valor Original";

            Persona1 = new Persona()
            {
                Nombre = "Personilla 1",
                Descripcion = "Se supone que es la personilla 1",
                ImgUri = new Uri("ms-appx:///Assets/Logo.png")
            };

            Persona2 = new Persona()
            {
                Nombre = "Personilla 2",
                Descripcion = "Se supone que es la personilla 2",
                ImgUri = new Uri("ms-appx:///Assets/Logo.png")
            };

            Persona3 = new Persona()
            {
                Nombre = "Personilla 3",
                Descripcion = "Se supone que es la personilla 3",
                ImgUri = new Uri("ms-appx:///Assets/Logo.png")
            };

            Persona4 = new Persona()
            {
                Nombre = "Personilla 4",
                Descripcion = "Se supone que es la personilla 4",
                ImgUri = new Uri("ms-appx:///Assets/Logo.png")
            };

            Persona5 = new Persona()
            {
                Nombre = "Personilla 5",
                Descripcion = "Se supone que es la personilla 5",
                ImgUri = new Uri("ms-appx:///Assets/Logo.png")
            };
        }
    }
}
