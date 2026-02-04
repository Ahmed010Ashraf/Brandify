using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shared.DTOs
{
    public class ProjectImagesDto
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public int ImageOrder { get; set; }
    }
}
