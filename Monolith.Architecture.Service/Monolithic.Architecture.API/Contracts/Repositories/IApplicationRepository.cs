using Monolithic.Architecture.API.Contracts.Common;
using Monolithic.Architecture.API.Data.Models.Applications;

namespace Monolithic.Architecture.API.Contracts.Repositories
{
    public interface IApplicationRepository : IRepository<Application>
    {
        IQueryable<Application> Applications { get; }
    }
}