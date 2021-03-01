using Dotnet.Onion.Template.Application.Login.Dto;
using System.Threading.Tasks;

namespace Dotnet.Onion.Template.Application.Login.Service.Facade
{
    public interface ILoginFacade
    {
        Task<LoginOutPutDto> Login(LoginInputDto loginInputDto);
    }
}
