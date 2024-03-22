using CodeHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeHub.Model.Follow;

public class FollowViewModel
{
    public long Id { get; set; }
    public long FollowerId { get; set; }
    public User Follower { get; set; }
    public long FollowingId { get; set; }
    public User Following { get; set; }

}
