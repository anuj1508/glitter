using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HashTagDto;
using TweetDto;
using UserDetailDto;
using UserFollowerDto;
using UserReactionDto;
using BusinessLogic;
using LoginFollowerBindDto;

namespace Glitter.Controllers
{
    public class UserController : ApiController
    {
        [HttpPost]
        public Register UserRegisteration(Register newRegister)
        {
            return BsUserDetail.UserRegisteration(newRegister);
            //return BsUserDetail.UserRegisteration(newRegister.Email, newRegister.Password, newRegister.FirstName, newRegister.LastName, newRegister.Image, newRegister.MobileNumber, newRegister.Country);
        }

        [HttpPost]
        public Login Login(Login newLogin)
        {
            return BsUserDetail.UserLogin(newLogin.Email, newLogin.Password);
        }

        [HttpPost]
        public DtoUserFollower AddFollower(DtoLoginFollowerBind trackUser)
        {
            return BsUserFollower.AddFollower(trackUser.Email, trackUser.Password, trackUser.FollowerId, trackUser.UserDetailId);
        }

        [HttpPost]
        public IList<UserData> GetFollowings(DtoLoginFollowerBind trackUser)
        {
            return BsUserFollower.GetFollowees(trackUser.Email, trackUser.Password, trackUser.UserDetailId);
        }

        [HttpPost]
        public IList<UserData> GetFollowers(DtoLoginFollowerBind trackUser)
        {
            return BsUserFollower.GetFollowers(trackUser.Email, trackUser.Password, trackUser.UserDetailId);
        }

        [HttpPost]
        public bool UnfollowUser(DtoUserFollower newTrack)
        {
            return BsUserFollower.UnFollow(newTrack);
        }
    }
}
