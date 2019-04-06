using CopaFilmesAPI.Domain.Servicos.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CopaFilmesAPI.Domain.Servicos.Interfaces
{
    public interface IFilmesService
    {
        IEnumerable<FilmeVO> ObterFilmes();

        List<FinalistasResultadoVO> ObterFinalistas(List<FilmeVO> filmesSelecionados);
    }
}
