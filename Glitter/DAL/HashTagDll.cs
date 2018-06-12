using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HashTagDto;

namespace DAL
{
    public class HashTagDll
    {
        public static bool AddToHashTagList(IList<DtoHashTag> listOFHashTags)
        {
            try
            {
                using (GlitterDBEntities1 context = new GlitterDBEntities1())
                {
                    foreach (DtoHashTag hashtag in listOFHashTags)
                    {
                        HashTag newHashtag = context.HashTags.FirstOrDefault(a => a.HashTagName == hashtag.HashTagName);

                            context.HashTags.Add(new HashTag
                            {
                                HashTagName = newHashtag.HashTagName,
                                TweetId = newHashtag.TweetId
                            });
                        
                    }
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool DeleteFromHashTagList(IList<DtoHashTag> listOFHashTags)
        {
            try
            {
                using (GlitterDBEntities1 context = new GlitterDBEntities1())
                {
                    foreach (DtoHashTag hashtag in listOFHashTags)
                    {
                        HashTag newHashtag = context.HashTags.FirstOrDefault(a => a.HashTagName == hashtag.HashTagName && a.TweetId == hashtag.TweetId);
                        //if a hashtag already exists
                        if (newHashtag != null)
                        {
                            context.HashTags.Remove(newHashtag);
                        }
                        context.SaveChanges();
                    }
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}