using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.ServicesModule
{
    public class Service:BaseEntity<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string? IconUrl { get; set; }
        public ServiceCategory ServiceCategory { get; set; }
        public int? ServiceCategoryId { get; set; }  
    }
}
