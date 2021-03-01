using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dotnet.Onion.Template.Application.Login.Dto;
using Dotnet.Onion.Template.Application.Login.Service.Facade;
using Dotnet.Onion.Template.Domain.Integration.Http;

namespace Dotnet.Onion.Template.Application.Login.Service
{
    public class LoginFacade : ILoginFacade
    {
        private readonly ILoginIntegration _loginIntegration;

        public LoginFacade(ILoginIntegration loginIntegration)
        {
            _loginIntegration = loginIntegration;
        }

        public Task<LoginOutPutDto> Login(LoginInputDto loginInputDto)
        {
            throw new NotImplementedException();
        }
    }
}
