﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
        public Task<HttpResponseMessage> DeleteAsync<T>(string uri, string authorizationtodekn = null, string authorizationmethod = "Bearer")
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetStringAsync(string uri, string authorizationToken = null, string authorizationMethod = "Bearer")
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get,uri);

            if (authorizationToken != null)
            {
                requestMessage.Headers.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue
                    (authorizationMethod, authorizationToken);
            }
            var response= await _client.SendAsync(requestMessage);
            Console.WriteLine(response.StatusCode.ToString());
            return await response.Content.ReadAsStringAsync();
        }

        public Task<HttpResponseMessage> PostAsync<T>(string uri, T item, string authorizationtodekn = null, string authorizationmethod = "Bearer")
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> PutAsync<T>(string uri, T item, string authorizationtodekn = null, string authorizationmethod = "Bearer")
        {
            throw new NotImplementedException();
        }
    }
}
