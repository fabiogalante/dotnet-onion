using System;

namespace Dotnet.Onion.Template.Domain.Company.Events
{
    public interface ICompanyCreatedEvent
    {
        string CompanyName { get; set; }
        string CompanyDb { get; set; }
        bool Active { get; set; }
        DateTime CreatedAt { get; set; }
    }
}
