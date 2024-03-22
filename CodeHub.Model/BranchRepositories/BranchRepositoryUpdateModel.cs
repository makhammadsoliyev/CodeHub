namespace CodeHub.Model.BranchRepositories;

public class BranchRepositoryUpdateModel
{
    public long Id { get; set; }
    public string BranchName { get; set; }
    public long UserId { get; set; }
    public long RepositoryId { get; set; }
    public long? ReadmeId { get; set; }
    public long? GitIgnoreId { get; set; }
    public long? LicenseId { get; set; }
}
