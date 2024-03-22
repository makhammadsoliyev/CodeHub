namespace CodeHub.Model.Issues;

public class IssueCreateModel
{
    public string Title { get; set; }
    public string Description { get; set; }
    public long RepositoryId { get; set; }
    public long UserId { get; set; }
}
