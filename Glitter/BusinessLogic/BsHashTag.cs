     using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using DAL;

namespace BusinessLogic
{
    public class BsHashTag
    {
        private static IList<HashTagDto.DtoHashTag> SplitHashtags(TweetDto.DtoTweet tweet)
        {
            IList<HashTagDto.DtoHashTag> listOfHashTagsInMessage = new List<HashTagDto.DtoHashTag>();
            var regex = new Regex(@"(?<=#)\w+");
            var hashTagsInMessage = regex.Matches(tweet.TweetContent);
            foreach (Match m in hashTagsInMessage)
            {
                var newhashtag = new HashTagDto.DtoHashTag
                {
                    HashTagName = m.ToString(),
                    TweetId = tweet.TweetId,
                };
                listOfHashTagsInMessage.Add(newhashtag);
            }
            return listOfHashTagsInMessage;
        }

        public static bool AddHashTag(TweetDto.DtoTweet tweet)
        {
            IList<HashTagDto.DtoHashTag> hashTagsInTheMessage = SplitHashtags(tweet);
            bool isAdded = HashTagDll.AddToHashTagList(hashTagsInTheMessage);
            if (isAdded == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool RemoveHashTag(TweetDto.DtoTweet tweet)
        {
            //string message = tweet.Content;
            IList<HashTagDto.DtoHashTag> hashTagsInThisMessage = SplitHashtags(tweet);
            bool isDeleted = HashTagDll.DeleteFromHashTagList(hashTagsInThisMessage);
            if (isDeleted == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}