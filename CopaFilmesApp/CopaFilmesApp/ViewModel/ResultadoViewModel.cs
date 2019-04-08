using CopaFilmesApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CopaFilmesApp.ViewModel
{
    public class ResultadoViewModel : BaseViewModel
    {
        private ObservableCollection<FilmesFinalistas> _listaFinalistas;
        public ObservableCollection<FilmesFinalistas> ListaFinalistas { get => _listaFinalistas; set => SetProperty(ref _listaFinalistas, value); }
       
        public ResultadoViewModel(ObservableCollection<FilmesFinalistas> listaFinalistas)
        {
            listaFinalistas[0].Rodada = 1;
            listaFinalistas[1].Rodada = 2;
            ListaFinalistas = listaFinalistas;
        }

    }
}
