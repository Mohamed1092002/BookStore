using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreBL.DTOs.Author
{
    public class AuthorLogin
    {
        public string AuthorEmail { get; set; } = string.Empty;
        public string AuthorPassword { get; set; } = string.Empty;
    }
}
