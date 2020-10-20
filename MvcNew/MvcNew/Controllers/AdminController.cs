using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcNew.Models;
using Newtonsoft.Json;

namespace MvcNew.Controllers
{
    public class AdminController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var list = new List<Book>();
            using (var httpclient = new HttpClient())
            {
                httpclient.BaseAddress = new Uri("http://localhost:63479/");
                HttpResponseMessage res = await httpclient.GetAsync("api/Admin/GetBookDetails()");
                if (res.IsSuccessStatusCode)
                {
                    var result = res.Content.ReadAsStringAsync().Result;
                    list = JsonConvert.DeserializeObject<List<Book>>(result);
                }
            }
            return View(list);
        }
        public async Task<IActionResult> Details(int id)
        {
            Book book = new Book();
            using (var httpclient = new HttpClient())
            {
                httpclient.BaseAddress = new Uri("http://localhost:63479/");

                HttpResponseMessage res = await httpclient.GetAsync("api/Admin/GetBookDetails?id=" + id);
                if (res.IsSuccessStatusCode)
                {
                    var result = res.Content.ReadAsStringAsync().Result;
                    book = JsonConvert.DeserializeObject<Book>(result);
                }
            }
            return View(book);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            using (var httpclient = new HttpClient())
            {
                httpclient.BaseAddress = new Uri("http://localhost:63479/");

                var postData = httpclient.PostAsJsonAsync<Book>("api/Admin/AddBook", book);
                var res = postData.Result;
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(book);
        }
        public async Task<IActionResult> Edit(int bookid)
        {
            Book book = new Book();
            using (var httpclient = new HttpClient())
            {
                httpclient.BaseAddress = new Uri("http://localhost:63479/");
                HttpResponseMessage res = await httpclient.GetAsync("api/Admin/UpdateBookRecord?Bookid=" + bookid);
                if (res.IsSuccessStatusCode)
                {
                    var result = res.Content.ReadAsStringAsync().Result;
                    book = JsonConvert.DeserializeObject<Book>(result);
                }
            }
            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            using (var httpclient = new HttpClient())
            {
                httpclient.BaseAddress = new Uri("http://localhost:63479/");
                var postdata = httpclient.PutAsJsonAsync("api/Admin/UpdateBookRecord?Bookid=" + book.Book_Id, book);
                var res = postdata.Result;
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

            }
            return View(book);
        }
        public IActionResult Delete(int id)
        {
            using (var httpclient = new HttpClient())
            {
                httpclient.BaseAddress = new Uri("http://localhost:63479/");
                var delete = httpclient.DeleteAsync("api/Admin/RemoveBook?Bookid=" +id);
                var res = delete.Result;
               
                    return RedirectToAction("Index");
              
            }
        }

        public async Task<IActionResult> IssuedBook()
        {
            var list = new List<IssueDetails>();
            using (var httpclient = new HttpClient())
            {
                httpclient.BaseAddress = new Uri("http://localhost:63479/");
                HttpResponseMessage res = await httpclient.GetAsync("api/Admin/GetIssuedBookDetail");
                if (res.IsSuccessStatusCode)
                {
                    var result = res.Content.ReadAsStringAsync().Result;
                    list = JsonConvert.DeserializeObject<List<IssueDetails>>(result);
                }
            }
            return View(list);
        }
        public IActionResult IssueBook()
        {
            return View();
        }

        [HttpPost]
        public IActionResult IssueBook(IssueDetails issue)
        {
            using (var httpclient = new HttpClient())
            {
                                 
                httpclient.BaseAddress = new Uri("http://localhost:63479/");
                IssueDetails issue1 = new IssueDetails() { Book_Id=issue.Book_Id,Book_Name=issue.Book_Name,Book_Author=issue.Book_Author,User_Id=issue.User_Id,User_Name=issue.User_Name,Issue_Date=issue.Issue_Date,Phone_Number=issue.Phone_Number };
                var postData =  httpclient.PostAsJsonAsync<IssueDetails>("api/Admin/IssueBook",issue1);
                var res = postData.Result;
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("IssuedBook");
                }
            }
            return View(issue);
        }
        
        public IActionResult AddNewUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewUser(Usercheck user)
        {
            using (var httpclient = new HttpClient())
            {
                httpclient.BaseAddress = new Uri("http://localhost:63479/");

                var postData = httpclient.PostAsJsonAsync<Usercheck>("api/Admin/RegisterNewUser", user);
                var res = postData.Result;
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(user);
        }


    }
}
