using CodeHub.Domain.Entities;

namespace CodeHub.Model.RepositroyForks;

public class RepositoryForkViewModel
{
    public long Id { get; set; }
    public User User { get; set; }
    public Repository Repository { get; set; }
}
