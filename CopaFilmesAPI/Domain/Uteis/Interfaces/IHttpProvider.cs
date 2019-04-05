using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CopaFilmesAPI.Domain.Uteis.Interfaces
{
    interface IHttpProvider
    {
        Task<T> GetAsync<T>(string path, string authToken = "");
        Task<T> PostAsync<T>(string path, T data, string authToken = "");
        Task<TR> PostAsync<T, TR>(string path, T data, string authToken = "");
        Task<T> PutAsync<T>(string path, T data, string authToken = "");
        Task DeleteAsync(string path, string authToken = "");
    }
}
