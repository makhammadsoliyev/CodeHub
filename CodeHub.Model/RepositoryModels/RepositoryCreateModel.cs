using CodeHub.Domain.Enums;

namespace CodeHub.Model.RepositoryModels;

public class RepositoryCreateModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string BranchName { get; set; }
    public long UserID { get; set; }
    public RepositoryVisibility Visibility { get; set; }
    public long? ReadmeID { get; set; }
    public long? GitIgnoreID { get; set; }
    public long? LicenceID { get; set; }
    public long? ParentID { get; set; }
}
