using CodeHub.Domain.Entities;

namespace CodeHub.Model.RepositoryStar;

public class RepositoryStarViewModel
{
    public long Id { get; set; }
    public Repository Repository { get; set; }
    public User User { get; set; }
}
