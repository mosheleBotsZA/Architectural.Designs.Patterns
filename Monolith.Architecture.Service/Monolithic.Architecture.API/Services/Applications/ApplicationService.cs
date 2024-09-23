using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Monolithic.Architecture.API.Contracts.Repositories;
using Monolithic.Architecture.API.Contracts.Services;
using Monolithic.Architecture.API.Data.DTO;
using Monolithic.Architecture.API.Data.Models.Applications;

namespace Monolithic.Architecture.API.Services.Applications
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IMapper _mapper;

        public ApplicationService(IApplicationRepository applicationRepository, IMapper mapper)
        {
            _applicationRepository = applicationRepository;
            _mapper = mapper;
        }

        public IQueryable<ApplicationDTO> Applications => _applicationRepository
        .Applications.ProjectTo<ApplicationDTO>(_mapper.ConfigurationProvider);

        public Task<ApplicationDTO> AddorUpdate(ApplicationDTO application)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(ApplicationDTO application)
        {
            var entity = _mapper.Map<Application>(application);
            await _applicationRepository.Delete(entity);
        }

        public async Task<ApplicationDTO> GetApplicationById(string id)
        {
            var application = await Applications.FirstOrDefaultAsync(a => a.Id == id);
            return application;
        }

        public async Task<ApplicationDTO> GetApplicationByName(string name)
        {
            var application = await Applications.FirstOrDefaultAsync(a => a.Name == name);
            return application;
        }

        public async Task<IEnumerable<ApplicationDTO>> GetApplications()
        {
            var applications = await Applications.ToListAsync();
            return applications.AsEnumerable();
        }
    }
}