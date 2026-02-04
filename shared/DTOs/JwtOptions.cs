using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shared.DTOs
{
    public class JwtOptions
    {
        public string Issuer {  get; set; }
        public string Audience { get; set; }
        public int ExpirationInDays { get; set; }
        public string Key { get; set; }
    }
}
