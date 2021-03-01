using System.Net.Http;
using Dotnet.Onion.Template.Helpers.HttpClient.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnet.Onion.Template.Helpers.HttpClient.Extensions
{
    public static class HttpClientExtension
    {
        public static IServiceCollection AddHttpClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IHttpHelper), typeof(HttpHelper));

            services.AddHttpClient<HttpHelper>("ServiceLayer").ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
            {
                ClientCertificateOptions = ClientCertificateOption.Manual,
                ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, cetChain, policyErrors) => true
            });


          



            return services;
        }
    }
}
