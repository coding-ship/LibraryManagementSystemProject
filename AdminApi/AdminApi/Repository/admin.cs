using AdminApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminApi.Repository
{
    public class admin:iadmin
    {
        DatabaseDbContext context;
        public admin(DatabaseDbContext _context)
        {
            context = _context;
        }

        public int AddBook(Book book)
        {
            int result = 0;
            if (context != null)
            {
                context.Books.Add(book);
                result = context.SaveChanges();

            }
            return result;


        }

        public List<Book> GetBookDetails()
        {
            if (context != null)
            {
                return context.Books.ToList();

            }
            return null;

        }

        public Book GetBookDetails(int? id)
        {

            if (context != null)
            {

                return (context.Books.FirstOrDefault(x => x.Book_Id == id));


            }
            return null;
        }



        //public int RegisterNewUser(User user)
        //{
        //    int result = 0;
        //    if (context != null)
        //    {
        //        context.Usercredential.Add(user);

        //        result = context.SaveChanges();

        //    }
        //    return result;
        //}
        public int RegisterNewUser(Usercheck user)
        {
            int result = 0;
            if (context != null)
            {
                context.Usercheck.Add(user);

                result = context.SaveChanges();

            }
            return result;
        }

        public int RemoveBook(int? id)
        {
            int result = 0;
            if (context != null)
            {
                Book book = context.Books.SingleOrDefault(x => x.Book_Id == id);
                context.Books.Remove(book);
                result = context.SaveChanges();

            }
            return result;
        }

        public int UpdateBookRecord(int? bookid, Book book)
        {
            int result = 0;
            if (context != null)
            {
                Book b = context.Books.SingleOrDefault(x => x.Book_Id == bookid);
                //b.Id = book.Id;
                //b.Book_Id = book.Book_Id;
                b.Book_Name = book.Book_Name;
                b.Author = book.Author;
                b.Language = book.Language;
                b.No_of_pages = book.No_of_pages;
                b.Price = book.Price;

                result = context.SaveChanges();

            }
            return result;
        }

        public List<IssueDetails> GetIssuedBookDetail()
        {



            if (context != null)
            {
                var post = context.IssueDetail.ToList();
                if (post != null)
                {
                    return post;
                }
                return null;

            }
            else
            {
                return null;
            }
        }

        public int IssueBook(IssueDetails issue)
        {
            int result = 0;
            if (context != null)
            {
              //Book book = context.Books.FirstOrDefault(x => x.Book_Id == issue.Book_Id);
              //Usercredentials user = context.Usercredential.FirstOrDefault(x => x.User_Id == issue.User_Id);
              //  if (book != null && user != null)
              //  {


                    context.IssueDetail.Add(issue);
                    result = context.SaveChanges();
                //}

               

            }
            return result;
        }

       
    }
}
