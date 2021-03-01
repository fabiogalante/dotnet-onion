using System.Threading;
using System.Threading.Tasks;
using Dotnet.Onion.Template.Application.Company.Service.Interface;
using MediatR;

namespace Dotnet.Onion.Template.Application.Company.Handler.Query
{
    public class GetAllQueryHandler : IRequestHandler<GetAllQueryCommand, GetAllQueryCommandResponse>
    {
        private readonly ICompanyService _companyService;

        public GetAllQueryHandler(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public async Task<GetAllQueryCommandResponse> Handle(GetAllQueryCommand request, CancellationToken cancellationToken)
        {
            var result = await _companyService.GetAll();
            return new GetAllQueryCommandResponse(result);
        }
    }
}
