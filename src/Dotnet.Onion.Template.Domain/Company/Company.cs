using System;
using Dotnet.Onion.Templante.Crosscutting.Entity;

namespace Dotnet.Onion.Template.Domain.Company
{
    public class Company : Entity<int>, IDomain<Company>
    {
        public string CompanyName { get; set; }
        public string CompanyDb { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
