using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace WebMVC.Infrastructure
{
    public class CustomHttpClient : IHttpClient
    {
        private readonly HttpClient _client;

        public CustomHttpClient()
        {
            _client = new HttpClient();
        }
     

        public async Task<string> GetStringAsync(string uri, string authorizationtoken = null, string authorizationMethod = "Bearer")
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get,uri);

            if (authorizationtoken != null)
            {
                requestMessage.Headers.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue
                    (authorizationMethod, authorizationtoken);
            }
            var response= await _client.SendAsync(requestMessage);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<HttpResponseMessage> PostAsync<T>(string uri, T item, string authorizationtoken = null, string authorizationmethod = "Bearer")
        {
            return await DoPostPutAsync(uri, HttpMethod.Post, item, authorizationtoken, authorizationmethod);
            
        }

        public async Task<HttpResponseMessage> PutAsync<T>(string uri, T item, string authorizationtoken = null, string authorizationmethod = "Bearer")
        {
            return await DoPostPutAsync(uri, HttpMethod.Put, item, authorizationtoken, authorizationmethod);
        }

        public async Task<HttpResponseMessage> DeleteAsync(string uri, string authorizationtoken = null, string authorizationmethod = "Bearer")
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            if (authorizationtoken != null)
            {
                requestMessage.Headers.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue
                    (authorizationmethod, authorizationtoken);
            }
            return (await _client.SendAsync(requestMessage));
        }

        private async Task<HttpResponseMessage> DoPostPutAsync<T>(string uri, HttpMethod method, T item, string authorizationtoken, string authorizationmethod)
        {
            if (method != HttpMethod.Put && method != HttpMethod.Post)
            {
                throw new ArgumentException("Value must be either put or post", nameof(method));
            }
            var requestMessage = new HttpRequestMessage(method, uri);
            requestMessage.Content = new StringContent(JsonConvert.SerializeObject(item), System.Text.Encoding.UTF8, "application/json");

            if (authorizationtoken != null)
            {
                requestMessage.Headers.Authorization =
                    new AuthenticationHeaderValue
                    (authorizationmethod, authorizationtoken);
            }
            var response= await _client.SendAsync(requestMessage);
            if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                throw new HttpRequestException();
            }
            return response;
        }
    }
}
