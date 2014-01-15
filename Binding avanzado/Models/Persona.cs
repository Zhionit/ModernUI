using Binding_avanzado.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binding_avanzado.Models
{
    public class Persona : BindableBase
    {
        private String _nombre;
        public String Nombre
        {
            get { return _nombre; }
            set { SetProperty(ref _nombre, value); }
        }

        private String _descripcion;
        public String Descripcion
        {
            get { return _descripcion; }
            set { SetProperty(ref _descripcion, value); }
        }

        private Uri _imgUri;
        public Uri ImgUri
        {
            get { return _imgUri; }
            set { SetProperty(ref _imgUri, value); }
        }
        

    }
}
