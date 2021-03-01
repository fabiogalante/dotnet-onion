using Dotnet.Onion.Template.Application;
using Dotnet.Onion.Template.Domain;
using Dotnet.Onion.Template.Integration.Http;
using Dotnet.Onion.Template.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnet.Onion.Template.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<INotifier, Notifier>();

            services.RegisterIntegration();

            services.RegisterApplication();

            services.RegisterRepository(configuration);

           

            return services;


           
        }
    }
}
