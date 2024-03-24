using CodeHub.Domain.Commons;
using CodeHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using File = CodeHub.Domain.Entities.File;

namespace CodeHub.DataAccess.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
        //Database.MigrateAsync();
        //Database.EnsureCreatedAsync();
    }

    public DbSet<User> Users { get; set; }
    public DbSet<File> Files { get; set; }
    public DbSet<Issue> Issues { get; set; }
    public DbSet<Commit> Commits { get; set; }
    public DbSet<Readme> Readmes { get; set; }
    public DbSet<Follow> Follows { get; set; }
    public DbSet<Folder> Folders { get; set; }
    public DbSet<License> Licenses { get; set; }
    public DbSet<GitIgnore> GitIgnores { get; set; }
    public DbSet<Repository> Repositories { get; set; }
    public DbSet<RepositoryStar> RepositoryStars { get; set; }
    public DbSet<RepositoryFork> RepositoryForks { get; set; }
    public DbSet<IssueAssignment> IssueAssignments { get; set; }
    public DbSet<BranchRepository> BranchRepositories { get; set; }

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
