using CodeHub.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeHub.Domain.Entities;
public class RepositoryStar:Auditable
{
    public long RepositoryId {  get; set; }
    public Repository Repository { get; set; }
    public long UserId {  get; set; }
    public User User { get; set; }
}
