using CopaFilmesAPI.Application;
using CopaFilmesAPI.Application.DTOs.Request;
using CopaFilmesAPI.Application.DTOs.Response;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CopaFilmesAPI.Controllers
{
    [Produces("application/json")]
    //[ApiVersion("1.0")]
    [Route("api/[controller]/[action]")]
    public class FilmesController : ControllerBase
    {
        private FilmesApplication _filmeApplication;

        public FilmesController(FilmesApplication filmeApplication)
        {
            _filmeApplication = filmeApplication;
        }

        [HttpGet()]
        [Produces("application/json", Type = typeof(decimal))]
        public IEnumerable<FilmesResponse> ObterFilmes()
        {
            return _filmeApplication.ObterFilmes();
        }

        [HttpGet()]
        [Produces("application/json", Type = typeof(decimal))]
        public IEnumerable<FilmesFinalistasResponse> ObterFilmesFinalistas(List<FilmesRequest> filmesSelecionados)
        {
            filmesSelecionados = new List<FilmesRequest>()
            {
                new FilmesRequest(){ Id= "B", Titulo = " TST B", Ano = 2019 , Nota = 8.5 },
                new FilmesRequest(){ Id= "A", Titulo = " TST A", Ano = 2018 , Nota = 7.5 },
                new FilmesRequest(){ Id= "C", Titulo = " TST C", Ano = 2013 , Nota = 9 },
                new FilmesRequest(){ Id= "E", Titulo = " TST E", Ano = 2018 , Nota = 7 },
                new FilmesRequest(){ Id= "D", Titulo = " TST D", Ano = 2018 , Nota = 9.5 },
                new FilmesRequest(){ Id= "F", Titulo = " TST F", Ano = 2018 , Nota = 7.9 },
                new FilmesRequest(){ Id= "G", Titulo = " TST G", Ano = 2018 , Nota = 7.8},
                new FilmesRequest(){ Id= "H", Titulo = " TST H", Ano = 2018 , Nota = 7.7 },
            };

            return _filmeApplication.ObterFilmesFinalistas(filmesSelecionados);
        }
    }
}
