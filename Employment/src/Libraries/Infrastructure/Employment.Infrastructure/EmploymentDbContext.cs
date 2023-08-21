using Microsoft.EntityFrameworkCore;

namespace Employment.Infrastructure;
public class EmploymentDbContext : DbContext
{

    public EmploymentDbContext(DbContextOptions<EmploymentDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EmploymentDbContext).Assembly);
    }
}
