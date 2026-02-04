using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
   public class ProjectImages:BaseEntity<int>
    {
        public string ImageUrl { get; set; }
        public int ImageOrder { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }

    }
}
