using CodeHub.Domain.Commons;
using CodeHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeHub.DataAccess.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Repository> Repositories { get; set; }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e => e.Entity is Auditable && e.State == EntityState.Modified);

        foreach (var entry in entries)
            ((Auditable)entry.Entity).UpdatedAt = DateTime.UtcNow;

        return await base.SaveChangesAsync();
    }
}
