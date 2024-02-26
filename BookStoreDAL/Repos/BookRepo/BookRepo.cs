using BookStoreDAL.Context;
using BookStoreDAL.Models;
using BookStoreDAL.Repos.Author_Repo;
using BookStoreDAL.Repos.Generic_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreDAL.Repos.BookRepo;

public class BookRepo : GenericRepo<Book>, IBookRepo
{
    private readonly BookDbContext _context;
    public BookRepo(BookDbContext context) : base(context)
    {
        _context= context;
    }

    public List<Book> GetBooksByAuthorName(string authorName)
    {
     return _context.books.Where(b => b.AuthorName == authorName).ToList();
    }
    public Book Delete(int BookId)
    {
        return _context.books.FirstOrDefault(b => b.BookId == BookId);
    }

   

    Book IBookRepo.GetById(int BookId)
    {
        return _context.books.FirstOrDefault(b => b.BookId == BookId);
    }
}

