using CodeHub.Domain.Commons;

namespace CodeHub.Domain.Entities;

public class IssueAssignment : Auditable
{
    public long IssueID { get; set; }
    public Issue Issue { get; set; }
    public long AssignessID { get; set; }
    public User AssignedUser { get; set; }
}
