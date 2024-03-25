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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Repository
        modelBuilder.Entity<Repository>()
            .HasOne(repository => repository.User)
            .WithMany(user => user.Repositories)
            .HasForeignKey(repository => repository.UserId);

        modelBuilder.Entity<Repository>()
            .HasOne(repository => repository.ParentRepository)
            .WithMany()
            .HasForeignKey(repository => repository.ParentRepositoryId);

        modelBuilder.Entity<Repository>()
             .HasOne(repository => repository.Readme)
             .WithMany()
             .HasForeignKey(repository => repository.ReadmeId);

        modelBuilder.Entity<Repository>()
            .HasOne(repository => repository.License)
            .WithMany()
            .HasForeignKey(repository => repository.LicenseId);

        modelBuilder.Entity<Repository>()
            .HasOne(repository => repository.GitIgnore)
            .WithMany()
            .HasForeignKey(repository => repository.GitIgnoreId);


        // BranchRepository
        modelBuilder.Entity<BranchRepository>()
            .HasOne(branchRepository => branchRepository.Repository)
            .WithMany(repository => repository.BranchRepositories)
            .HasForeignKey(branchRepository => branchRepository.RepositoryId);

        modelBuilder.Entity<BranchRepository>()
            .HasOne(branchRepository => branchRepository.User)
            .WithMany()
            .HasForeignKey(branchRepository => branchRepository.UserId);

        modelBuilder.Entity<BranchRepository>()
            .HasOne(branchRepository => branchRepository.Readme)
            .WithMany()
            .HasForeignKey(branchRepository => branchRepository.ReadmeId);

        modelBuilder.Entity<BranchRepository>()
            .HasOne(branchRepository => branchRepository.License)
            .WithMany()
            .HasForeignKey(branchRepository => branchRepository.LicenseId);

        modelBuilder.Entity<BranchRepository>()
            .HasOne(branchRepository => branchRepository.GitIgnore)
            .WithMany()
            .HasForeignKey(branchRepository => branchRepository.GitIgnoreId);

        // Commit
        modelBuilder.Entity<Commit>()
            .HasOne(commit => commit.User)
            .WithMany()
            .HasForeignKey(commit => commit.UserId);

        modelBuilder.Entity<Commit>()
           .HasOne(commit => commit.Repository)
           .WithMany(repository => repository.Commits)
           .HasForeignKey(commit => commit.RepositoryId);

        modelBuilder.Entity<Commit>()
           .HasOne(commit => commit.BranchRepository)
           .WithMany()
           .HasForeignKey(commit => commit.BranchRepositoryId);


        // Issue
        modelBuilder.Entity<Issue>()
            .HasOne(issue => issue.Creator)
            .WithMany()
            .HasForeignKey(issue => issue.CreatorId);

        modelBuilder.Entity<Issue>()
           .HasOne(issue => issue.Repository)
           .WithMany(repository => repository.Issues)
           .HasForeignKey(issue => issue.RepositoryId);


        // IssueAssignment
        modelBuilder.Entity<IssueAssignment>()
            .HasOne(issueAssignment => issueAssignment.Issue)
            .WithMany(issue => issue.IssueAssignees)
            .HasForeignKey(issueAssignment => issueAssignment.IssueId);

        modelBuilder.Entity<IssueAssignment>()
           .HasOne(issueAssignment => issueAssignment.Assignees)
           .WithMany()
           .HasForeignKey(issueAssignment => issueAssignment.AssigneesId);


        // Repository Fork
        modelBuilder.Entity<RepositoryFork>()
            .HasOne(repositoryFork => repositoryFork.User)
            .WithMany(user => user.Forks)
            .HasForeignKey(repositoryFork => repositoryFork.UserId);

        modelBuilder.Entity<RepositoryFork>()
            .HasOne(repositoryFork => repositoryFork.Repository)
            .WithMany()
            .HasForeignKey(repositoryFork => repositoryFork.RepositoryId);


        // Repository Star
        modelBuilder.Entity<RepositoryStar>()
            .HasOne(repositoryStar => repositoryStar.User)
            .WithMany()
            .HasForeignKey(repositoryStar => repositoryStar.UserId);

        modelBuilder.Entity<RepositoryStar>()
            .HasOne(repositoryStar => repositoryStar.Repository)
            .WithMany(repository => repository.Stars)
            .HasForeignKey(repositoryStar => repositoryStar.RepositoryId);


        // Follow
        modelBuilder.Entity<Follow>()
            .HasOne(follow => follow.Following)
            .WithMany(user => user.Followings)
            .HasForeignKey(follow => follow.FollowingId);

        modelBuilder.Entity<Follow>()
           .HasOne(follow => follow.Follower)
           .WithMany(user => user.Followers)
           .HasForeignKey(follow => follow.FollowerId);


        // Folder
        modelBuilder.Entity<Folder>()
            .HasOne(folder => folder.Repository)
            .WithMany(repository => repository.Folders)
            .HasForeignKey(folder => folder.RepositoryId);

        modelBuilder.Entity<Folder>()
           .HasOne(folder => folder.Parent)
           .WithMany()
           .HasForeignKey(folder => folder.ParentId);


        // File
        modelBuilder.Entity<File>()
            .HasOne(file => file.Repository)
            .WithMany()
            .HasForeignKey(file => file.RepositoryId);

        modelBuilder.Entity<File>()
           .HasOne(file => file.Folder)
           .WithMany(folder => folder.Files)
           .HasForeignKey(file => file.FolderId);


        ////Seed data GitIgnore
        //modelBuilder.Entity<GitIgnore>().HasData(
        //    new GitIgnore() { Id = 1, Name = "gitignore", Content = "Content", CreatedAt = DateTime.UtcNow }
        //    );


        ////Seed data Readme
        //modelBuilder.Entity<Readme>().HasData(
        //    new Readme() { Id = 1, Name = "Readme", Content = "Content", CreatedAt = DateTime.UtcNow }
        //    );


        ////Seed data License
        //modelBuilder.Entity<License>().HasData(
        //    new License() { Id = 1, Name = "MIT", Content = "Content", CreatedAt = DateTime.UtcNow}
        //    );


        ////Seed data User
        //modelBuilder.Entity<User>().HasData(
        //    new User() { Id = 2, FirstName = "Umidjon", LastName = "Makhammadsoliyev", Email =  "umidjon@gmail.com", Password = "1234", AvatarUrl = "url", CreatedAt = DateTime.UtcNow }
        //    );

        ////Seed data BranchRepository
        //modelBuilder.Entity<BranchRepository>().HasData(
        //    new BranchRepository { Id = 1, BranchName = "BranchName", GitIgnoreId = 1, RepositoryId = 1, LicenseId = 1, ReadmeId = 1, CreatedAt =DateTime.UtcNow }
        //    );


        ////Seed data Commit
        //modelBuilder.Entity<Commit>().HasData(
        //    new Commit { Id = 1, RepositoryId = 1, UserId = 1, Message = "Message", CreatedAt = DateTime.UtcNow, BranchRepositoryId = null }
        //    );


        ////Seed data Issue
        //modelBuilder.Entity<Issue>().HasData(
        //    new Issue { Id = 1, Title = "Issue", CreatorId = 1, Status = Domain.Enums.IssueStatus.Open, RepositoryId = 1, CreatedAt = DateTime.UtcNow}
        //    );


        ////Seed data RepositoryFork
        //modelBuilder.Entity<RepositoryFork>().HasData(
        //    new RepositoryFork { Id = 1, UserId = 1, RepositoryId = 1, CreatedAt = DateTime.UtcNow }
        //    );


        ////Seed data RepositoryStar
        //modelBuilder.Entity<RepositoryStar>().HasData(
        //    new RepositoryStar { Id = 1, RepositoryId = 1, UserId = 1, CreatedAt = DateTime.UtcNow }
        //    );

        ////Seed data Repository
        //modelBuilder.Entity<Repository>().HasData(
        //    new Repository() { Id = 1, Name = "CodeHub", UserId = 1, CloneUrl = "https://github.com/makhammadsoliyev/CodeHub.git" ,Visibility = Domain.Enums.RepositoryVisibility.Public 
        //    ,BranchName = "main" ,GitIgnoreId = 1 ,LicenseId = 1 ,ReadmeId = 1 ,ParentRepositoryId = null ,CreatedAt = DateTime.UtcNow }
        //    );

        ////Seed data Folder
        //modelBuilder.Entity<Folder>().HasData(
        //    new Folder { Id = 1, Name = "Folder", ParentId = null, RepositoryId = 1, CreatedAt = DateTime.UtcNow }
        //    );


        ////Seed data File
        //modelBuilder.Entity<File>().HasData(
        //    new File { Id = 1, Name = "File", Extension = "cs", FolderId = 1, RepositoryId = 1, Content = "Code", CreatedAt = DateTime.UtcNow }
        //    );

        ////Seed data IssueAssignment
        //modelBuilder.Entity<IssueAssignment>().HasData(
        //    new IssueAssignment { Id = 1, AssigneesId = 1, IssueId = 1, CreatedAt = DateTime.UtcNow }
        //    );


        ////Seed data Follow
        //modelBuilder.Entity<Follow>().HasData(
        //    new Follow { Id = 1, FollowerId = 1, FollowingId = 2, CreatedAt = DateTime.UtcNow }
        //    );
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
