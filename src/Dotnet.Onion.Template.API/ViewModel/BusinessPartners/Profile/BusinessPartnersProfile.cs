using Dotnet.Onion.Template.API.ViewModel.BusinessPartners.Response;
using Dotnet.Onion.Template.Application.BusinessPartner.Dto;
using Dotnet.Onion.Template.Application.BusinessPartner.Query;
using Dotnet.Onion.Template.Domain.BusinessPartners;

namespace Dotnet.Onion.Template.API.ViewModel.BusinessPartners.Profile
{
    public class BusinessPartnersProfile : AutoMapper.Profile
    {
        public BusinessPartnersProfile()
        {
            CreateMap<BusinnesPartnerOutPutDto, BusinessPartnersResponse>();

            CreateMap<BusinnesPartnerOutPutDto, GetBusinnesPartnerCommandResponse>();

            


            CreateMap<BusinessPartner, BusinnesPartnerOutPutDto>();
            CreateMap<BusinessPartner, GetBusinnesPartnerCommandResponse>();
        }
    }
}
