using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreBL.DTOs.Book;

public class BookAddDto
{
    public string Title { get; set; }
    public string Description { get; set; } = string.Empty;
    public bool IsAvailable { get; set; } = true;
    public string AuthorName { get; set; } = string.Empty;
    public int AuthorId { get; set; }
}
