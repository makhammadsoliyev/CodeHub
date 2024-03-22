using CodeHub.Domain.Entities;
using CodeHub.Model.Users;

namespace CodeHub.Model.Commits;

public class CommitViewModel
{
    public UserViewModel User { get; set; }
    public Repository Repository { get; set; }
    public BranchRepository BranchRepository { get; set; }
    public string Message { get; set; }
}
