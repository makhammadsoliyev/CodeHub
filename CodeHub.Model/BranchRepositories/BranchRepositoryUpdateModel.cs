namespace CodeHub.Model.BranchRepositories;

public class BranchRepositoryUpdateModel
{
    public string BranchName { get; set; }
    public long? ReadmeId { get; set; }
    public long? GitIgnoreId { get; set; }
    public long? LicenceId { get; set; }
}
