using CodeHub.Domain.Enums;
using CodeHub.Model.IssueAssignments;
using CodeHub.Model.Repositories;
using CodeHub.Model.Users;

namespace CodeHub.Model.Issues;

public class IssueViewModel
{
    public long Id { get; set; }
    public string Title { get; set; }
    public RepositoryViewModel Repository { get; set; }
    public string Description { get; set; }
    public IssueStatus Status { get; set; }
    public UserViewModel User { get; set; }

    public IEnumerable<IssueAssignmentViewModel> IssueAssignees { get; set; }
}