using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserApi.Models;

namespace UserApi.Repository
{
    public interface iuser
    {
        List<Book> GetBookDetails();
        List<IssueDetails> Book_Issued(int? Id);

       // int UpdateDetail(int Userid, int age, string PhnNo = "", string Address = "");
    }
}
