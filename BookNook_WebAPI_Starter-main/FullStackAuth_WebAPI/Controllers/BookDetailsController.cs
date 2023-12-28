using FullStackAuth_WebAPI.Data;
using FullStackAuth_WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using FullStackAuth_WebAPI.DataTransferObjects;

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
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                /*var book = _context.Find(bookId);*/
            }
            catch (Exception ex)
            {
                // If an error occurs, return a 500 internal server error with the error message
                return StatusCode(500, ex.Message);
            }
            return StatusCode(200);
        }

       
    }
}
