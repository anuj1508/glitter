using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserReactionDto;

namespace DAL
{
    public class UserReactionDll
    {
        public static bool AddToLikes(UserReactionDto.DtoUserReaction reactionObject)
        {
            try
            {
                using (GlitterDBEntities1 context = new GlitterDBEntities1())
                {
                    context.UserReactions.Add(new UserReaction
                    {
                        UserReactionId = reactionObject.UserReactionId,
                        UserDetailId = reactionObject.UserDetailId,
                        IsLiked = 1
                    });
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool ReamoveReaction(UserReactionDto.DtoUserReaction reactionObject)
        {
            try
            {
                using (GlitterDBEntities1 context = new GlitterDBEntities1())
                {
                    //var react = context.Reacts.Find(reactObject.Id);
                    var react = context.UserReactions.FirstOrDefault(l => l.UserReactionId == reactionObject.UserReactionId && l.UserDetailId == reactionObject.UserDetailId);
                    context.UserReactions.Remove(react);
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool AddToDislikes(UserReactionDto.DtoUserReaction reactionObject)
        {
            try
            {
                using (GlitterDBEntities1 context = new GlitterDBEntities1())
                {
                    context.UserReactions.Add(new UserReaction
                    {
                        UserReactionId = reactionObject.UserReactionId,
                        UserDetailId = reactionObject.UserDetailId,
                        IsLiked = 1
                    });
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static int NoOfLikes(int tweetid)
        {
            int count = 0;
            try
            {
                using (GlitterDBEntities1 context = new GlitterDBEntities1())
                {
                    count = (from reactions in context.UserReactions
                             where reactions.UserReactionId == tweetid && reactions.IsLiked == 1
                             select reactions.UserReactionId).ToList().Count;
                }
            }
            catch (Exception)
            {
            }
            return count;
        }

        public static int NoOfDisLikes(int tweetid)
        {
            int count = 0;
            try
            {
                using (GlitterDBEntities1 context = new GlitterDBEntities1())
                {
                    count = (from reactions in context.UserReactions
                             where reactions.UserReactionId == tweetid && reactions.IsLiked == -1
                             select reactions.UserReactionId).ToList().Count;
                }
            }
            catch (Exception)
            {
            }
            return count;
        }


    }
}
