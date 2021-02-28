using System;
using System.ComponentModel.DataAnnotations;

namespace Dotnet.Onion.Template.API.ViewModel.Companies.Request
{
    public class CompanyRequest
    {
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string CompanyDb { get; set; }
        [Required]
        public bool Active { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        
        
        
      
    }
}
