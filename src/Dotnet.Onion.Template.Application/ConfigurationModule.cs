using System.Reflection;
using Dotnet.Onion.Template.Application.BusinessPartner.Service;
using Dotnet.Onion.Template.Application.BusinessPartner.Service.Facade;
using Dotnet.Onion.Template.Application.BusinessPartner.Service.Facade.Interface;
using Dotnet.Onion.Template.Application.BusinessPartner.Service.Interface;
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
            services.AddMediatR(typeof(ConfigurationModule).GetTypeInfo().Assembly);

            services.AddScoped<ICompanyService, CompanyService>();

            services.AddScoped<IStoreService, StoreService>();

            services.AddScoped<IBusinessPartnersFacade, BusinessPartnersFacade>();

            services.AddScoped<IBusinessPartnersService, BusinessPartnersService>();
        }
    }
}
