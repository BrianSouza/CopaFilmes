using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CopaFilmesApp.Services.Interface
{
    public class MessageService : IMessageService
    {
        public MessageService()
        {

        }
        public async Task ShowAsync(string titulo,string mensagem)
        {
            await CopaFilmesApp.App.Current.MainPage.DisplayAlert(titulo, mensagem, "OK");
        }
    }
}
