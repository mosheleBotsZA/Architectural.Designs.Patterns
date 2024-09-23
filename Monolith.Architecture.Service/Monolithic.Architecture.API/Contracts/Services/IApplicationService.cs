using Monolithic.Architecture.API.Data.DTO;

namespace Monolithic.Architecture.API.Contracts.Services
{
    public interface IApplicationService
    {
        IQueryable<ApplicationDTO> Applications { get; }
        Task<IEnumerable<ApplicationDTO>> GetApplications();
        Task<ApplicationDTO> GetApplicationById(string id);
        Task<ApplicationDTO> GetApplicationByName(string name);
        Task<ApplicationDTO> AddorUpdate(ApplicationDTO application);
        Task Delete(ApplicationDTO application);
    }
}