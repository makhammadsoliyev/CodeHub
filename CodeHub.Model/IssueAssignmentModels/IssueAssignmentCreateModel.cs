using CodeHub.Domain.Entities;

namespace CodeHub.Model.IssueAssignmentModels;

public class IssueAssignmentCreateModel
{
    public long IssueID { get; set; }
    public long AssignessID { get; set; }
}
public class IssueAssignmentUpdateModel
{
    public long AssignessID { get; set; }
}
public class IssueAssignmentViewModel
{
    public long ID { get; set; }
    public long IssueID { get; set; }
    public User AssignedUser { get; set; }
}