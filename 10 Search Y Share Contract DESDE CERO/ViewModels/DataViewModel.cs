using _10_Search_Y_Share_Contract_DESDE_CERO.Common;
using _10_Search_Y_Share_Contract_DESDE_CERO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_Search_Y_Share_Contract_DESDE_CERO.ViewModels
{
    public class DataViewModel:BindableBase
    {
        private ListaPersonas _lista;

        public ListaPersonas Lista
        {
            get { return _lista; }
            set { SetProperty(ref _lista, value); }
        }

        public DataViewModel()
        {
            var listaPivote = new ListaPersonas()
            {
                new Persona(){ Profesion="Ingeniero", Apellido="Ruiz pacheco", Nombre="Juan Carlos"},
                new Persona(){ Profesion="Médico", Apellido="Montoya Perez", Nombre="Leidy"},
                new Persona(){ Profesion="Análista", Apellido="Gates", Nombre="Bill"},
                new Persona(){ Profesion="Enfermero", Apellido="Jobs", Nombre="Steve"},
                new Persona(){ Profesion="Conductor", Apellido="Tolvars", Nombre="Linus"},
                new Persona(){ Profesion="Piloto", Apellido="Cruise", Nombre="Tom"},
                new Persona(){ Profesion="Capitán", Apellido="Cat Dog", Nombre="Tom"},
                new Persona(){ Profesion="Biólogo", Apellido="Master", Nombre="Osho"},
                new Persona(){ Profesion="Físico", Apellido="Eye", Nombre="Golden"},
                new Persona(){ Profesion="Astrónomo", Apellido="Telecom", Nombre="Telefonica"},
                new Persona(){ Profesion="Developer", Apellido="Ruiz Montolla", Nombre="Mariana"},
                new Persona(){ Profesion="Mixer", Apellido="Jobs Dell", Nombre="Bill Steve"}
            };

            Random genCedula = new Random();
            var cartesianList = (from persona in listaPivote
                                 from persona2 in listaPivote
                                 from persona3 in listaPivote
                                 select new Persona()
                                 {
                                     Cedula = (int)Math.Abs((genCedula.NextDouble() * 999999999)),
                                     Nombre = persona.Nombre,
                                     Apellido = persona2.Apellido,
                                     Profesion = persona3.Profesion
                                 }).OrderBy((o) => o.Cedula);
            Lista = new ListaPersonas(cartesianList);
        }

    }
}
