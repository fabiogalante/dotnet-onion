using Dotnet.Onion.Template.Domain.Company;
using Dotnet.Onion.Template.Domain.Company.Repository;
using Dotnet.Onion.Template.Repository.Context;

namespace Dotnet.Onion.Template.Repository.Repository
{
    public class CompanyRepository : UnitOfWork<Company>, ICompanyRepository
    {
        public CompanyRepository(ContextApp context) : base(context)
        {
        }
    }
}
