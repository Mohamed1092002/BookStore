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
            AuthorEmail = author.AuthorEmail,
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
            AuthorEmail = a.AuthorEmail,
        }).ToList();
        
    }

    public AuthorAddDto GetAuthorById(int authorId)
    {
        var author = _authorsRepo.GetById(authorId);
        return new AuthorAddDto
        {
            AuthorName = author.AuthorName,
            AuthorBio = author.AuthorBio,
            AuthorEmail = author.AuthorEmail,
        };
    }

    public AuthorLogin Login(string email, string password)
    {
        var author = _authorsRepo.GetAuthorByEmail(email);
        if (author == null)
        {
            return null;
        }
        if (author.AuthorPassword == password)
        {
            return new AuthorLogin
            {
               
                AuthorEmail = author.AuthorEmail,
                AuthorPassword = author.AuthorPassword,
            };
        }
        return null;
    }
    
    public void remove(int authorId)
    {
        _authorsRepo.Delete(authorId);
        _authorsRepo.SaveChanges();
    }

    

    AuthorRegisterDto IAuthorManager.Register(AuthorRegisterDto author)
    {
     
        var Author = new BookStoreDAL.Models.Author
        {
            AuthorName = author.AuthorName,
            AuthorBio = author.AuthorBio,
            AuthorEmail = author.AuthorEmail,
            AuthorPassword = author.AuthorPassword,
        };
        _authorsRepo.Add(Author);
        _authorsRepo.SaveChanges();
        return author;
    }
}
