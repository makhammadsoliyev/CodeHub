using CodeHub.Domain.Enums;

namespace CodeHub.Model.RepositoryModels;

public class RepositoryUpdateModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string BranchName { get; set; }
    public RepositoryVisibility Visibility { get; set; }
    public long? ReadmeID { get; set; }
    public long? GitIgnoreID { get; set; }
    public long? LicenceID { get; set; }
    public long? ParentID { get; set; }
}
