using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginFollowerBindDto
{
    public class DtoLoginFollowerBind
    {
        public int UserDetailId { get; set; }
        public int FollowerId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
