using CopaFilmesApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CopaFilmesApp.ViewModel
{
    public class ResultadoViewModel : BaseViewModel
    {
        //private ObservableCollection<FilmesFinalistas> _listaFinalistas;
        //public ObservableCollection<FilmesFinalistas> ListaFinalistas { get => _listaFinalistas; set => SetProperty(ref _listaFinalistas, value); }
        private string tituloPrimeiro;
        private string tituloSegundo;
        public string TituloPrimeiro { get => tituloPrimeiro; set => SetProperty(ref tituloPrimeiro ,value); }
        public string TituloSegundo { get => tituloSegundo; set => SetProperty(ref tituloSegundo , value); }

        public ResultadoViewModel(ObservableCollection<FilmesFinalistas> listaFinalistas)
        {
            TituloPrimeiro = listaFinalistas[0].Titulo;
            TituloSegundo = listaFinalistas[1].Titulo;
        }

    }
}
