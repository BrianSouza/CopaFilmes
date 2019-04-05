using CopaFilmesAPI.Domain.Servicos.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CopaFilmesAPI.Domain.Servicos.Facades.Interfaces
{
    public interface IFilmesFacade
    {
        IEnumerable<FilmeVO> ObterFilmes();
    }
}
