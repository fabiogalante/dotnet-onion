using System.Threading.Tasks;
using AutoMapper;
using Dotnet.Onion.Template.API.ViewModel.Store.Response;
using Dotnet.Onion.Template.Application.Store.Service.Interface;
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
    public class StoresController : MainController
    {
        private readonly ILogger<StoresController> _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IStoreService _storeService;

        public StoresController(INotifier notifier, ILogger<StoresController> logger, IMapper mapper, IMediator mediator, IStoreService storeService) : base(notifier)
        {
            _logger = logger;
            _mapper = mapper;
            _mediator = mediator;
            _storeService = storeService;
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StoreResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Store(int id)
        {
            var stores = await _storeService.GetById(id);
            var result = _mapper.Map<StoreResponse>(stores);

            if (result != null) return CustomResponse(result);
            NotifyError("Invalid Id");
            return CustomResponse();

        }



    }
}