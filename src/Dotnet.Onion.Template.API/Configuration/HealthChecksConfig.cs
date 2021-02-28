using HealthChecks.SqlServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnet.Onion.Template.API.Configuration
{
    public static class HealthChecksConfig
    {
        public static IServiceCollection AddHealthChecksConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks()
                .AddCheck("SQL", new SqlServerHealthCheck(configuration.GetConnectionString("AuxConnection"), "Select 1"))
                .AddSqlServer(configuration.GetConnectionString("AuxConnection"), name: "BancoSQL");

            return services;
        }
    }
}
