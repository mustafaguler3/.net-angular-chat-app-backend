using System;
using DatingApp.API.Data;
using DatingApp.API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
	public class BuggyController : BaseController
	{
		private readonly DataContext _context;

        public BuggyController(DataContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetSecret()
        {
            return "secret text";
        }

        [HttpGet("not-found")]
        public ActionResult<User> NotFound()
        {
            var thing = _context.Users.Find(89);

            if (thing == null) return NotFound();

            return thing;
        }

        [HttpGet("server-error")]
        public ActionResult<string> ServerError()
        {
            try
            {
                var thing = _context.Users.Find(89);

                var thingToReturn = thing.ToString();

                return thingToReturn;
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
            
        }

        [HttpGet("bad-request")]
        public ActionResult<string> BadRequest()
        {
            return BadRequest("This was not a good request");
        }
    }
}

