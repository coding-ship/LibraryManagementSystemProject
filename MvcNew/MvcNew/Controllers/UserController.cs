using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcNew.Models;
using Newtonsoft.Json;

namespace MvcNew.Controllers
{
    public class UserController : Controller
    {
        public async Task<IActionResult> Index()
        { 
            var list = new List<Book>();
            using (var httpclient = new HttpClient())
            {
                httpclient.BaseAddress = new Uri("http://localhost:63554/");
                HttpResponseMessage res = await httpclient.GetAsync("api/User/GetBookDetails()");
                if (res.IsSuccessStatusCode)
                {
                    var result = res.Content.ReadAsStringAsync().Result;
                    list = JsonConvert.DeserializeObject<List<Book>>(result);
                }
            }
            return View(list);
        }


        public async Task<IActionResult> Details(int id)
        {   var issuedbook = new List<IssueDetails> ();
           
            using (var httpclient = new HttpClient())
            {
                httpclient.BaseAddress = new Uri("http://localhost:63554/");

                HttpResponseMessage res = await httpclient.GetAsync("api/User/Book_Issued?id=" + id);
                if (res.IsSuccessStatusCode)
                {
                    var result = res.Content.ReadAsStringAsync().Result;
                   
                    issuedbook = JsonConvert.DeserializeObject<List<IssueDetails>>(result);
                }
            }
            return View(issuedbook);
        }
       
       
    }
}
