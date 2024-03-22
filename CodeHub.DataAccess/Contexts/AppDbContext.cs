using CodeHub.Domain.Commons;
using Microsoft.EntityFrameworkCore;

namespace CodeHub.DataAccess.Contexts;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "Host=raja.db.elephantsql.com; Database=xuqrbloy; Username=xuqrbloy; Password=2rrItqHcos3DLvq5LiCGq4slFbqMXKdk";
        optionsBuilder.UseNpgsql(connectionString);
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
