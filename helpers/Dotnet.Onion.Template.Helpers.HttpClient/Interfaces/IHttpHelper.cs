using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Dotnet.Onion.Template.Helpers.HttpClient.Interfaces
{
    public interface IHttpHelper
    {
        Task<HttpResponseMessage> PostRequest<TRequest>(string url, TRequest request, TimeSpan? timeout = null, Dictionary<string, string> headers = null);
        Task<HttpResponseMessage> PutRequest<TRequest>(string url, TRequest request, TimeSpan? timeout = null, Dictionary<string, string> headers = null);
        Task<HttpResponseMessage> GetRequest(string url, TimeSpan? timeout = null, Dictionary<string, string> headers = null);
        Task<HttpResponseMessage> DeleteRequest(string url, TimeSpan? timeout = null, Dictionary<string, string> headers = null);

    }
}
