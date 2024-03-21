using CodeHub.Domain.Commons;
using CodeHub.Domain.Enums;

namespace CodeHub.Domain.Entities;

public class Repository : Auditable
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string BranchName { get; set; }
    public string CloneURL { get; set; }
    public long UserID { get; set; }
    public User User { get; set; }
    public RepositoryVisibility Visibility { get; set; }
    public long ReadmeID { get; set; }
    public long GitIgnoreID { get; set; }
    public long LicenceID { get; set; }
    public long ParentID { get; set; }
    public Repository ParentRepository { get; set; }
}
