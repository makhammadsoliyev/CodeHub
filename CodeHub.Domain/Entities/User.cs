using CodeHub.Domain.Commons;

namespace CodeHub.Domain.Entities;

public class User : Auditable
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string AvatarURL { get; set; }
}
