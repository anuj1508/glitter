using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserFollowerDto;

namespace DAL
{
    public class UserFollowerDll
    {
        public static DtoUserFollower AddFollower(DtoUserFollower userTrack)
        {
            DtoUserFollower newFollowee = new DtoUserFollower();
            try
            {
                using (GlitterDBEntities1 context = new GlitterDBEntities1())
                {
                    UserFollower followee = new UserFollower
                    {
                        FollowerId = userTrack.FollowerId,
                        UserDetailId = userTrack.UserDetailId
                    };
                    context.UserFollowers.Add(followee);
                    context.SaveChanges();

                    {
                        newFollowee.UserDetailId = followee.UserDetailId;
                        newFollowee.FollowerId = followee.FollowerId;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return newFollowee;
        }

        public static IList<UserDetailDto.UserData> GetFollowees(int ucid)
        {
            var list = new List<UserDetailDto.UserData>();
            try
            {
                using (GlitterDBEntities1 context = new GlitterDBEntities1())
                {
                    var list1 = (from userConnection in context.UserFollowers
                                 where userConnection.FollowerId == ucid
                                 select userConnection).ToList();
                    list1.ForEach(item =>
                    {
                        list.Add(new UserDetailDto.UserData()
                        {
                            UserDetailId = item.UserDetailId,
                            FirstName = item.UserDetail.FirstName,
                            Image = item.UserDetail.Image
                        });
                    });
                }
            }
            catch (Exception)
            {
            }
            return list;
        }

        public static IList<UserDetailDto.UserData> GetFollowers(int ucid)
        {
            var list = new List<UserDetailDto.UserData>();
            try
            {
                using (GlitterDBEntities1 context = new GlitterDBEntities1())
                {
                    var list1 = (from userConnection in context.UserFollowers
                                 where userConnection.UserDetailId == ucid
                                 select userConnection).ToList();
                    list1.ForEach(item =>
                    {
                        list.Add(new UserDetailDto.UserData()
                        {
                            UserDetailId = item.FollowerId,
                            FirstName = item.UserDetail.FirstName,
                            Image = item.UserDetail.Image
                        });
                    });
                }
            }
            catch (Exception)
            {
            }
            return list;
        }

        public static bool UnFollow(DtoUserFollower followee)
        {
            try
            {
                using (GlitterDBEntities1 context = new GlitterDBEntities1())
                {
                    var following = (from followings in context.UserFollowers
                                     where followings.FollowerId == followee.FollowerId &&
                                     followings.UserDetailId == followee.UserDetailId
                                     select followings).FirstOrDefault();
                    if (following == null)
                    {
                        return false;
                    }
                    context.UserFollowers.Remove(following);
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool CheckUserLoggedIn(string emailId, string password)
        {
            using (GlitterDBEntities1 context = new GlitterDBEntities1())
            {
                var emailCheck = (from users in context.UserDetails
                                  where users.Email == emailId
                                  select users.Email).ToList();
                var passwordCheck = (from users in context.UserDetails
                                     where users.Password == password
                                     select users.Password).ToList();
                if (emailCheck.Count() != 0 && passwordCheck.Count() != 0)
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
}
