using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcNew.Models;
using Newtonsoft.Json;

namespace MvcNew.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginCheck(Usercheck user)
        {
            string token = "";
            using (var httpclient = new HttpClient())
            {
                httpclient.BaseAddress = new Uri("http://localhost:63582/");
                var postData =  httpclient.PostAsJsonAsync<Usercheck>("api/TokenValidate/api/Token/LoginDetail", user);
                var res = postData.Result;
                if (res.IsSuccessStatusCode)
                {
                    token = await res.Content.ReadAsStringAsync();
                    TempData["token"] = token;
                    

                    return RedirectToAction("Index", "User");
                }
            }
            return View("Login");
        }
    }
}


