using CodeHub.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeHub.Domain.Entities;

public class GitIgnore:Auditable
{
    public string Name {  get; set; }
    public string Content {  get; set; }

}
