using BookStoreDAL.Models;
using BookStoreDAL.Repos.Generic_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreDAL.Repos.Author_Repo;

public interface IAuthorRepo:IGenericRepo<Author>
{
    Author Delete(int authorId);
    Author GetById(int authorId);
}
