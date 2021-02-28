using System;

namespace Dotnet.Onion.Template.API.ViewModel.Companies.Response
{
    public class CompanyResponse
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyDb { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
