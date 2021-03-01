using System.Threading.Tasks;
using Dotnet.Onion.Template.Domain.Login;

namespace Dotnet.Onion.Template.Domain.Integration.Http
{
    public interface ILoginIntegration
    {
        Task<LoginServiceLayer> Login(Login.Login login);
    }
}
