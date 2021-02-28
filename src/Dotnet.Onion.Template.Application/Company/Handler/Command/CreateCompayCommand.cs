using Dotnet.Onion.Template.Application.Company.Dto;
using MediatR;

namespace Dotnet.Onion.Template.Application.Company.Handler.Command
{
    public class CreateCompayCommand : IRequest<CreateCompanyCommandResponse>
    {
        public CompanyInputDto CompanyInput { get; }

        public CreateCompayCommand(CompanyInputDto companyInput)
        {
            CompanyInput = companyInput;
        }
    }
}
