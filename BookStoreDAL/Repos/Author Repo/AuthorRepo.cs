using BookStoreDAL.Context;
using BookStoreDAL.Models;
using BookStoreDAL.Repos.Generic_Repo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreDAL.Repos.Author_Repo
{
    public class AuthorRepo : GenericRepo<Author>, IAuthorRepo
    {
        private readonly BookDbContext _context;
        public AuthorRepo(BookDbContext context) : base(context)
        {
            _context = context;
        }
        public Author Delete(int authorId)
        {
            return _context.authors.FirstOrDefault(a => a.AuthorId == authorId);

        }

        public Author GetById(int authorId)
        {
            return _context.authors.FirstOrDefault(a => a.AuthorId == authorId);
        }
    }
}
