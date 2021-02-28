using Dotnet.Onion.Template.API.ViewModel.Store.Response;
using Dotnet.Onion.Template.Application.Store.Dto;

namespace Dotnet.Onion.Template.API.ViewModel.Store.Profile
{
    public class StoreProfile : AutoMapper.Profile
    {
        public StoreProfile()
        {
            CreateMap<StoreOutPutDto, StoreResponse>();
            CreateMap<Domain.Store.Store, StoreOutPutDto>();
        }
    }
}
