using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dotnet.Onion.Template.Application.BusinessPartner.Service.Interface;
using MediatR;

namespace Dotnet.Onion.Template.Application.BusinessPartner.Query
{
    public class GetBusinnesPartnerQueryHandler : IRequestHandler<GetBusinnesPartnerQueryCommand, GetBusinnesPartnerCommandResponse>
    {
        private readonly IBusinessPartnersService _businessPartnersService;
        private readonly IMapper _mapper;

        public GetBusinnesPartnerQueryHandler(IBusinessPartnersService businessPartnersService, IMapper mapper)
        {
            _businessPartnersService = businessPartnersService;
            _mapper = mapper;
        }

        public async Task<GetBusinnesPartnerCommandResponse> Handle(GetBusinnesPartnerQueryCommand request, CancellationToken cancellationToken)
        {
            var businessPartners = await _businessPartnersService.GetBusinessPartners(request.CardCode);
            return _mapper.Map<GetBusinnesPartnerCommandResponse>(businessPartners);
        }
    }
}
