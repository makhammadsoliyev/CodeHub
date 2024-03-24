using CodeHub.Domain.Commons;
using CodeHub.Domain.Enums;

namespace CodeHub.Domain.Entities;

public class Repository : Auditable
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string BranchName { get; set; }
    public string CloneUrl { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }
    public RepositoryVisibility Visibility { get; set; }
    public long? ReadmeId { get; set; }
    public Readme Readme { get; set; }
    public long? GitIgnoreId { get; set; }
    public GitIgnore GitIgnore { get; set; }
    public long? LicenseId { get; set; }
    public License License { get; set; }
    public long? ParentRepositoryId { get; set; }
    public Repository ParentRepository { get; set; }
    public IEnumerable<BranchRepository> BranchRepositories { get; set; }
    public IEnumerable<Issue> Issues { get; set; }
}
