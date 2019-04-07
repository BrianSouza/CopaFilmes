using CopaFilmesApp.Model;
using CopaFilmesApp.Services.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CopaFilmesApp.Services
{
    public class FilmesProvider : IFilmesProvider
    {
        HttpClient client = new HttpClient();
        public async Task<List<FilmesModel>> GetFilmesAsync()
        {
            try
            {
                string  url = "http://192.168.0.40/Filmes/api/Filmes/ObterFilmes/";
                var response = await client.GetStringAsync(url);
                var filmes = JsonConvert.DeserializeObject<List<FilmesModel>>(response);
                return filmes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<FilmesFinalistas>> SentFilmesAsync(ObservableCollection<FilmesModel> filmesSelecionados)
        {
            try
            {
                string url = "http://192.168.0.40/Filmes/api/Filmes/ObterFilmesFinalistas/";
                string jsonString = JsonConvert.SerializeObject(filmesSelecionados);
                var response = await client.PostAsync(url , new StringContent(jsonString, Encoding.UTF8, "application/json"));
                var filmes = JsonConvert.DeserializeObject<List<FilmesFinalistas>>(await response.Content.ReadAsStringAsync());
                return filmes;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
