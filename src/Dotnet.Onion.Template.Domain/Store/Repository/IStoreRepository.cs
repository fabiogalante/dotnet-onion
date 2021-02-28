using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dotnet.Onion.Template.Domain.Store.Repository
{
    public interface IStoreRepository
    {
        Task<IEnumerable<Store>> FindAll();
        Task<Store> FindById(int id);
    }
}
