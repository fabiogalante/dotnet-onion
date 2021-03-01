using System.Threading.Tasks;

namespace Dotnet.Onion.Template.Domain.Integration.Http
{
    public interface IBusinessPartnersIntegration
    {
        Task<BusinessPartners.BusinessPartner> BusinessPartner(string cardCode);
    }
}
