using Dotnet.Onion.Template.Application.Company.Service;
using Dotnet.Onion.Template.Application.Company.Service.Interface;
using Dotnet.Onion.Template.Application.Store.Service;
using Dotnet.Onion.Template.Application.Store.Service.Interface;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnet.Onion.Template.Application
{
    public static class ConfigurationModule
    {
        public static void RegisterApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ConfigurationModule).Assembly);
            
            services.AddScoped<ICompanyService, CompanyService>();

            services.AddScoped<IStoreService, StoreService>();
        }
    }
}
