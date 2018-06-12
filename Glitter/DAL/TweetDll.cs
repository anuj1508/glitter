using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TweetDto;

namespace DAL
{
    public class TweetDll
    {
        public static TweetDto.DtoTweet AddTweet(TweetDto.DtoTweet tweetObject)
        {
            TweetDto.DtoTweet newTweet = null;
            try
            {
                using (GlitterDBEntities1 context = new GlitterDBEntities1())
                {
                    Tweet tweet = new Tweet
                    {
                        TweetContent = tweetObject.TweetContent,
                        UserDetailId = tweetObject.UserDetailId,
                        Date = tweetObject.Date
                    };
                    context.Tweets.Add(tweet);
                    if (context.SaveChanges() > 0)
                    {
                        newTweet = tweetObject;
                    }
                }
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
            return newTweet;
        }

        public static List<TweetDto.DtoTweet> GetTweets(int followingId)
        {
            var oldTweet = new List<TweetDto.DtoTweet>();

            try
            {
                using (GlitterDBEntities1 context = new GlitterDBEntities1())
                {

                    var Ucontent = (from tweets in context.Tweets
                                    where tweets.UserDetailId == followingId
                                    select tweets).ToList();

                    Ucontent.ForEach(y =>
                    {
                        oldTweet.Add(new TweetDto.DtoTweet()
                        {
                            TweetContent = y.TweetContent
                        });
                    });

                    return oldTweet;

                }
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
            return oldTweet;
        }

        public static TweetDto.DtoTweet EditTweet(TweetDto.DtoTweet editedTweet)
        {
            TweetDto.DtoTweet newtweet = null;
            try
            {
                using (GlitterDBEntities1 context = new GlitterDBEntities1())
                {
                    var tweet = context.Tweets.Find(editedTweet.TweetId);
                    tweet.TweetContent = editedTweet.TweetContent;
                    tweet.Date = editedTweet.Date;
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
            }
            return newtweet;
        }

        public static bool DeleteTweet(TweetDto.DtoTweet tweettoDelete)
        {
            try
            {
                using (GlitterDBEntities1 context = new GlitterDBEntities1())
                {
                    var tweet = context.Tweets.Find(tweettoDelete.TweetId);
                    context.Tweets.Remove(tweet);
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
