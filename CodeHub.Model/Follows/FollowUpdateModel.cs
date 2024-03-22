using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeHub.Model.Follows;

public class FollowUpdateModel
{
    public long FollowerId { get; set; }
    public long FollowingId { get; set; }
}
