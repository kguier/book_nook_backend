using Microsoft.AspNetCore.Mvc;
using FullStackAuth_WebAPI.Models;
using FullStackAuth_WebAPI.Data;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FullStackAuth_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReviewsController(ApplicationDbContext context)
        {
            _context = context;
        }


        // POST api/Reviews
        [HttpPost, Authorize]
        public IActionResult Post([FromBody] Review review)
        {

            _context.Reviews.Add(review);
            var userId = User.FindFirstValue("id");
            User loggedInUser = _context.Users.Find(userId);
            return StatusCode(201, review);
        }

       
    }
}
