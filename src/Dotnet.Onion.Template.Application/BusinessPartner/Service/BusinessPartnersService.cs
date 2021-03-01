using System.Threading.Tasks;
using AutoMapper;
using Dotnet.Onion.Template.Application.BusinessPartner.Dto;
using Dotnet.Onion.Template.Application.BusinessPartner.Service.Facade;
using Dotnet.Onion.Template.Application.BusinessPartner.Service.Facade.Interface;
using Dotnet.Onion.Template.Application.BusinessPartner.Service.Interface;

namespace Dotnet.Onion.Template.Application.BusinessPartner.Service
{
    public class BusinessPartnersService : IBusinessPartnersService
    {
        private readonly IBusinessPartnersFacade _businessPartnersFacade;
        private readonly IMapper _mapper;

        public BusinessPartnersService(IBusinessPartnersFacade businessPartnersFacade, IMapper mapper)
        {
            _businessPartnersFacade = businessPartnersFacade;
            _mapper = mapper;
        }


        public async Task<BusinnesPartnerOutPutDto> GetBusinessPartners(string cardCode)
        {
            return await _businessPartnersFacade.BusinessPartners(cardCode);
        }
    }
}
