using BookStoreBL.DTOs.Author;
using BookStoreDAL.Repos.Author_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookStoreDAL.Models;
using System.Threading.Tasks;

namespace BookStoreBL.Manager.Author;

public class AuthorManager:IAuthorManager
{

    private readonly IAuthorRepo _authorsRepo;
    public AuthorManager(IAuthorRepo authorsRepo)
    {
        _authorsRepo = authorsRepo;
    }

    public void Add(AuthorAddDto author)
    {
        
        var Author = new BookStoreDAL.Models.Author
        {
            AuthorName = author.AuthorName,
            AuthorBio = author.AuthorBio,
        };
        _authorsRepo.Add(Author);
        _authorsRepo.SaveChanges();
        
    }

    public List<AuthorAddDto> GetAll()
    {
        List<BookStoreDAL.Models.Author> AuthorsfromDb = _authorsRepo.GetAll();
        return AuthorsfromDb
        .Select(a => new AuthorAddDto
        {
            AuthorName = a.AuthorName,
            AuthorBio= a.AuthorBio,
        }).ToList();
        
    }

    public AuthorAddDto GetAuthorById(int authorId)
    {
        var author = _authorsRepo.GetById(authorId);
        return new AuthorAddDto
        {
            AuthorName = author.AuthorName,
            AuthorBio = author.AuthorBio,
        };
    }

    public void remove(int authorId)
    {
        _authorsRepo.Delete(authorId);
        _authorsRepo.SaveChanges();
    }
}
