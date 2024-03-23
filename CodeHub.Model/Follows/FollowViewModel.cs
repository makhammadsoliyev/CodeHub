using CodeHub.Domain.Entities;

namespace CodeHub.Model.Follow;

public class FollowViewModel
{
    public long Id { get; set; }
    public User Follower { get; set; }
    public User Following { get; set; }
}
