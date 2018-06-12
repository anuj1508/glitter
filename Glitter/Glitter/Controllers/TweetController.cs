using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UserDetailDto;
using BusinessLogic;
using TweetDto;
using HashTagDto;
using UserFollowerDto;
using UserReactionDto;
using LoginFollowerBindDto;


namespace Glitter.Controllers
{
    public class TweetController : ApiController
    {
        [HttpPost]
        public DtoTweet AddTweet([FromBody]DtoTweet tweetDTO)
        {
            DtoTweet tweetObject = new DtoTweet();

            tweetObject = BsTweet.AddTweet(tweetDTO.UserDetailId, tweetDTO.TweetContent);

            return tweetObject;
        }

        [HttpGet]
        public IList<DtoTweet> GetUserTweets(int id)
        {
            IList<DtoTweet> listOfTweets = new List<DtoTweet>();

            listOfTweets = BsTweet.GetTweets(id);

            return listOfTweets;
        }

        [HttpPost]
        public bool DeleteTweet(DtoTweet tweetObj)
        {
            return BsTweet.DeleteTweet(tweetObj);
        }

        [HttpPost]
        public DtoTweet EditTweet(DtoTweet tweetObj1, DtoTweet tweetObj2)
        {
            return BsTweet.EditTweet(tweetObj1, tweetObj2);
        }

        [HttpPost]
        public IList<DtoTweet> DisplayTweets(DtoLoginFollowerBind userTracks)
        {
            return BsUserDetail.DisplayTweets(userTracks);
        }

        [HttpPost]
        public bool AddHashTag(DtoTweet addHash)
        {
            return BsHashTag.AddHashTag(addHash);
        }

        [HttpPost]
        public bool RemoveHashTag(DtoTweet removeHash)
        {
            return BsHashTag.RemoveHashTag(removeHash);
        }

        [HttpPost]
        public bool LikeTweet(DtoTweet likeTweet)
        {
            return BsUserReaction.Like(likeTweet);
        }

        [HttpPost]
        public bool DislikeTweet(DtoTweet disLikeTweet)
        {
            return BsUserReaction.DisLike(disLikeTweet);
        }

        [HttpPost]
        public bool UndoReaction(DtoTweet actionTweet)
        {
            return BsUserReaction.UndoReaction(actionTweet);
        }

        [HttpGet]
        public int NoOfLikes(int tweetId)
        {
            return BsUserReaction.NoOfLikes(tweetId);
        }

        [HttpGet]
        public int NoOfDislikes(int tweetId)
        {
            return BsUserReaction.NoOfDisLikes(tweetId);
        }
    }
}
