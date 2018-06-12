using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TweetDto
{
    public class DtoTweet
    {
        public int TweetId { get; set; }
        public int UserDetailId { get; set; }
        public string TweetContent { get; set; }
        public DateTime Date { get; set; }
    }
}
