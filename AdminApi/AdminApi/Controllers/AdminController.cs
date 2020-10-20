using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminApi.Models;
using AdminApi.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdminApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   [EnableCors("AllowOrigin")]
    public class AdminController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(AdminController));
        iadmin adm;
        public AdminController(iadmin _adm)
        {
            adm = _adm;
        }
        // GET: api/<AdminController>

        [HttpGet]
        [Route("GetBookDetails()")]
        public IActionResult GetBookDetails()
        {
            _log4net.Info(" Http GetBookDetails request Initiated");
            try
            {
                var books = adm.GetBookDetails();
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

        // GET api/<AdminController>/5
        // [HttpGet("{id}")]
        [HttpGet]
        [Route("GetBookDetails")]
        public IActionResult GetBookDetails(int? id)
        {
            _log4net.Info(" Http request GetBookDetails as per Bookid  Initiated");
            try
            {
                var book = adm.GetBookDetails(id);
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

        // POST api/<AdminController>

        [HttpPost]
        [Route("IssueBook")]
        public IActionResult IssueBook(IssueDetails issue)
        {
            _log4net.Info(" Http request IssueBook Initiated");
            try
            {
                var i = adm.IssueBook(issue);
                if (i > 0)
                {
                    return Ok(i);
                }
                else
                {
                    return NoContent();
                }

            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        [HttpPost]
        [Route("AddBook")]
        public IActionResult AddBook([FromBody] Book book)
        {
            _log4net.Info(" Http request AddBook Initiated");
            try
            {
                var i = adm.AddBook(book);
                if (i > 0)
                {
                    return Ok(i);
                }
                else
                {
                    return NoContent();
                }

            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        // PUT api/<AdminController>/5
        [HttpPut]
        [Route("UpdateBookRecord")]
        public IActionResult UpdateBookRecord(int? Bookid, [FromBody] Book book)
        {
            _log4net.Info(" Http request UpdateBookRecord Initiated");
            try
            {
                var i = adm.UpdateBookRecord(Bookid, book);
                if (i > 0)
                {
                    return Ok(i);
                }
                else
                {
                    return NoContent();
                }

            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        // DELETE api/<AdminController>/5
        [HttpDelete]
        [Route("RemoveBook")]
        public IActionResult RemoveBook(int? Bookid)
        {
            _log4net.Info(" Http request RemoveBook Initiated");
            try
            {
                var i = adm.RemoveBook(Bookid);
                if (i > 0)
                {
                    return Ok(i);
                }
                else
                {
                    return NoContent();
                }

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        //[HttpPost]
        //[Route("RegisterNewUser")]
        //public IActionResult RegisterNewUser([FromBody] Usercredentials user)
        //{
        //    _log4net.Info(" Http request RegisterNewUser Initiated");
        //    try
        //    {
        //        var i = adm.RegisterNewUser(user);
        //        if (i > 0)
        //        {
        //            return Ok(i);
        //        }
        //        else
        //        {
        //            return NoContent();
        //        }

        //    }
        //    catch (Exception)
        //    {
        //        return BadRequest();
        //    }

        //}

[HttpPost]
[Route("RegisterNewUser")]
public IActionResult RegisterNewUser([FromBody] Usercheck user)
{
    _log4net.Info(" Http request RegisterNewUser Initiated");
    try
    {
        var i = adm.RegisterNewUser(user);
        if (i > 0)
        {
            return Ok(i);
        }
        else
        {
            return NoContent();
        }

    }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpGet]
        [Route("GetIssuedBookDetail")]
        public IActionResult GetIssuedBookDetail()
        {
            _log4net.Info(" Http request RegisterNewUser Initiated");
            try
            {
                var book = adm.GetIssuedBookDetail();
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
