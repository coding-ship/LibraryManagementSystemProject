using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserApi.Models;

namespace UserApi.Repository
{
    public class user:iuser
    {
        UserDbContext context;
        public user(UserDbContext _context)
        {
            context = _context;
        }

        public List<Book> GetBookDetails()
        {
            if (context != null)
            {
                return context.Books.ToList();

            }
            return null;

        }
        public List<IssueDetails> Book_Issued(int? Id)
        {
            if (context != null)
            {
                var detail = from obj in context.IssueDetail where obj.User_Id == Id select obj;
                return detail.ToList();


            }
            return null;

        }


        //public int UpdateDetail(int Userid, int age, string PhnNo = "", string Address = "")
        //{
        //    int result = 0;
        //    if (context != null)
        //    {
        //        Usercredentials user = context.Usercredential.FirstOrDefault(x => x.User_Id == Userid);
        //        if ((age != 0) || (PhnNo == "") || (Address == ""))
        //        {
        //            user.Age = age;
        //            user.Phone_no = PhnNo;
        //            user.Address = Address;
        //        }
        //        result = context.SaveChanges();

        //    }
        //    return result;
        //}
    }
}
