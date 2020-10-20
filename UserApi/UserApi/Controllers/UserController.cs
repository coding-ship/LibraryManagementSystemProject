using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserApi.Repository;

namespace UserApi.Controllers
{ 
   
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class UserController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(UserController));
        iuser Iuser;
        public UserController(iuser _Iuser)
        {
            Iuser = _Iuser;
        }
        // GET: api/<UserController>

        [HttpGet]
        [Route("GetBookDetails()")]
        public IActionResult GetBookDetails()
        {
            _log4net.Info(" Http GetBookDetails request Initiated");
            try
            {
                var books = Iuser.GetBookDetails();
                if (books != null)
                {
                    return Ok(books);
                }

                return NotFound();

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }



        [HttpGet]
        [Route("Book_Issued")]
        public IActionResult Book_Issued(int? id)
        {
            _log4net.Info(" Http Get request Book_Issued initiated");
            try
            {
                var book = Iuser.Book_Issued(id);
                if (book != null)
                {
                    return Ok(book);
                }

                return NotFound();

            }
            catch (Exception)
            {
                return BadRequest();
            }

        }


    }
}
