using AdminApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminApi.Repository
{
    public interface iadmin
    {
        List<Book> GetBookDetails();

        Book GetBookDetails(int? id);

        int AddBook(Book book);

        int RemoveBook(int? id);
        int UpdateBookRecord(int? Bookid, Book book);

        int IssueBook(IssueDetails issue);
        // int RegisterNewUser(Usercredentials user);
        int RegisterNewUser(Usercheck user);

        List<IssueDetails> GetIssuedBookDetail();
    }
}
