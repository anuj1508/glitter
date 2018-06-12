using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDetailDto;

namespace DAL
{
    public class UserDetailDll
    {
        public static Register AddUser(Register register)
        {
            try
            {
                using (GlitterDBEntities1 context = new GlitterDBEntities1())
                {
                    UserDetail user = new UserDetail
                    {
                        Email = register.Email,
                        Password = register.Password,
                        FirstName = register.FirstName,
                        LastName = register.LastName,
                        Image = Enumerable.Repeat((byte)0x20,10).ToArray(),
                        MobileNumber = register.MobileNumber,
                        Country = register.Country
                    };
                    context.UserDetails.Add(user);
                    context.SaveChanges();
                    
                }
            }
            catch (Exception e)
            {
                Console.Write(e);
                throw (e);
            }

            return register;
        }

        public static Login GetUserInfo(Login login)
        {
            Login UserInfo = null;
            try
            {
                using (GlitterDBEntities1 context = new GlitterDBEntities1())
                {
                    var user = (from users in context.UserDetails
                                where users.Email == login.Email &&
                                users.Password == login.Password
                                select users).FirstOrDefault();

                    if (user != null)
                    {
                        UserInfo = new Login
                        {
                            Email = user.Email,
                            Password = user.Password
                        };
                    }
                    else
                    {
                        UserInfo = null;
                    }
                }
            }
            catch (NullReferenceException)
            {
                UserInfo = null;
            }

            return UserInfo;
        }



        public static bool IfEmailIsUnique(string email)
        {
            using (GlitterDBEntities1 context = new GlitterDBEntities1())
            {
                var emailid = (from users in context.UserDetails
                               where users.Email == email
                               select users.Email).FirstOrDefault();
                if (emailid == null)
                    return true;
                else
                    return false;
            }
        }


        public static IList<string> SearchUser(string searchString)
        {
            using (GlitterDBEntities1 context = new GlitterDBEntities1())
            {
                var Fname = (from users in context.UserDetails
                             where users.FirstName == searchString
                             select users.FirstName).ToList();
                if (Fname == null)
                    return null;
                else
                    return Fname;
            }
        }


        public static int GetUserDetailId(string emailId)
        {
            using (GlitterDBEntities1 context = new GlitterDBEntities1())
            {
                var userDetailId = (from e in context.UserDetails select e).Where(x => x.Email.Equals(emailId)).FirstOrDefault().UserDetailId;
                return userDetailId;
            }
        }

    }
}