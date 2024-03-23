namespace CodeHub.Model.Commits;

public class CommitUpdateModel
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public long? RepositoryId { get; set; }
    public long? BranchRepositoryId { get; set; }
    public string Message { get; set; }
}
