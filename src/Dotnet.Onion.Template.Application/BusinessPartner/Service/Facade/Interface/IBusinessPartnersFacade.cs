using System.Threading.Tasks;
using Dotnet.Onion.Template.Application.BusinessPartner.Dto;

namespace Dotnet.Onion.Template.Application.BusinessPartner.Service.Facade.Interface
{
    public interface IBusinessPartnersFacade
    {
        Task<BusinnesPartnerOutPutDto> BusinessPartners(string cardCode);
    }
}
