using CodeHub.Model.Repositories;
using CodeHub.Model.Users;

namespace CodeHub.Model.RepositoryStar;

public class RepositoryStarViewModel
{
    public long Id { get; set; }
    public RepositoryViewModel Repository { get; set; }
    public UserViewModel User { get; set; }
}
