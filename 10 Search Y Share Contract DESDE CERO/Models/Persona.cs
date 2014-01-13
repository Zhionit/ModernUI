using _10_Search_Y_Share_Contract_DESDE_CERO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace _10_Search_Y_Share_Contract_DESDE_CERO.Models
{
    public class Persona: BindableBase
    {
        private String _nombre;
        public String Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        private String _apellido;

        public String Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }
        
        private int _cedula;
        public int Cedula
        {
            get { return _cedula; }
            set { _cedula = value; }

        }

        private String _profesion;
        public String Profesion
        {
            get { return _profesion; }
            set { _profesion = value; }
        }

        private SolidColorBrush _colorFavorito;
        public SolidColorBrush ColorFavorito
        {
            get { return  _colorFavorito; }
            set { _colorFavorito = value; }
        }

        static readonly Random _colorRamdomizer = new Random();
        public Persona()
        {
            byte[] colorComponents = new byte[3];
            _colorRamdomizer.NextBytes(colorComponents);

            ColorFavorito = new SolidColorBrush( Color.FromArgb(255, colorComponents[0], colorComponents[1], colorComponents[2]) );
        }
    }
}
