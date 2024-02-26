using BookStoreDAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreDAL.Repos.Generic_Repo;

public class GenericRepo<T> : IGenericRepo<T> where T : class
{
    private readonly BookDbContext _context;
    public GenericRepo(BookDbContext context)
    {
        _context = context;
    }

    public void Add(T item)
    {
        _context.Set<T>().Add(item);
    }

    public void Delete(T item)
    {
        _context.Set<T>().Remove(item);
    }

    public T? Get(int id)
    {
        return _context.Set<T>().Find(id);
    }

    public List<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }

    public void Update(T item)
    {
      
    }
}
