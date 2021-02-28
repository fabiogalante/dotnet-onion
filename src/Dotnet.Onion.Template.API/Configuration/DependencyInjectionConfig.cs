using Dotnet.Onion.Template.Application;
using Dotnet.Onion.Template.Domain;
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

            services.RegisterApplication();
            
            services.RegisterRepository(configuration.GetConnectionString("AuxConnection"),configuration);

            return services;
        }
    }
}
