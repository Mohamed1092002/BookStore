using BookStoreBL.DTOs.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreBL.Manager.Book;

public interface IBookManager

{
    List<BookAddDto> GetAll();
    void Add(BookAddDto book);
    void remove(int BookId);
    BookAddDto GetBookById(int BookId);
    List<BookAddDto> GetBooksByAuthorName(string authorName);
}
