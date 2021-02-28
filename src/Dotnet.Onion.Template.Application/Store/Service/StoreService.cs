using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Dotnet.Onion.Template.Application.Store.Dto;
using Dotnet.Onion.Template.Application.Store.Service.Interface;
using Dotnet.Onion.Template.Domain.Store.Repository;
using OpenTracing;

namespace Dotnet.Onion.Template.Application.Store.Service
{
    public class StoreService : IStoreService
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IMapper _mapper;
        private readonly ITracer _tracer;

        public StoreService(IStoreRepository storeRepository, IMapper mapper, ITracer tracer)
        {
            _storeRepository = storeRepository;
            _mapper = mapper;
            _tracer = tracer;
        }

        public async Task<StoreOutPutDto> GetById(int id)
        {
            var store = await _storeRepository.FindById(id);
            var storeOutPut = _mapper.Map<StoreOutPutDto>(store);
            return storeOutPut;
        }

        public async Task<IEnumerable<StoreOutPutDto>> FindAll()
        {
            var stores = await _storeRepository.FindAll();
            var storesOutPut = _mapper.Map<IEnumerable<StoreOutPutDto>>(stores);
            return storesOutPut;
        }
    }
}
