using CodeHub.Domain.Entities;
using CodeHub.Domain.Enums;

namespace CodeHub.Model.Repositories;

public class RepositoryViewModel
{
    public long ID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string BranchName { get; set; }
    public long UserID { get; set; }
    public RepositoryVisibility Visibility { get; set; }
    public Readme Readme { get; set; }
    public GitIgnore GitIgnore { get; set; }
    public License License { get; set; }
    public Repository Parent { get; set; }
}