using System.Collections.Generic;
using System.Threading.Tasks;
using Dotnet.Onion.Template.Application.Store.Dto;

namespace Dotnet.Onion.Template.Application.Store.Service.Interface
{
    public interface IStoreService
    {
        Task<StoreOutPutDto> GetById(int id);
        Task<IEnumerable<StoreOutPutDto>> FindAll();
    }
}
