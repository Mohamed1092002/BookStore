using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreDAL.Models;

public class Author
{
    public int AuthorId { get; set; }
    public string AuthorName { get; set; } = string.Empty;
    public string AuthorBio { get; set; } = string.Empty;
    public string AuthorEmail { get; set; } = string.Empty;
    public string AuthorPassword { get; set; } = string.Empty;
    public ICollection<Book> books { get; set; } = new List<Book>();
}
