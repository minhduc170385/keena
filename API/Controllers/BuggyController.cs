using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BuggyController : ControllerBase
    {
        private readonly DataContext _context;
        public BuggyController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("auth")]
        public ActionResult<string> GetSecret()
        {
            return "secret text";
        }
        [HttpGet("not-found")]
        public ActionResult<string> GetNotFound()
        {
            return NotFound();            
        }
        [HttpGet("server-error")]
        public ActionResult<string> GetServerError()
        {
            //try
            //{
                var thing = _context.Doctors.Find(-1);
                var thingToReturn = thing.ToString();
                return thingToReturn;
            //}
            //catch(Exception ex)
            //{
            //    return StatusCode(500, "Computer say no");
            //}
            
        }
        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest()
        {
            return BadRequest("This was not a good request");
        }
    }
}
