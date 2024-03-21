namespace CodeHub.Model.BranchRepositoryModels;

public class BranchRepositoryUpdateModel
{
    public string BranchName { get; set; }
    public long? ReadmeID { get; set; }
    public long? GitIgnoreID { get; set; }
    public long? LicenceID { get; set; }
}
