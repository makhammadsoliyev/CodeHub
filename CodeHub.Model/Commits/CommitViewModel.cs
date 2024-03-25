using CodeHub.Model.BranchRepositories;
using CodeHub.Model.Repositories;
using CodeHub.Model.Users;

namespace CodeHub.Model.Commits;

public class CommitViewModel
{
    public long Id { get; set; }
    public UserViewModel User { get; set; }
    public RepositoryViewModel Repository { get; set; }
    public BranchRepositoryViewModel BranchRepository { get; set; }
    public string Message { get; set; }
}