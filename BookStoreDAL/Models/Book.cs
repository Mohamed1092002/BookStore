using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreDAL.Models;

public class Book
{
    public int BookId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; } = string.Empty;
    public bool IsAvailable { get; set; } = true;

   
    public int AuthorId { get; set; }

    public Author? Author { get; set; }
    public string AuthorName { get; set; } = string.Empty;

}
