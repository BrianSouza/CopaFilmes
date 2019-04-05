using CopaFilmesAPI.Application;
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
    }
}
