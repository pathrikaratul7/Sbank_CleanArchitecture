using Microsoft.EntityFrameworkCore;
using SbankAPI.Domain.Entities;

namespace SbankAPI.Infrastructure.Data;

public class APpDbContext : DbContext
{
    public APpDbContext(DbContextOptions<APpDbContext> options)
        : base(options)
    {
    }

    public DbSet<Tbl_User> Tbl_Users => Set<Tbl_User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(APpDbContext).Assembly);
    }
}