using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Dotnet.Onion.Template.Application.Company.Dto;
using Dotnet.Onion.Template.Application.Company.Service.Interface;
using Dotnet.Onion.Template.Domain.Company.Repository;
using OpenTracing;

namespace Dotnet.Onion.Template.Application.Company.Service
{
        /*
     * Application service is that layer which initializes and oversees interaction 
     * between the domain objects and services. The flow is generally like this: 
     * get domain object (or objects) from repository, execute an action and put it 
     * (them) back there (or not). It can do more - for instance it can check whether 
     * a domain object exists or not and throw exceptions accordingly. So it lets the 
     * user interact with the application (and this is probably where its name originates 
     * from) - by manipulating domain objects and services. Application services should 
     * generally represent all possible use cases.
     */

    
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;
        private readonly ITracer _tracer;
        
        public CompanyService(IMapper mapper, ICompanyRepository companyRepository, ITracer tracer)
        {
            _mapper = mapper;
            _companyRepository = companyRepository;
            _tracer = tracer;
        }

        public async Task<CompanyOutPutDto> Create(CompanyInputDto dto)
        {
            using (var scope = _tracer.BuildSpan("Create_TaskService").StartActive(true))
            {
                var company = _mapper.Map<Domain.Company.Company>(dto);

                await _companyRepository.Save(company);

                return this._mapper.Map<CompanyOutPutDto>(company);
            }
        }

        public async Task<IEnumerable<CompanyOutPutDto>> GetAll()
        {
            var result = await _companyRepository.GetAll();
            return _mapper.Map<List<CompanyOutPutDto>>(result);
        }
    }
}
