using System.Collections.Generic;
using Dotnet.Onion.Template.Application.Company.Dto;

namespace Dotnet.Onion.Template.Application.Company.Handler.Query
{
    public class GetAllQueryCommandResponse 
    {
        public IEnumerable<CompanyOutPutDto> Companies { get; set; }
        
        public GetAllQueryCommandResponse(IEnumerable<CompanyOutPutDto> companies)
        {
            Companies = companies;
        }

        
        
    }
}
