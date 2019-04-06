using AutoMapper;
using CopaFilmesAPI.Application.DTOs.Request;
using CopaFilmesAPI.Application.DTOs.Response;
using CopaFilmesAPI.Domain.Servicos.Interfaces;
using CopaFilmesAPI.Domain.Servicos.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CopaFilmesAPI.Application
{
    public class FilmesApplication
    {
        IFilmesService _filmesService;
        private readonly IMapper _mapper;

        public FilmesApplication(IFilmesService filmesService, IMapper mapper)
        {
            _filmesService = filmesService;
            _mapper = mapper;
        }

        public IEnumerable<FilmesResponse> ObterFilmes()
        {
            return _mapper.Map<IEnumerable<FilmesResponse>>(_filmesService.ObterFilmes());
        }

        public List<FilmesFinalistasResponse> ObterFilmesFinalistas(List<FilmesRequest> filmesSelecionados)
        {
            return _mapper.Map<List<FilmesFinalistasResponse>>(_filmesService.ObterFinalistas(_mapper.Map<List<FilmeVO>>(filmesSelecionados)));
        }
    }
}
