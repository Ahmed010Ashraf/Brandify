using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shared.DTOs.serviceDto
{
    public class ServiceDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string? IconUrl { get; set; }
        public int? ServiceCategoryId { get; set; }
    }
}
