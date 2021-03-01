﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Dotnet.Onion.Template.Helpers.HttpClient.Configuration;
using Dotnet.Onion.Template.Helpers.HttpClient.Interfaces;
using Dotnet.Onion.Template.Helpers.HttpClient.Login;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;


namespace Dotnet.Onion.Template.Helpers.HttpClient
{
    public class HttpHelper : IHttpHelper
    {
        private readonly IHttpClientFactory _clientFactory;
        private string _cookie = "B1SESSION";
        private readonly string _serviceLayerUrl;
        private readonly string _companyDb;
        private readonly IDistributedCache _redisCache;
        private readonly string _password;
        private readonly string _userName;
        private const string KeyServiceLayer = "SessionId_ServiceLayer";

        public HttpHelper(IHttpClientFactory clientFactory, IDistributedCache redisCache, IOptions<ServiceLayerOptions> options)
        {
            _clientFactory = clientFactory;
            _redisCache = redisCache;
            _serviceLayerUrl = options.Value.ServiceLayerUrl;
            _companyDb = options.Value.CompanyDb;
            _userName = options.Value.UserName;
            _password = options.Value.Passwrod;

        }

        

        public async Task<HttpResponseMessage> PostRequest<TRequest>(string url, TRequest request, TimeSpan? timeout = null, Dictionary<string, string> headers = null)
        {
            return await RequestServiceLayer<TRequest>(HttpMethod.Post, url, request, timeout, headers);
        }

        public async Task<HttpResponseMessage> GetRequest(string url, TimeSpan? timeout = null, Dictionary<string, string> headers = null)
        {
            return await RequestServiceLayer(HttpMethod.Get, url, timeout);
        }

        public async Task<HttpResponseMessage> PutRequest<TRequest>(string url, TRequest request, TimeSpan? timeout = null, Dictionary<string, string> headers = null)
        {
            return await Request<TRequest>(HttpMethod.Put, url, request, timeout, headers);
        }

        public async Task<HttpResponseMessage> DeleteRequest(string url, TimeSpan? timeout = null, Dictionary<string, string> headers = null)
        {
            return await Request(HttpMethod.Delete, url, timeout, headers);
        }

        private async Task<HttpResponseMessage> Request<TRequest>(HttpMethod method, string url, TRequest request, TimeSpan? timeout = null, Dictionary<string, string> headers = null)
        {
            var client = _clientFactory.CreateClient();

            client.BaseAddress = new Uri(url);
            client.Timeout = timeout ?? TimeSpan.FromSeconds(30);
            client.DefaultRequestHeaders.Clear();

            var httpRequestMessage = new HttpRequestMessage(method, client.BaseAddress);

            if (headers != null)
            {
                foreach (var item in headers)
                {
                    httpRequestMessage.Headers.Add(item.Key, item.Value);
                }
            }

            var serializedParameters = JsonConvert.SerializeObject(request);
            httpRequestMessage.Content = new StringContent(serializedParameters);
            httpRequestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.SendAsync(httpRequestMessage);
            return response;
        }

        private async Task<HttpResponseMessage> Request(HttpMethod method, string url, TimeSpan? timeout = null, Dictionary<string, string> headers = null)
        {
            var client = _clientFactory.CreateClient();

            client.BaseAddress = new Uri(url);
            client.Timeout = timeout ?? TimeSpan.FromSeconds(30);
            client.DefaultRequestHeaders.Clear();

            var httpRequestMessage = new HttpRequestMessage(method, client.BaseAddress);

            if (headers != null)
            {
                foreach (var item in headers)
                {
                    httpRequestMessage.Headers.Add(item.Key, item.Value);
                }
            }

            var response = await client.SendAsync(httpRequestMessage);
            return response;
        }

        private async Task<HttpResponseMessage> RequestServiceLayer<TRequest>(HttpMethod method, string url, TRequest request, TimeSpan? timeout = null, Dictionary<string, string> headers = null)
        {

            var sessionId = await SessionId();

            var client = _clientFactory.CreateClient("ServiceLayer");

            client.BaseAddress = new Uri(url);
            client.Timeout = timeout ?? TimeSpan.FromSeconds(30);
            client.DefaultRequestHeaders.Clear();

            var httpRequestMessage = new HttpRequestMessage(method, client.BaseAddress);

            if (headers != null)
            {
                foreach (var item in headers)
                {
                    httpRequestMessage.Headers.Add(item.Key, item.Value);
                }
            }

            httpRequestMessage.Headers.Add(_cookie, sessionId);
            var serializedParameters = JsonConvert.SerializeObject(request);
            httpRequestMessage.Content = new StringContent(serializedParameters);
            httpRequestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            
            var response = await client.SendAsync(httpRequestMessage);
            return response;
        }



        private async Task<string> SessionId()
        {
            var sessionIdCache = await _redisCache.GetStringAsync(KeyServiceLayer);
            
            if (string.IsNullOrWhiteSpace(sessionIdCache))
            {
                var request = new LoginServiceLayer
                {
                    CompanyDB = _companyDb,
                    Password = _password,
                    UserName = _userName
                };

                var client = _clientFactory.CreateClient("ServiceLayer");
                var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, client.BaseAddress);
                var serializedParameters = JsonConvert.SerializeObject(request);
                httpRequestMessage.Content = new StringContent(serializedParameters);
                var response = await client.PostAsync($"{_serviceLayerUrl}/Login", httpRequestMessage.Content);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responseLogin = System.Text.Json.JsonSerializer.Deserialize<LoginResponse>(await response.Content.ReadAsStringAsync());
                    var cacheSettings = new DistributedCacheEntryOptions();
                    cacheSettings.SetAbsoluteExpiration(TimeSpan.FromMinutes(25));
                    await _redisCache.SetStringAsync(KeyServiceLayer, responseLogin?.SessionId, cacheSettings);
                    return responseLogin?.SessionId;
                }
            }

            return await Task.FromResult(sessionIdCache);
        }
    }
}




