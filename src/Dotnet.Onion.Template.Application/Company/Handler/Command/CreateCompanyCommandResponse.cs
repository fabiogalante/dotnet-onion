using Dotnet.Onion.Template.Application.Company.Dto;

namespace Dotnet.Onion.Template.Application.Company.Handler.Command
{
    public class CreateCompanyCommandResponse
    {
        public CompanyOutPutDto Company { get; set; }

        public CreateCompanyCommandResponse(CompanyOutPutDto company)
        {
            Company = company;
        }
    }
}
