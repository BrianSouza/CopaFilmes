using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CopaFilmesAPI.Application;
using CopaFilmesAPI.Domain.Servicos;
using CopaFilmesAPI.Domain.Servicos.Facades;
using CopaFilmesAPI.Domain.Servicos.Facades.Interfaces;
using CopaFilmesAPI.Domain.Servicos.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CopaFilmesAPI.IoC
{
    public class Container
    {
        public static void Registrar(IServiceCollection services)
        {
            services.AddScoped(typeof(IFilmesService), typeof(FilmesService));
            services.AddScoped(typeof(FilmesApplication));
            services.AddScoped(typeof(IFilmesFacade), typeof(FilmesFacade));
        }
    }
}
