using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreDAL.Auth.Token
{
    public interface ITokenProvider
    {
        string GenerateToken(List<Claim> claims);
    }
}
