using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreDAL.Auth.TokenSetting
{
    public class JWTSetting
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audicne { get; set; }

        public int DurationInMinutes { get; set; }
    }
}