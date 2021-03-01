using System.Threading.Tasks;
using Dotnet.Onion.Template.Application.BusinessPartner.Dto;

namespace Dotnet.Onion.Template.Application.BusinessPartner.Service.Interface
{
    public interface IBusinessPartnersService
    {
        Task<BusinnesPartnerOutPutDto> GetBusinessPartners(string cardCode);
    }
}
