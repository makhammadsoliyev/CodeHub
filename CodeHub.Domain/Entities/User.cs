using CodeHub.Domain.Commons;

namespace CodeHub.Domain.Entities;

public class User : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string AvatarUrl { get; set; }

    public IEnumerable<Repository> Repositories { get; set; }
    public IEnumerable<RepositoryFork> Forks { get; set; }
    public IEnumerable<Follow> Follows { get; set; }
    public IEnumerable<Follow> Followers { get; set; }
    public IEnumerable<Follow> Followings { get; set; }
}