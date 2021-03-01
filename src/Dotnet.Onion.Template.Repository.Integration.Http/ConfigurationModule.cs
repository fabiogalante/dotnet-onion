using Dotnet.Onion.Template.Domain.Integration.Http;
using Dotnet.Onion.Template.Integration.Http.Integrations;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnet.Onion.Template.Integration.Http
{
    public static class ConfigurationModule
    {
        public static void RegisterIntegration(this IServiceCollection services)
        {
           services.AddScoped<IBusinessPartnersIntegration, BusinessPartnersIntegration>();

        }
    }
}
