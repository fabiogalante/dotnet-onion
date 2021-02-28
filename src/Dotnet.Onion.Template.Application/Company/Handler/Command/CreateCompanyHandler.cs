using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dotnet.Onion.Template.Application.Company.Service;
using Dotnet.Onion.Template.Application.Company.Service.Interface;
using MediatR;

namespace Dotnet.Onion.Template.Application.Company.Handler.Command
{
    public class CreateCompanyHandler : IRequestHandler<CreateCompayCommand, CreateCompanyCommandResponse>
    {
        private ICompanyService CompanyService { get; set; }
        
        public CreateCompanyHandler(ICompanyService companyService)
        {
            CompanyService = companyService;
        }

       
        
        public async Task<CreateCompanyCommandResponse> Handle(CreateCompayCommand request, CancellationToken cancellationToken)
        {
            var result = await CompanyService.Create(request.CompanyInput);

            return new CreateCompanyCommandResponse(result);
        }
    }
}
