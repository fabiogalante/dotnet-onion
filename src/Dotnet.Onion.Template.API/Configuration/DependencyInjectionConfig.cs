using Dotnet.Onion.Template.Application;
using Dotnet.Onion.Template.Domain;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using WmsPicking.Api.Configuration;

namespace Dotnet.Onion.Template.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<INotifier, Notifier>();

            services.RegisterService();
            
            services.RegisterRepository();

            return services;
        }
    }
}
