using Dotnet.Onion.Template.Crosscutting.Common.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Dotnet.Onion.Template.API.Configuration
{
    public static class ApiSettingsConfig
    {
        public static void AddApiSettingsConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ApiSettings>(configuration.GetSection(nameof(ApiSettings)));

            services.AddSingleton<ApiSettings>(sp =>
                sp.GetRequiredService<IOptions<ApiSettings>>().Value);
        }
    }
}
