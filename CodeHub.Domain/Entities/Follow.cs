using CodeHub.Domain.Commons;

namespace CodeHub.Domain.Entities;
public class Follow : Auditable
{
    public long FollowerId {  get; set; }
    public User Follower { get; set; }
    public long FollowingId {  get; set; }
    public User Following { get; set; }
}
