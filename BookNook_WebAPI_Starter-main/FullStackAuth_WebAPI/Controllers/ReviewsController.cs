using Microsoft.AspNetCore.Mvc;
using FullStackAuth_WebAPI.Models;
using FullStackAuth_WebAPI.Data;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FullStackAuth_WebAPI.Controllers
{
    [Route("api/Reviews")]
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
            string userId = User.FindFirstValue("id");

            // If the user ID is null or empty, the user is not authenticated, so return a 401 unauthorized response
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }
           
            /*User loggedInUser = _context.Users.Find(userId);*/
            _context.Reviews.Add(review);
            _context.SaveChanges();
            return StatusCode(201, review);
        }

       
    }
}
