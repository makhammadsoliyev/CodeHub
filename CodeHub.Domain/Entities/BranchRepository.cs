using CodeHub.Domain.Commons;

namespace CodeHub.Domain.Entities;

public class BranchRepository : Auditable
{
    public string BranchName { get; set; }
    public long UserID { get; set; }
    public User User { get; set; }
    public long? ReadmeID { get; set; }
    public long? GitIgnoreID { get; set; }
    public long? LicenceID { get; set; }
    public long RepositoryID { get; set; }
    public Repository repository { get; set; }
}
