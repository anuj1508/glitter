using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserReactionDto
{
    public class DtoUserReaction
    {
        public int UserReactionId { get; set; }
        public int UserDetailId { get; set; }
        public int TweetId { get; set; }
        public int IsLiked { get; set; }
    }
}
