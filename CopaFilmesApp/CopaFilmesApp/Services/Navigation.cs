using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using CopaFilmesApp.Model;
using CopaFilmesApp.View;

namespace CopaFilmesApp.Services.Interface
{
    public class Navigation : INavigation
    {
        public async Task NavegarParaResultado(ObservableCollection<FilmesFinalistas> listaResultado)
        {
            await CopaFilmesApp.App.Current.MainPage.Navigation.PushAsync(new ResultadoView(listaResultado));
        }
    }
}
