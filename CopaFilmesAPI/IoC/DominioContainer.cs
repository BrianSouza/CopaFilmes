using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CopaFilmesAPI.IoC
{
    public class DominioContainer
    {
        private readonly IServiceProvider _resolver;

        public DominioContainer(IServiceProvider resolver)
        {
            _resolver = resolver;
        }

        public object ObterServico(Type serviceType)
        {
            return _resolver.GetService(serviceType);
        }

        public T ObterServico<T>()
        {
            return (T)_resolver.GetService(typeof(T));
        }
    }
}
