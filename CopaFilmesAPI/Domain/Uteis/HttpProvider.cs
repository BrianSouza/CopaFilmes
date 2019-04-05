using CopaFilmesAPI.Domain.Uteis.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CopaFilmesAPI.Domain.Uteis
{
    public class HttpProvider : IHttpProvider
    {
        readonly string _baseApiUrl;
        public HttpProvider(string baseApiUrl)
        {
            _baseApiUrl = baseApiUrl;
        }
        public async Task<T> GetAsync<T>(string path, string authToken = "")
        {
            try
            {
                UriBuilder builder = new UriBuilder(_baseApiUrl)
                {
                    Path = path
                };
                var uri = builder.ToString();
                HttpClient httpClient = CriarClienteHttp(uri);
                string jsonResult = string.Empty;

                var responseMessage = await httpClient.GetAsync(uri);

                if (responseMessage.IsSuccessStatusCode)
                {
                    jsonResult =
                        await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var json = JsonConvert.DeserializeObject<T>(jsonResult);
                    return json;
                }

                if (responseMessage.StatusCode == HttpStatusCode.Forbidden ||
                    responseMessage.StatusCode == HttpStatusCode.Unauthorized)
                {
                    //throw new ServiceAuthenticationException(jsonResult);
                }

                throw new Exception(string.Format("{0}{1}", responseMessage.StatusCode, jsonResult));

            }
            catch (Exception e)
            {
                Debug.WriteLine($"{ e.GetType().Name + " : " + e.Message}");
                throw;
            }
        }

        public async Task<T> PostAsync<T>(string path, T data, string authToken = "")
        {
            try
            {
                UriBuilder builder = new UriBuilder(_baseApiUrl)
                {
                    Path = path
                };
                var uri = builder.ToString();

                HttpClient httpClient = CriarClienteHttp(uri);

                var content = new StringContent(JsonConvert.SerializeObject(data));
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                string jsonResult = string.Empty;

                var responseMessage = await httpClient.PostAsync(uri, content);

                if (responseMessage.IsSuccessStatusCode || responseMessage.StatusCode == HttpStatusCode.BadRequest)
                {
                    jsonResult = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var json = JsonConvert.DeserializeObject<T>(jsonResult);
                    return json;
                }

                if (responseMessage.StatusCode == HttpStatusCode.Forbidden ||
                    responseMessage.StatusCode == HttpStatusCode.Unauthorized)
                {
                    //throw new ServiceAuthenticationException(jsonResult);
                }

                throw new Exception(string.Format("{0}{1}", responseMessage.StatusCode, jsonResult));

            }
            catch (Exception e)
            {
                Debug.WriteLine($"{ e.GetType().Name + " : " + e.Message}");
                throw;
            }
        }

        public async Task<TR> PostAsync<T, TR>(string path, T data, string authToken = "")
        {
            try
            {
                UriBuilder builder = new UriBuilder(_baseApiUrl)
                {
                    Path = path
                };
                var uri = builder.ToString();

                HttpClient httpClient = CriarClienteHttp(authToken);

                var content = new StringContent(JsonConvert.SerializeObject(data));
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                string jsonResult = string.Empty;

                var responseMessage = await httpClient.PostAsync(uri, content);

                if (responseMessage.IsSuccessStatusCode)
                {
                    jsonResult = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var json = JsonConvert.DeserializeObject<TR>(jsonResult);
                    return json;
                }
                if (responseMessage.StatusCode == HttpStatusCode.BadRequest)
                {
                    jsonResult = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var obj = JsonConvert.DeserializeObject<TR>(jsonResult);

                    return obj;
                }

                if (responseMessage.StatusCode == HttpStatusCode.Forbidden ||
                    responseMessage.StatusCode == HttpStatusCode.Unauthorized)
                {
                    //throw new ServiceAuthenticationException(jsonResult);
                }

                throw new Exception(string.Format("{0}{1}", responseMessage.StatusCode, jsonResult));

            }
            catch (Exception e)
            {
                Debug.WriteLine($"{ e.GetType().Name + " : " + e.Message}");
                throw;
            }
        }

        public async Task<T> PutAsync<T>(string path, T data, string authToken = "")
        {
            try
            {
                UriBuilder builder = new UriBuilder(_baseApiUrl)
                {
                    Path = path
                };
                var uri = builder.ToString();

                HttpClient httpClient = CriarClienteHttp(uri);

                var content = new StringContent(JsonConvert.SerializeObject(data));
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                string jsonResult = string.Empty;

                var responseMessage = await httpClient.PutAsync(uri, content);

                if (responseMessage.IsSuccessStatusCode)
                {
                    jsonResult = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var json = JsonConvert.DeserializeObject<T>(jsonResult);
                    return json;
                }

                if (responseMessage.StatusCode == HttpStatusCode.Forbidden ||
                    responseMessage.StatusCode == HttpStatusCode.Unauthorized)
                {
                    //throw new ServiceAuthenticationException(jsonResult);
                }

                throw new Exception(string.Format("{0}{1}", responseMessage.StatusCode, jsonResult));

            }
            catch (Exception e)
            {
                Debug.WriteLine($"{ e.GetType().Name + " : " + e.Message}");
                throw;
            }
        }

        public async Task DeleteAsync(string path, string authToken = "")
        {
            UriBuilder builder = new UriBuilder(_baseApiUrl)
            {
                Path = path
            };
            var uri = builder.ToString();

            HttpClient httpClient = CriarClienteHttp(authToken);
            await httpClient.DeleteAsync(uri);
        }

        private HttpClient CriarClienteHttp(string authToken)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            if (!string.IsNullOrEmpty(authToken))
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
            }
            return httpClient;
        }
    }
}
