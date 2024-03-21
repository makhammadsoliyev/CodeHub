using CodeHub.Domain.Commons;

namespace CodeHub.Domain.Entities;

public class BranchRepository : Auditable
{
    public string BranchName { get; set; }
    public long UserID { get; set; }
    public User User { get; set; }
    public long? ReadmeId { get; set; }
    public long? GitIgnoreId { get; set; }
    public long? LicenceId { get; set; }
    public long RepositoryId { get; set; }
    public Repository Repository { get; set; }
}
