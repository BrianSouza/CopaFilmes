using CopaFilmesApp.Model;
using CopaFilmesApp.ViewModel;
using System;
using Xamarin.Forms;

namespace CopaFilmesApp.View
{
    public partial class ListaFilmesView : ContentPage
    {
        ListaFilmesViewModel vmFilmes;
        public ListaFilmesView()
        {
            InitializeComponent();
            vmFilmes = new ListaFilmesViewModel();
            BindingContext = vmFilmes;
        }

        private void MenuItem_Clicked(object sender, EventArgs e)
        {
            //Por algum motivo(vou verificar depois) meu command nao esta sendo chamado, para dar continuidade ao projeto farei via UI.
            var filme = ((MenuItem)sender).CommandParameter;
            vmFilmes.ExcluirFilme((FilmesModel)filme);
        }
        
    }
}
