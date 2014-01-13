using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_Search_Y_Share_Contract_DESDE_CERO.Models
{
    public class ListaPersonas:ObservableCollection<Persona>
    {
        public ListaPersonas():base()
        {

        }

        public ListaPersonas(IEnumerable<Persona> lista):base(lista)
        {

        }
    }
}
