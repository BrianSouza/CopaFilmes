using CopaFilmesAPI.Domain.Servicos.Facades.Interfaces;
using CopaFilmesAPI.Domain.Servicos.Interfaces;
using CopaFilmesAPI.Domain.Servicos.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CopaFilmesAPI.Domain.Servicos
{
    public class FilmesService : IFilmesService
    {
        private readonly IFilmesFacade _filmesFacade;
        public FilmesService(IFilmesFacade filmesFacade)
        {
            _filmesFacade = filmesFacade;
        }
        public IEnumerable<FilmeVO> ObterFilmes()
        {
            return _filmesFacade.ObterFilmes();
        }
    }
}
