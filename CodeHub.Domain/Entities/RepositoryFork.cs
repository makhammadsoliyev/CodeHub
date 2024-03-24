using CodeHub.Domain.Commons;

namespace CodeHub.Domain.Entities;

public class RepositoryFork : Auditable
{
    public long UserId {get;set;}
    public User User { get;set;}    
    public long RepositoryId { get; set; }
    public Repository Repository { get; set; }
}
