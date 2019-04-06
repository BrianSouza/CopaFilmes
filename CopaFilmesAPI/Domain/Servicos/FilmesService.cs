using AutoMapper;
using CopaFilmesAPI.Domain.Servicos.Entidades;
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
        private readonly IMapper _mapper;
        public FilmesService(IFilmesFacade filmesFacade, IMapper mapper)
        {
            _filmesFacade = filmesFacade;
            _mapper = mapper;
        }
        public IEnumerable<FilmeVO> ObterFilmes()
        {
           
            return _filmesFacade.ObterFilmes();
        }

        public List<FinalistasResultadoVO> ObterFinalistas(List<FilmeVO> filmesSelecionados)
        {
            var ganhadores = Filmes.ObterGanhadores(filmesSelecionados);
            var finalistas = Filmes.ObterFinal(ganhadores);
            return finalistas;
        }
        
    }
}
