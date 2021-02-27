using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WmsPicking.Api.Configuration
{
    public static class HealthChecksConfig
    {
        public static IServiceCollection AddHealthChecksConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks()
                .AddCheck("Select 1", new SqlServerHealthCheck(configuration.GetConnectionString("AuxConnection")))
                .AddSqlServer(configuration.GetConnectionString("AuxConnection"), name: "BancoSQL");

            return services;
        }
    }
}
