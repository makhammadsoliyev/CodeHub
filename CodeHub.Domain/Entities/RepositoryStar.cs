using CodeHub.Domain.Commons;

namespace CodeHub.Domain.Entities;
public class RepositoryStar : Auditable
{
    public long RepositoryId { get; set; }
    public Repository Repository { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }
}
