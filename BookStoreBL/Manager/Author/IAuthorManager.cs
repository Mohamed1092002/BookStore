using BookStoreBL.DTOs.Author;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreBL.Manager.Author;

public interface IAuthorManager
{
    List<AuthorAddDto> GetAll();
    void Add(AuthorAddDto author);
    void remove(int authorId);
    AuthorAddDto GetAuthorById(int authorId);

}
