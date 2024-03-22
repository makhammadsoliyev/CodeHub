using CodeHub.Domain.Entities;

namespace CodeHub.Model.BranchRepositories;

public class BranchRepositoryViewModel
{
    public long Id { get; set; }
    public string BranchName { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }
    public long RepositoryId { get; set; }
    public Repository Repository { get; set; }
    public ReadmeModel Readme { get; set; }
    public GitIgnore GitIgnore { get; set; }
    public License License { get; set; }
}
