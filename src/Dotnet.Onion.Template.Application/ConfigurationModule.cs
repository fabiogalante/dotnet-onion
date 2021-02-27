using Dotnet.Onion.Template.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnet.Onion.Template.Application
{
    public static class ConfigurationModule
    {
        public static void RegisterService(this IServiceCollection services)
        {

            services.AddScoped<ITaskService, TaskService>();
        }
    }
}
