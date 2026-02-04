using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shared.DTOs
{
    public class CreateOrUpdateTechnologyDto
    {
        public string Name { get; set; }
        public IFormFile IconUrl { get; set; }
    }
}
