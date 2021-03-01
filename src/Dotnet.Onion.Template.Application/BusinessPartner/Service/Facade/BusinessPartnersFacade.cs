using System;
using System.Threading.Tasks;
using AutoMapper;
using Dotnet.Onion.Template.Application.BusinessPartner.Dto;
using Dotnet.Onion.Template.Application.BusinessPartner.Service.Facade.Interface;
using Dotnet.Onion.Template.Domain.Integration.Http;

namespace Dotnet.Onion.Template.Application.BusinessPartner.Service.Facade
{
    public class BusinessPartnersFacade : IBusinessPartnersFacade
    {
        private readonly IBusinessPartnersIntegration _businessPartnersIntegration;
        private readonly IMapper _mapper;

        public BusinessPartnersFacade(IBusinessPartnersIntegration businessPartnersIntegration, IMapper mapper)
        {
            _businessPartnersIntegration = businessPartnersIntegration;
            _mapper = mapper;
        }

        public async Task<BusinnesPartnerOutPutDto> BusinessPartners(string cardCode)
        {
           var businessPartner = await  _businessPartnersIntegration.BusinessPartner(cardCode);
           return _mapper.Map<BusinnesPartnerOutPutDto>(businessPartner);
        }
    }
}
