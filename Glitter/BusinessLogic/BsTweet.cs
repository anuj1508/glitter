using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BusinessLogic
{
    public class BsTweet
    {
        public static TweetDto.DtoTweet AddTweet(int userid, string content)
        {
            {
                TweetDto.DtoTweet tweets = new TweetDto.DtoTweet()
                {
                    TweetContent = content,
                    UserDetailId = userid,
                    Date = DateTime.Now
                };

                TweetDto.DtoTweet addTweet = TweetDll.AddTweet(tweets);

                if (addTweet != null)
                {
                    return addTweet;
                }
                else
                {
                    return null;
                }
            }
        }

        public static IList<TweetDto.DtoTweet> GetTweets(int id)
        {
            IList<TweetDto.DtoTweet> getTweets = TweetDll.GetTweets(id);
            if (getTweets != null)
            {
                return getTweets;
            }
            else
            {
                return null;
            }
        }

        public static bool DeleteTweet(TweetDto.DtoTweet tweet)
        {
            if (BsHashTag.RemoveHashTag(tweet))
            {
                if (BsUserReaction.UndoReaction(tweet))
                {
                    return TweetDll.DeleteTweet(tweet);
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static TweetDto.DtoTweet EditTweet(TweetDto.DtoTweet beforeedit, TweetDto.DtoTweet afteredit)
        {
            if (BsHashTag.RemoveHashTag(beforeedit))
            {
                if (BsHashTag.AddHashTag(afteredit))
                {
                    return TweetDll.EditTweet(afteredit);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
