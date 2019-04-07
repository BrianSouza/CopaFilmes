using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CopaFilmesApp.Services.Interface
{
    public interface IMessageService
    {
        Task ShowAsync(string titulo, string mensagem);
    }
}
