using CodeHub.Domain.Commons;

namespace CodeHub.Domain.Entities;

public class IssueAssignment : Auditable
{
    public long IssueId { get; set; }
    public Issue Issue { get; set; }
    public long AssignessId { get; set; }
    public User Assigness { get; set; }
}
