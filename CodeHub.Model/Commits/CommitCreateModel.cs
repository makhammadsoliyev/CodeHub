namespace CodeHub.Model.Commits;

public class CommitCreateModel
{
    public long UserId { get; set; }
    public long? RepositoryId { get; set; }
    public long? BranchRepositoryId { get; set; }
    public string Message { get; set; }
}
