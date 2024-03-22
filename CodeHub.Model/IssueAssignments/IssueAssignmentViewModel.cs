using CodeHub.Domain.Entities;

namespace CodeHub.Model.IssueAssignments;

public class IssueAssignmentViewModel
{
    public long Id { get; set; }
    public Issue Issue { get; set; }
    public User Assignees { get; set; }
}
