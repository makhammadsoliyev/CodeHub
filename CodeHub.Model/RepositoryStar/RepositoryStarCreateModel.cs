using CodeHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeHub.Model.RepositoryStar;

public class RepositoryStarCreateModel
{
    public long RepositoryId { get; set; }
    public Repository Repository { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }
}
