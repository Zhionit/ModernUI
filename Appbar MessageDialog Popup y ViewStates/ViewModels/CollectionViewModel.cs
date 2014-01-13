using Appbar_MessageDialog_Popup_y_ViewStates.Common;
using Appbar_MessageDialog_Popup_y_ViewStates.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appbar_MessageDialog_Popup_y_ViewStates.ViewModels
{
    public class CollectionViewModel: BindableBase
    {

        private PersonCollection _peopleList = new PersonCollection();

        public PersonCollection PeopleList
        {
            get { return _peopleList; }
            set { SetProperty(ref _peopleList, value); }
        }

        
        public CollectionViewModel()
        {

            _peopleList.Add(new Persona()
            {
                Nombre = "Personilla 1",
                Descripcion = "Se supone que es la personilla 1",
                ImgUri = new Uri("ms-appx:///Assets/Logo.png")
            });

            _peopleList.Add(new Persona()
            {
                Nombre = "Personilla 2",
                Descripcion = "Se supone que es la personilla 2",
                ImgUri = new Uri("ms-appx:///Assets/Logo.png")
            });

            _peopleList.Add(new Persona()
            {
                Nombre = "Personilla 3",
                Descripcion = "Se supone que es la personilla 3",
                ImgUri = new Uri("ms-appx:///Assets/Logo.png")
            });

            _peopleList.Add(new Persona()
            {
                Nombre = "Personilla 4",
                Descripcion = "Se supone que es la personilla 4",
                ImgUri = new Uri("ms-appx:///Assets/Logo.png")
            });

            _peopleList.Add(new Persona()
            {
                Nombre = "Personilla 5",
                Descripcion = "Se supone que es la personilla 5",
                ImgUri = new Uri("ms-appx:///Assets/Logo.png")
            });
        }
    }
}
