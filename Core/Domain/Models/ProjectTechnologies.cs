using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ProjectTechnologies:BaseEntity<int>
    {
        public int ProjectId { get; set; }
        public Project Project{ get; set; }

        public int TechnologiesId { get; set; }
        public Technologies Technologies { get; set; }
    }
}
