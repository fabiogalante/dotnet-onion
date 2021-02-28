using System.Collections.Generic;
using System.Threading.Tasks;
using Dotnet.Onion.Template.Application.Company.Dto;

namespace Dotnet.Onion.Template.Application.Company.Service.Interface
{
    public interface ICompanyService
    {
        Task<CompanyOutPutDto> Create(CompanyInputDto company);
        Task<IEnumerable<CompanyOutPutDto>> GetAll();
    }
}
