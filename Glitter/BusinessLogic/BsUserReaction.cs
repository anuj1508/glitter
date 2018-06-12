using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserReactionDto;
using DAL;

namespace BusinessLogic
{
    public class BsUserReaction
    {
        public static bool Like(TweetDto.DtoTweet tweet)
        {
            UserReactionDto.DtoUserReaction like = new UserReactionDto.DtoUserReaction
            {
                UserDetailId = tweet.UserDetailId,
                TweetId = tweet.TweetId,
                IsLiked = 1
            };
            return UserReactionDll.AddToLikes(like);
        }

        public static bool DisLike(TweetDto.DtoTweet tweet)
        {
            UserReactionDto.DtoUserReaction dislike = new UserReactionDto.DtoUserReaction
            {
                UserDetailId = tweet.UserDetailId,
                TweetId = tweet.TweetId,
                IsLiked = -1
            };
            return UserReactionDll.AddToDislikes(dislike);
        }

        public static bool UndoReaction(TweetDto.DtoTweet tweet)
        {
            UserReactionDto.DtoUserReaction undo = new UserReactionDto.DtoUserReaction
            {
                UserDetailId = tweet.UserDetailId,
                TweetId = tweet.TweetId,

            };
            return UserReactionDll.ReamoveReaction(undo);
        }

        public static int NoOfLikes(int tweetid)
        {
            return UserReactionDll.NoOfLikes(tweetid);
        }

        public static int NoOfDisLikes(int tweetid)
        {
            return UserReactionDll.NoOfDisLikes(tweetid);
        }


    }


}

