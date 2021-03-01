using Dotnet.Onion.Template.Application.BusinessPartner.Dto;

namespace Dotnet.Onion.Template.Application.BusinessPartner.Query
{
    public class GetBusinnesPartnerCommandResponse
    {
        public BusinnesPartnerOutPutDto BusinnesPartner { get; set; }

        public GetBusinnesPartnerCommandResponse(BusinnesPartnerOutPutDto businnesPartner)
        {
            BusinnesPartner = businnesPartner;
        }
    }
}
