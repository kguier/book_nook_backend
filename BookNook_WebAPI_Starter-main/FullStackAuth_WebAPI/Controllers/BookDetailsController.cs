using FullStackAuth_WebAPI.Data;
using FullStackAuth_WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using FullStackAuth_WebAPI.DataTransferObjects;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization.Metadata;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FullStackAuth_WebAPI.Controllers
{
    [Route("api/BookDetails")]
    [ApiController]
    public class BookDetailsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BookDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET api/BookDetails/5
        [HttpGet("{bookId}")]
        public IActionResult GetBookDetailsByID(string bookId)
        {
            try
            {
                var reviews = _context.Reviews.Where(r => r.BookId == bookId).Include(r => r.User).ToList();

                var book = new BookDetailsDto
                {
                    BookId = bookId,
                    Reviews = reviews.Select(r => new ReviewWithUserDto
                    {
                        Id = r.Id,
                        BookId = r.BookId,
                        Text = r.Text,
                        Rating = r.Rating,
                        User = new UserForDisplayDto
                        {
                            Id = r.User.Id,
                            FirstName = r.User.FirstName,
                            LastName = r.User.LastName,
                            UserName = r.User.UserName,
                        }
                    }).ToList(),
                    AverageRating = reviews.Select(r => r.Rating).Average(),
                    IsFavorite = false,

                };

               /* string userId = User.FindFirstValue("id");*/

                return StatusCode(200, book);
            }
            catch (Exception ex)
            {
                // If an error occurs, return a 500 internal server error with the error message
                return StatusCode(500, ex.Message);
            }
            
        }

       
    }
}
