using CodeHub.Model.Follow;
using CodeHub.Model.Repositories;
using CodeHub.Model.RepositroyForks;

namespace CodeHub.Model.Users;

public class UserViewModel
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string AvatarUrl { get; set; }

    public IEnumerable<RepositoryViewModel> Repositories { get; set; }
    public IEnumerable<RepositoryForkViewModel> Forks { get; set; }
    public IEnumerable<FollowViewModel> Followers { get; set; }
    public IEnumerable<FollowViewModel> Followings { get; set; }
}