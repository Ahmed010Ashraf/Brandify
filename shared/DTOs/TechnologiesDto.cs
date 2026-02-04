using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shared.DTOs
{
    public class TechnologiesDto
    {
        public int  Id { get; set; }
        public string Name { get; set; }
        public string IconUrl { get; set; }
    }
}
