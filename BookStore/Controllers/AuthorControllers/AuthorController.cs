using BookStoreBL.DTOs.Author;
using BookStoreBL.Manager.Author;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookStore.Controllers.AuthorControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorManager _authorManager;
        private readonly IConfiguration _configuration;
        public AuthorController(IAuthorManager authorManager,IConfiguration configuration)
        {
            _configuration = configuration;
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
        [HttpPost("Login")]
            public ActionResult Login(string email, string password)
            {
                var author = _authorManager.Login(email, password);
                if (author == null)
                {
                    return NotFound();
                }
                return Ok(author);
            }
        

        [HttpPost("Register")]
        public ActionResult Register(AuthorRegisterDto author)
        {
            var authorDto = _authorManager.Register(author);
            if (authorDto == null)
            {
                return NotFound();
            }
            return Ok(authorDto);
        }

    }
}
