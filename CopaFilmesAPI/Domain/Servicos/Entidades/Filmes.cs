using CopaFilmesAPI.Domain.Servicos.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CopaFilmesAPI.Domain.Servicos.Entidades
{
    public static class Filmes
    {
        private static FilmeVO RetornarGanhador(List<FilmeVO> lista, int posicao1, int posicao2 )
        {
            if(lista[posicao1].Nota == lista[posicao2].Nota)
            {
                List<FilmeVO> novaLista = new List<FilmeVO>();
                novaLista.Add(lista[posicao1]);
                novaLista.Add(lista[posicao2]);
                return novaLista.OrderBy(o => o.Titulo).FirstOrDefault();
            }
            else if(lista[posicao1].Nota > lista[posicao2].Nota)
            {
                return lista[posicao1];
            }
            else
            {
                return lista[posicao2];
            }
        }
        private static FinalistasResultadoVO RetornarGanhador(List<FinalistasResultadoVO> lista, int posicao1, int posicao2)
        {
            if (lista[posicao1].Nota == lista[posicao2].Nota)
            {
                List<FinalistasResultadoVO> novaLista = new List<FinalistasResultadoVO>();
                novaLista.Add(lista[posicao1]);
                novaLista.Add(lista[posicao2]);
                return novaLista.OrderBy(o => o.Titulo).FirstOrDefault();
            }
            else if (lista[posicao1].Nota > lista[posicao2].Nota)
            {
                return lista[posicao1];
            }
            else
            {
                return lista[posicao2];
            }
        }

        private static FinalistasResultadoVO CriarFinalistasResultadoVO(FilmeVO filmeGanhador, int posicao)
        {
            FinalistasResultadoVO filmeGanhadorVO = new FinalistasResultadoVO();
            filmeGanhadorVO.Id = filmeGanhador.Id;
            filmeGanhadorVO.Ano = filmeGanhador.Ano;
            filmeGanhadorVO.Nota = filmeGanhador.Nota;
            filmeGanhadorVO.Titulo = filmeGanhador.Titulo;
            filmeGanhadorVO.Rodada = posicao;

            return filmeGanhadorVO;
        }
        
        public static List<FinalistasResultadoVO> ObterGanhadores(List<FilmeVO> filmesSelecionados)
        {
            var listaFilmesOrdenados = filmesSelecionados.OrderBy(o => o.Titulo).ToList();

            List<FinalistasResultadoVO> vencedoresPrimeiraFase = new List<FinalistasResultadoVO>();
            int contador = filmesSelecionados.Count();
            for (int i = 0; i < contador / 2; i++)
            {
                var filmeGanhador = RetornarGanhador(filmesSelecionados, i, (contador - 1) - i);
                vencedoresPrimeiraFase.Add(CriarFinalistasResultadoVO(filmeGanhador,i));
            }

            return vencedoresPrimeiraFase.OrderBy(o => o.Rodada).ToList();
        }

        public static  List<FinalistasResultadoVO> ObterFinal(List<FinalistasResultadoVO> vencedoresPrimeiraFase)
        {
            List<FinalistasResultadoVO> finalistas = new List<FinalistasResultadoVO>();
            int contador = vencedoresPrimeiraFase.Count();
            for (int i = 0; i < contador / 2; i++)
            {
                var filmeFinalista = RetornarGanhador(vencedoresPrimeiraFase, i, (contador - 1) - i);
                filmeFinalista.Rodada = i;
                finalistas.Add(filmeFinalista);
            }
            return finalistas.OrderByDescending(o => o.Nota).ThenBy(t => t.Titulo).ToList();
        }

    }
}
