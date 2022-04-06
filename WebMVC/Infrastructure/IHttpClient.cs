using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

namespace WebMVC.Infrastructure
{
    public interface IHttpClient
    {
        Task<string> GetStringAsync(string uri, string authorizationtodekn=null,
            string authorizationmethod="Bearer");

        Task<HttpResponseMessage> PostAsync <T>(string uri, T item,
            string authorizationtodekn = null,
            string authorizationmethod = "Bearer");

        Task<HttpResponseMessage> PutAsync<T>(string uri, T item,
            string authorizationtodekn = null,
            string authorizationmethod = "Bearer");

        Task<HttpResponseMessage> DeleteAsync<T>(string uri,
            string authorizationtodekn = null,
            string authorizationmethod = "Bearer");
    }
}
