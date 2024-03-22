﻿using CodeHub.Domain.Commons;

namespace CodeHub.Domain.Entities;

public class User : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string AvatarUrl { get; set; }
    IEnumerable<Repository> Repositories { get; set; }
}
