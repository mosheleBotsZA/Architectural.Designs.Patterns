using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Monolithic.Architecture.API.Data.Models.Applications;
using Monolithic.Architecture.API.Data.Models.Users;

namespace Monolithic.Architecture.API.Data;

public class MonolithDbContext : IdentityDbContext<User, Role, string>
{
    public DbSet<Application> Applications { get; set; }
    public MonolithDbContext(DbContextOptions<MonolithDbContext> options) : base(options) { }
}
