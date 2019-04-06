using AutoMapper;
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
            var ganhadores = ObterGanhadores(filmesSelecionados);
            var finalistas = ObterFinal(ganhadores);
            return finalistas;
        }

        private List<FinalistasResultadoVO> ObterGanhadores(List<FilmeVO> filmesSelecionados)
        {
            var listaFilmesOrdenados = filmesSelecionados.OrderBy(o => o.Titulo).ToList();

            List<FinalistasResultadoVO> vencedoresPrimeiraFase = new List<FinalistasResultadoVO>();
            int contador = filmesSelecionados.Count();
            for (int i = 0; i < contador/2; i++)
            {
                var filmeGanhador = listaFilmesOrdenados[i].Nota > listaFilmesOrdenados[(contador - 1) - i].Nota ? listaFilmesOrdenados[i] : listaFilmesOrdenados[(contador - 1) - i];

                FinalistasResultadoVO filmeGanhadorVO = new FinalistasResultadoVO();
                filmeGanhadorVO.Id = filmeGanhador.Id;
                filmeGanhadorVO.Ano = filmeGanhador.Ano;
                filmeGanhadorVO.Nota = filmeGanhador.Nota;
                filmeGanhadorVO.Titulo = filmeGanhador.Titulo;
                filmeGanhadorVO.Posicao = i;
                vencedoresPrimeiraFase.Add(filmeGanhadorVO);
            }

            return vencedoresPrimeiraFase.OrderBy( o => o.Posicao).ToList();
        }

        private List<FinalistasResultadoVO> ObterFinal(List<FinalistasResultadoVO> vencedoresPrimeiraFase)
        {
            List<FinalistasResultadoVO> finalistas = new List<FinalistasResultadoVO>();
            int contador = vencedoresPrimeiraFase.Count();
            for (int i = 0; i < contador / 2; i++)
            {
                var filmeFinalista = vencedoresPrimeiraFase[i].Nota > vencedoresPrimeiraFase[(contador - 1) - i].Nota ? vencedoresPrimeiraFase[i] : vencedoresPrimeiraFase[(contador - 1) - i];
                FinalistasResultadoVO filmeFinalistaVO =  new FinalistasResultadoVO();
                filmeFinalistaVO.Id = filmeFinalista.Id;
                filmeFinalistaVO.Ano = filmeFinalista.Ano;
                filmeFinalistaVO.Nota = filmeFinalista.Nota;
                filmeFinalistaVO.Titulo = filmeFinalista.Titulo;
                filmeFinalistaVO.Posicao = i;
                filmeFinalistaVO.Posicao = i;
                finalistas.Add(filmeFinalistaVO);
            }
            return finalistas.OrderByDescending(o => o.Nota).ToList();
        }

        
    }
}
