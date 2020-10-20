using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UserApi.Controllers;
using UserApi.Models;
using UserApi.Repository;

namespace UserTesting
{
    public class Tests
    {
        UserDbContext context;
      

        [SetUp]
        public void Setup1()
        {
            var booklist = new List<Book>
            {
                new Book{Id=1, Book_Id=1, Book_Name="Mathematics", Author="RS Agarwal",Language="English",No_of_pages=200,Price=400 },
                new Book{Id=2, Book_Id=2, Book_Name="Physics", Author="RS Agarwal",Language="English",No_of_pages=300,Price=200 },
                new Book{Id=3, Book_Id=3, Book_Name="Chemistry", Author="RS Agarwal",Language="English",No_of_pages=400,Price=400 },new Book{Id=1, Book_Id=1, Book_Name="Mathematics", Author="RS Agarwal",Language="English",No_of_pages=200,Price=400 },

            };

            var issue = new List<IssueDetails>
        { new IssueDetails{ Id=1,Book_Id=1,User_Id=1,User_Name="shubham",Book_Name="Mathematics",Book_Author="RS Agarwal",Issue_Date="20/10/2020",Phone_Number="6128128221"}

        };
            var books = booklist.AsQueryable();
            var mockSet = new Mock<DbSet<Book>>();
            mockSet.As<IQueryable<Book>>().Setup(m => m.Provider).Returns(books.Provider);
            mockSet.As<IQueryable<Book>>().Setup(m => m.Expression).Returns(books.Expression);
            mockSet.As<IQueryable<Book>>().Setup(m => m.ElementType).Returns(books.ElementType);
            mockSet.As<IQueryable<Book>>().Setup(m => m.GetEnumerator()).Returns(books.GetEnumerator());
            var mockContext = new Mock<UserDbContext>();
            mockContext.Setup(c => c.Books).Returns(mockSet.Object);
            context = mockContext.Object;

        }
        [Test]
        public void GetBookDetails()
        {
            var res = new Mock<user>(context);
            UserController h2 = new UserController(res.Object);
            var d1 = h2.GetBookDetails();
            var R1 = d1 as OkObjectResult;
            Assert.AreEqual(200, R1.StatusCode);
        }


    }
}