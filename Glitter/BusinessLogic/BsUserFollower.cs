using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using UserFollowerDto;
using UserDetailDto;

namespace BusinessLogic
{
    public class BsUserFollower
    {
        public static UserFollowerDto.DtoUserFollower AddFollower(string email, string password, int followerid, int followingid)
        {
            if (!UserFollowerDll.CheckUserLoggedIn(email, password))
            {
                //If user is not logged in
                return null;
            }
            else
            {
                UserFollowerDto.DtoUserFollower userdto = new UserFollowerDto.DtoUserFollower()
                {
                    FollowerId = followerid,
                    UserDetailId = followingid
                };

                UserFollowerDto.DtoUserFollower addFollowing = UserFollowerDll.AddFollower(userdto);

                if (addFollowing != null)
                {
                    return addFollowing;
                }
                else
                {
                    return null;
                }
            }
        }

        public static IList<UserDetailDto.UserData> GetFollowees(string email, string password, int followerId)
        {
            if (!UserFollowerDll.CheckUserLoggedIn(email, password))
            {
                //If user is not logged in
                return null;
            }
            else
            {
                UserFollowerDto.DtoUserFollower obj = new UserFollowerDto.DtoUserFollower()
                {
                    FollowerId = followerId
                };
                IList<UserDetailDto.UserData> getFollowees = UserFollowerDll.GetFollowees(obj.FollowerId);
                if (getFollowees != null)
                {
                    return getFollowees;
                }
                else
                {
                    return null;
                }
            }
        }
        public static IList<UserDetailDto.UserData> GetFollowers(string email, string password, int followeeid)
        {
            if (!UserFollowerDll.CheckUserLoggedIn(email, password))
            {
                //User logged out
                return null;
            }
            else
            {
                UserFollowerDto.DtoUserFollower obj = new UserFollowerDto.DtoUserFollower()
                {
                    UserDetailId = followeeid
                };
                IList<UserDetailDto.UserData> getFollowers = UserFollowerDll.GetFollowers(obj.UserDetailId);
                if (getFollowers != null)
                {
                    return getFollowers;
                }
                else
                {
                    return null;
                }
            }
        }

        public static bool UnFollow(DtoUserFollower newTrack)
        {
            //if (!UserFollowerDll.CheckUserLoggedIn(email, password))
            //{
            //    //User logged out
            //    return false;
            //}

            UserFollowerDto.DtoUserFollower followee = new UserFollowerDto.DtoUserFollower
            {
                UserDetailId = newTrack.FollowerId,
                FollowerId = newTrack.UserDetailId
            };
            return UserFollowerDll.UnFollow(followee);
        }
    }
}

