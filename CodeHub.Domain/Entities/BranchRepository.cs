using CodeHub.Domain.Commons;

namespace CodeHub.Domain.Entities;

public class BranchRepository : Auditable
{
    public string BranchName { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }
    public long? ReadmeId { get; set; }
    public Readme Readme { get; set; }
    public long? GitIgnoreId { get; set; }
    public GitIgnore GitIgnore { get; set; }
    public long? LicenseId { get; set; }
    public License License { get; set; }
    public long RepositoryId { get; set; }
    public Repository Repository { get; set; }
}
