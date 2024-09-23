using Monolithic.Architecture.API.Contracts.Repositories;
using Monolithic.Architecture.API.Data.Models.Applications;

namespace Monolithic.Architecture.API.Data.Repositories;

public class ApplicationRepository : IApplicationRepository
{
    private readonly MonolithDbContext _context;

    public ApplicationRepository(MonolithDbContext context)
    {
        _context = context;
    }

    public IQueryable<Application> Applications => _context
    .Applications;

    public Task Delete(Application entity)
    {
        throw new NotImplementedException();
    }

    public async Task<Application> Upsert(Application entity)
    {
        var entry = _context.Applications.Add(entity);
        await _context.SaveChangesAsync();
        return entry.Entity;
    }
}
