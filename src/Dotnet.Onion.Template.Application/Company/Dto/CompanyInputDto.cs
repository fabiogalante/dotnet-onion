using System;

namespace Dotnet.Onion.Template.Application.Company.Dto
{
    public class CompanyInputDto
    {
        public string CompanyName { get; set; }
        public string CompanyDb { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
