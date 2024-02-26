using BookStoreBL.DTOs.Book;
using BookStoreDAL.Models;
using BookStoreDAL.Repos.Author_Repo;
using BookStoreDAL.Repos.BookRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreBL.Manager.Book;

public class BookManager : IBookManager
{
    private readonly IBookRepo _bookRepo;
    public BookManager(IBookRepo bookRepo)
    {
        _bookRepo = bookRepo;
    }
    public void Add(BookAddDto book)
    {
        var Book = new BookStoreDAL.Models.Book
        {
            Title = book.Title,
            Description = book.Description,
            IsAvailable = book.IsAvailable,
            AuthorName = book.AuthorName,
            AuthorId = book.AuthorId
        };
        _bookRepo.Add(Book);
        _bookRepo.SaveChanges();
    }

    public List<BookAddDto> GetAll()
    {

        List<BookStoreDAL.Models.Book> BooksfromDb = _bookRepo.GetAll();
        return BooksfromDb
        .Select(b => new BookAddDto
        {
            Title = b.Title,
            Description = b.Description,
            IsAvailable = b.IsAvailable,
            AuthorName = b.AuthorName,
        }).ToList();
    }

    public BookAddDto GetBookById(int BookId)
    {
        var book = _bookRepo.GetById(BookId);
        return new BookAddDto
        {
            Title = book.Title,
            Description = book.Description,
            IsAvailable = book.IsAvailable,
            AuthorName = book.AuthorName,
        };
    }

    public List<BookAddDto> GetBooksByAuthorName(string authorName)
    {
        List<BookStoreDAL.Models.Book> BooksfromDb = _bookRepo.GetBooksByAuthorName(authorName);
        return BooksfromDb
        .Select(b => new BookAddDto
        {
            Title = b.Title,
            Description = b.Description,
            IsAvailable = b.IsAvailable,
            AuthorName = b.AuthorName,
        }).ToList();
    }
    

    public void remove(int BookId)
    {
        _bookRepo.Delete(BookId);
        _bookRepo.SaveChanges();
    }
}
