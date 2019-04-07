using CopaFilmesApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CopaFilmesApp.Services.Interface
{
    public interface IFilmesProvider
    {
        Task<List<FilmesModel>> GetFilmesAsync();
        Task<List<FilmesFinalistas>> SentFilmesAsync(ObservableCollection<FilmesModel> filmesSelecionados);
    }
}
