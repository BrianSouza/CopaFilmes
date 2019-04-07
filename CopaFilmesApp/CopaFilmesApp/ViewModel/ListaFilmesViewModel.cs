using CopaFilmesApp.Model;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CopaFilmesApp.ViewModel
{
    public class ListaFilmesViewModel : BaseViewModel
    {
        private int _contadorHeader;
        private ObservableCollection<FilmesModel> _filmes;
        private ICommand iniciarCopaCommand;
        //private ICommand deletarFilmeCommand;
        private FilmesModel filmeSelecionado;


        public ICommand IniciarCopaCommand
        {
            get => iniciarCopaCommand;
            set => SetProperty(ref iniciarCopaCommand, value);
        }
        //public ICommand DeletarFilmeCommand
        //{
        //    get => deletarFilmeCommand;
        //    set => SetProperty(ref deletarFilmeCommand, value);
        //}
        public ObservableCollection<FilmesModel> Filmes { get => _filmes; set => SetProperty(ref _filmes, value); }
        public int ContadorHeader { get => _contadorHeader; set => SetProperty(ref _contadorHeader, value); }
        //public FilmesModel FilmeSelecionado { get => filmeSelecionado; set => SetProperty(ref filmeSelecionado, value); }

        public ListaFilmesViewModel()
        {
            IniciarCopaCommand = new Command(IniciarCopa);
            Task.Run(async ()=> await CarregarListaFilmes());
        }
        private void IniciarCopa()
        {
            if (Filmes.Count == 8)
            {
                Task.Run(async () => await filmesProvider.SentFilmesAsync(Filmes));
            }
            else
            {
                messageService.ShowAsync("Alerta", "Número de filmes escolhidos deve ser 8.");
            }
        }

        private async Task CarregarListaFilmes()
        {
            try
            {
                System.Collections.Generic.List<FilmesModel> filmes = new System.Collections.Generic.List<FilmesModel>();
                filmes = await filmesProvider.GetFilmesAsync();
                Filmes = new ObservableCollection<FilmesModel>(filmes);
                ContadorHeader = Filmes.Count;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
                throw;
            }
        }

        public void ExcluirFilme(FilmesModel FilmeSelecionado)
        {
            if (Filmes.Count > 8)
            {
                Filmes.Remove(FilmeSelecionado);
                ContadorHeader = Filmes.Count;
            }
            else
            {
                messageService.ShowAsync("Alerta", "Número de filmes escolhidos deve ser 8.");
            }
        }
    }
}
