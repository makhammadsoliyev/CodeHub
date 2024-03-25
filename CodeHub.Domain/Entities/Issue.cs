using CodeHub.Domain.Commons;
using CodeHub.Domain.Enums;

namespace CodeHub.Domain.Entities;

public class Issue : Auditable
{
    public string Title { get; set; }
    public string Description { get; set; }
    public IssueStatus Status { get; set; }
    public long RepositoryId { get; set; }
    public Repository Repository { get; set; }
    public long CreatorId { get; set; }
    public User Creator { get; set; }

    public IEnumerable<IssueAssignment> Assignees { get; set; }
}
