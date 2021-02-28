using Dotnet.Onion.Template.API.ViewModel.Companies.Request;
using Dotnet.Onion.Template.API.ViewModel.Companies.Response;
using Dotnet.Onion.Template.Application.Company.Dto;
using Dotnet.Onion.Template.Domain.Company;

namespace Dotnet.Onion.Template.API.ViewModel.Companies.Profile
{
    public class CompanyProfile : AutoMapper.Profile
    {
        public CompanyProfile()
        {
            CreateMap<CompanyRequest, CompanyInputDto>();
            CreateMap<CompanyOutPutDto, CompanyResponse>();

            CreateMap<CompanyInputDto, Company>();
            CreateMap<Company, CompanyOutPutDto>();
        }
    }
}
