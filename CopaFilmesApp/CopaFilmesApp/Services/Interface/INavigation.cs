using CopaFilmesApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace CopaFilmesApp.Services.Interface
{
    public interface INavigation
    {
        Task NavegarParaResultado(ObservableCollection<FilmesFinalistas> listaResultado);
    }
}
