using CodeHub.Domain.Entities;

namespace CodeHub.Model.IssueAssignments;

public class IssueAssignmentViewModel
{
    public long Id { get; set; }
    public User Assigness { get; set; }
}