using BookStoreDAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreDAL.Context
{
    public class BookDbContext:DbContext
    {
        public DbSet<Author> authors => Set<Author>();
        public DbSet<Book> books => Set<Book>();


        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Author>().ToTable("Authors");
            builder.Entity<Book>().ToTable("Books");
            builder.Entity<Book>()
           .HasOne(b => b.Author)
           .WithMany(a => a.books)
           .HasForeignKey(b => b.AuthorId);
        }
    }
}
