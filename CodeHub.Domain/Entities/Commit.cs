using CodeHub.Domain.Commons;

namespace CodeHub.Domain.Entities;

public class Commit : Auditable
{
    public long UserId { get; set; }
    public User User { get; set; }
    public long? RepositoryId { get; set; }
    public Repository Repository {get;set;} 
    public long? BranchRepositoryId { get; set; }
    public BranchRepository BranchRepository { get; set; }
    public string Message  { get; set; }
}