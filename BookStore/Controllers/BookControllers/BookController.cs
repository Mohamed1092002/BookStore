using BookStoreBL.DTOs.Book;
using BookStoreBL.Manager.Book;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers.BookControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookManager _bookManager;

        public BooksController(IBookManager bookManager)
        {
            _bookManager = bookManager;
        }
        [HttpGet("Get All Books")]
        public IActionResult GetAllBooks()
        {
            var books = _bookManager.GetAll();
            return Ok(books);
        }
        [HttpPost("Add Book")]
        public ActionResult AddBook(BookAddDto bookDto)
        {
            _bookManager.Add(bookDto);
            return Ok("Book Added Successfully");
        }
        [HttpDelete("Delete Book{id}")]
        public ActionResult DeleteBook(int id)
        {
            var book = _bookManager.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            _bookManager.remove(id);
            return Ok("Book Deleted Successfully");
        }
        [HttpGet("GetBook{id}")]
        public ActionResult GetBookById(int id)
        {
            var book = _bookManager.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }
        [HttpGet("GetBookbyAuthorName/{authorName}")]
        public ActionResult GetBooksByAuthorName(string authorName)
        {
            var books = _bookManager.GetBooksByAuthorName(authorName);
            if (books == null)
            {
                return NotFound();
            }
            return Ok(books);
        }


    }
}
