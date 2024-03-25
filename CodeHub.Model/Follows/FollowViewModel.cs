using CodeHub.Model.Users;

namespace CodeHub.Model.Follow;

public class FollowViewModel
{
    public long Id { get; set; }
    public UserViewModel Follower { get; set; }
    public UserViewModel Following { get; set; }
}