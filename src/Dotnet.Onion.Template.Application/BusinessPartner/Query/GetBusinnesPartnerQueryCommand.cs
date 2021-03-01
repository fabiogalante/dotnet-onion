using Dotnet.Onion.Template.Application.Company.Handler.Query;
using MediatR;

namespace Dotnet.Onion.Template.Application.BusinessPartner.Query
{
    public class GetBusinnesPartnerQueryCommand : IRequest<GetBusinnesPartnerCommandResponse>
    {
        public string CardCode { get; set; }

        public GetBusinnesPartnerQueryCommand(string cardCode)
        {
            CardCode = cardCode;
        }
    }
}
