using BookStoreBL.DTOs.Author;
using BookStoreBL.Manager.Author;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers.AuthorControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorManager _authorManager;
        public AuthorController(IAuthorManager authorManager)
        {
            _authorManager = authorManager;
        }
        [HttpGet("Get All Authors")]
        public IActionResult GetAllAuthors()
        {
            var authors = _authorManager.GetAll();
            return Ok(authors);
        }
      
        [HttpPost("Add Author")]
        
        public ActionResult AddAuthor(AuthorAddDto adminDto)
        {
            _authorManager.Add(adminDto);
            return Ok("Author Added Successfully");
        }
        [HttpDelete("Delete Author{id}")]
        public ActionResult DeleteAuthor(int id)
        {
            var author = _authorManager.GetAuthorById(id);
            if (author == null)
            {
                return NotFound();
            }
           _authorManager.remove(id);
            return Ok("Author Deleted Successfully");
        }

        [HttpGet("Get Author{id}")]
        public ActionResult GetAuthorById(int id)
        {
            var author = _authorManager.GetAuthorById(id);
            if (author == null)
            {
                return NotFound();
            }
            return Ok(author);
        }

    }
}
