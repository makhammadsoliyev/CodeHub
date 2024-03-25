using CodeHub.Model.Issues;
using CodeHub.Model.Users;

namespace CodeHub.Model.IssueAssignments;

public class IssueAssignmentViewModel
{
    public long Id { get; set; }
    public IssueViewModel Issue { get; set; }
    public UserViewModel Assigness { get; set; }
}
