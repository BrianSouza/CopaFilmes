using CopaFilmesAPI.Domain.Servicos.Facades.Interfaces;
using CopaFilmesAPI.Domain.Servicos.ValueObjects;
using CopaFilmesAPI.Domain.Uteis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CopaFilmesAPI.Domain.Servicos.Facades
{
    public class FilmesFacade: IFilmesFacade
    {
        readonly string _enderecoBaseFilmes;
        public FilmesFacade()
        {
        }
        public IEnumerable<FilmeVO> ObterFilmes()
        {
            IEnumerable<FilmeVO> filmes = null;
            using (var chamada = new HttpProvider("https://copadosfilmes.azurewebsites.net/").GetAsync<IEnumerable<FilmeVO>>("api/filmes", null))
                filmes = chamada.Result;
            return filmes;
        }
    
    }
}
