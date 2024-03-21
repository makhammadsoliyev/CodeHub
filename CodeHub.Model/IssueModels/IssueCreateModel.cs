namespace CodeHub.Model.IssueModels;

public class IssueCreateModel
{
    public string Title { get; set; }
    public string Description { get; set; }
    public long RepositoryID { get; set; }
    public long UserID { get; set; }
}
