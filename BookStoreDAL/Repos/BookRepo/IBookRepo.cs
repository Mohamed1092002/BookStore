using BookStoreDAL.Context;
using BookStoreDAL.Models;
using BookStoreDAL.Repos.Generic_Repo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreDAL.Repos.BookRepo;

public interface IBookRepo:IGenericRepo<Book>
{
    List<Book> GetBooksByAuthorName(string authorName);
  
    Book Delete(int BookId);
    Book GetById(int BookId);
}
