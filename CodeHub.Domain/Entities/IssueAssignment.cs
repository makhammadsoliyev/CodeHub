using CodeHub.Domain.Commons;

namespace CodeHub.Domain.Entities;

public class IssueAssignment : Auditable
{
    public long IssueId { get; set; }
    public Issue Issue { get; set; }
    public long AssigneesId { get; set; }
    public User Assignees { get; set; }
}
