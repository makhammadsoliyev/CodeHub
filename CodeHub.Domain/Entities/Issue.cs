using CodeHub.Domain.Commons;
using CodeHub.Domain.Enums;

namespace CodeHub.Domain.Entities;

public class Issue : Auditable
{
    public string Title { get; set; }
    public string Description { get; set; }
    public IssueStatus Status { get; set; }
    public long RepositoryID { get; set; }
    public Repository Repository { get; set; }
    public long CreatorID { get; set; }
    public User User { get; set; }
}
