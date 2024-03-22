using CodeHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeHub.Model.RepositoryStars;

public class RepositoryStarViewModel
{
    public long Id { get; set; }
    public long RepositoryId { get; set; }
    public Repository Repository { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }
}
