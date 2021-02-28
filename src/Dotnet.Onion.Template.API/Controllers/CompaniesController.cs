using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Dotnet.Onion.Template.API.ViewModel.Companies.Request;
using Dotnet.Onion.Template.API.ViewModel.Companies.Response;
using Dotnet.Onion.Template.Application.Company.Dto;
using Dotnet.Onion.Template.Application.Company.Handler.Command;
using Dotnet.Onion.Template.Application.Company.Handler.Query;
using Microsoft.AspNetCore.Mvc;
using Dotnet.Onion.Template.Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Dotnet.Onion.Template.API.Controllers
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CompaniesController : MainController
    {
        private readonly ILogger<CompaniesController> _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CompaniesController(INotifier notifier, ILogger<CompaniesController> logger, IMapper mapper, IMediator mediator) : base(notifier)
        {
            _logger = logger;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CompanyResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> GetCompanies()
        {
            var query = await _mediator.Send(new GetAllQueryCommand());
            var result = _mapper.Map<List<CompanyResponse>>(query.Companies);
            return CustomResponse(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> SaveCompanies(CompanyRequest request)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            CompanyInputDto companyInput = _mapper.Map<CompanyInputDto>(request);
            var query = await _mediator.Send(new CreateCompayCommand(companyInput));
            var result = this._mapper.Map<CompanyResponse>(query.Company);
            return Created($"/{result.Id}", result);
        }
    }
}
