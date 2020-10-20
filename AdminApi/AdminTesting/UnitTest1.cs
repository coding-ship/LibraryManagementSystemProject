using AdminApi.Controllers;
using AdminApi.Models;
using AdminApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdminTesting
{
    public class Tests
    {
        DatabaseDbContext context;
        [SetUp]
        public void Setup()
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
            var mockContext = new Mock<DatabaseDbContext>();
            mockContext.Setup(c => c.Books).Returns(mockSet.Object);
            context = mockContext.Object;

        }

        [Test]
        public void GetBookDetails()
        {
            var res = new Mock<admin>(context);
            AdminController h2 = new AdminController(res.Object);
            var d1 = h2.GetBookDetails();
            var R1 = d1 as OkObjectResult;
            Assert.AreEqual(200, R1.StatusCode);
        }

        [Test]
        public void GetBookDetailsbyid()
        {
            var res = new Mock<admin>(context);
            AdminController h2 = new AdminController(res.Object);
            var d1 = h2.GetBookDetails(1);
            var R1 = d1 as OkObjectResult;
            Assert.AreEqual(200, R1.StatusCode);
        }

      



        [Test]
        public void AddBook()
        {
            try
            {

                var res = new Mock<admin>(context);
                AdminController h2 = new AdminController(res.Object);
                Book book = new Book { Book_Id = 10, Book_Name = "Biology", Author = "S. Chand", Language = "English", No_of_pages = 500, Price = 400 };
                var d1 = h2.AddBook(book);
                var R1 = d1 as OkObjectResult;
                Assert.AreEqual(200, R1.StatusCode);
            }
            catch (Exception e)
            {
                Assert.AreEqual("Object reference not set to an instance of an object.", e.Message);
            }


        }
        [Test]
        public void Test4()
        {
            try
            {

                var res = new Mock<admin>(context);
                AdminController h2 = new AdminController(res.Object);
                Book book = new Book { Book_Id = 11, Book_Name = "Biology", Author = "S. Chand", Language = "English", No_of_pages = 500, Price = 400 };
                var d1 = h2.AddBook(book);
                var R1 = d1 as OkObjectResult;
                Assert.AreEqual(200, R1.StatusCode);
            }
            catch (Exception e)
            {
                Assert.AreEqual("Object reference not set to an instance of an object.", e.Message);
            }


        }
        [Test]
        public void RemoveBook()
        {
            try
            {

                var res = new Mock<admin>(context);
                AdminController h2 = new AdminController(res.Object);
                //Book book = new Book { Book_Id = 10, Book_Name = "Biology", Author = "S. Chand", Language = "English", No_of_pages = 500, Price = 400 };
                var d1 = h2.RemoveBook(2);
                var R1 = d1 as OkObjectResult;
                Assert.AreEqual(200, R1.StatusCode);
            }
            catch (Exception e)
            {
                Assert.AreEqual("Object reference not set to an instance of an object.", e.Message);
            }


        }
        [Test]
        public void RegisterNewUser()
        {
            try
            {

                var res = new Mock<admin>(context);
                AdminController h2 = new AdminController(res.Object);
                Usercheck user = new Usercheck
                {
                   
                    UserName = "shubham",
                    Password = "qdqwddq"
                 };
                //Book book = new Book { Book_Id = 10, Book_Name = "Biology", Author = "S. Chand", Language = "English", No_of_pages = 500, Price = 400 };
                var d1 = h2.RegisterNewUser(user);
                var R1 = d1 as OkObjectResult;
                Assert.AreEqual(200, R1.StatusCode);
            }
            catch (Exception e)
            {
                Assert.AreEqual("Object reference not set to an instance of an object.", e.Message);
            }


        }

        [Test]
        public void IssueBook()
        {
            try
            {

                var res = new Mock<admin>(context);
                AdminController h2 = new AdminController(res.Object);
                IssueDetails issue = new IssueDetails
                {
                    Book_Id = 15,
                    User_Id=1,
                    Book_Name="mathematics",
                    Book_Author="rs agarwal",
                    User_Name="shubham",
                    Phone_Number="8544565511",
                    Issue_Date="22/10/2020"
                     
                };
              
                var d1 = h2.IssueBook(issue);
                var R1 = d1 as OkObjectResult;
                Assert.AreEqual(200, R1.StatusCode);
            }
            catch (Exception e)
            {
                Assert.AreEqual("Object reference not set to an instance of an object.", e.Message);
            }


        }

        [Test]
        public void GetIssuedBookDetail()
        {
            try
            {

                var res = new Mock<admin>(context);
                AdminController h2 = new AdminController(res.Object);
                var d1 = h2.GetIssuedBookDetail();
                var R1 = d1 as OkObjectResult;
                Assert.AreEqual(200, R1.StatusCode);
            }
            catch (Exception e)
            {
                Assert.AreEqual("Object reference not set to an instance of an object.", e.Message);
            }


        }
       
          


      
    }
}