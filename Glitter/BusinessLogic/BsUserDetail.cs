using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDetailDto;
using UserFollowerDto;
using DAL;
using LoginFollowerBindDto;

namespace BusinessLogic
{
    public class BsUserDetail
    {
        public static Register UserRegisteration(Register newRegister)
        {

            if (!UserDetailDll.IfEmailIsUnique(newRegister.Email))
            {
                // Email has been used
                return null;
            }
            else
            {
                Register isUserAddedSuccessfully = UserDetailDll.AddUser(newRegister);
                if (isUserAddedSuccessfully != null)
                {
                    return isUserAddedSuccessfully;
                }
                else
                {
                    return null;
                }
            }
        }
        public static Login UserLogin(string email, string password)
        {
            if (UserDetailDll.IfEmailIsUnique(email))
            {
                return null;
            }
            else
            {
                int loginId = UserDetailDll.GetUserDetailId(email);
                Login userLoginDTO = UserDetailDll.GetUserInfo(new Login
                {
                    Email = email,
                    Password = password
                });

                if (userLoginDTO != null)
                {
                    return userLoginDTO;
                }
                else
                {
                    return null;
                }
            }
        }

        public static IList<TweetDto.DtoTweet> DisplayTweets(DtoLoginFollowerBind userTracks)
        {
            IList<UserData> followees = BsUserFollower.GetFollowees(userTracks.Email, userTracks.Password, userTracks.FollowerId);
            IList<TweetDto.DtoTweet> playGroundTweets = new List<TweetDto.DtoTweet>();
            foreach (var followee in followees)
            {
                foreach (TweetDto.DtoTweet tweet in BsTweet.GetTweets(followee.UserDetailId))
                {
                    playGroundTweets.Add(tweet);
                }
            }

            IList<TweetDto.DtoTweet> myTweets = BsTweet.GetTweets(userTracks.FollowerId);

            foreach (TweetDto.DtoTweet tweet in myTweets)
            {
                playGroundTweets.Add(tweet);
            }

            playGroundTweets.OrderByDescending(x => x.TweetId);
            return playGroundTweets;
        }
    }
}