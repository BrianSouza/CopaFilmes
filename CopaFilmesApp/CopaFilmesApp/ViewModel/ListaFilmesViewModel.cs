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
        private readonly ICommand iniciarCopaCommand;
        //private ICommand deletarFilmeCommand;
        private readonly FilmesModel filmeSelecionado;


        public ICommand IniciarCopaCommand { get; set; }
        //public ICommand DeletarFilmeCommand
        //{
        //    get => deletarFilmeCommand;
        //    set => SetProperty(ref deletarFilmeCommand, value);
        //}
        public ICommand RefreshList { get; set; }
        public ObservableCollection<FilmesModel> Filmes { get => _filmes; set => SetProperty(ref _filmes, value); }
        public int ContadorHeader { get => _contadorHeader; set => SetProperty(ref _contadorHeader, value); }
        //public FilmesModel FilmeSelecionado { get => filmeSelecionado; set => SetProperty(ref filmeSelecionado, value); }

        public ListaFilmesViewModel()
        {
            IniciarCopaCommand = new Command(async () => await IniciarCopa());
            Task.Run(async () => await CarregarListaFilmes());
            RefreshList = new Command(async () => await CarregarListaFilmes());
        }
        private async Task IniciarCopa()
        {
            if (Filmes.Count == 8)
            {
                ObservableCollection<FilmesFinalistas> finalistas = null;
                System.Collections.Generic.List<FilmesFinalistas> listFinalista = await filmesProvider.SentFilmesAsync(Filmes);
                finalistas = new ObservableCollection<FilmesFinalistas>(listFinalista);
                if (finalistas.Count > 0)
                {
                    await navigation.NavegarParaResultado(finalistas);
                }
            }
            else
            {
                await messageService.ShowAsync("Alerta", "Número de filmes escolhidos deve ser 8.");
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
