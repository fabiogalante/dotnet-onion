using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dotnet.Onion.Template.API.ViewModel.BusinessPartners.Response;
using Dotnet.Onion.Template.API.ViewModel.Companies.Response;
using Dotnet.Onion.Template.Application.BusinessPartner.Query;
using Dotnet.Onion.Template.Application.Company.Handler.Query;
using Dotnet.Onion.Template.Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Dotnet.Onion.Template.API.Controllers
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class BusinessPartnersController : MainController
    {
        private readonly ILogger<BusinessPartnersController> _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public BusinessPartnersController(INotifier notifier, ILogger<BusinessPartnersController> logger, IMapper mapper, IMediator mediator) : base(notifier)
        {
            _logger = logger;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet("{cardCode}")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CompanyResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> BusinessPartners(string cardCode)
        {
            var result = await _mediator.Send(new GetBusinnesPartnerQueryCommand(cardCode));
            return CustomResponse(result);
        }
    }
}
