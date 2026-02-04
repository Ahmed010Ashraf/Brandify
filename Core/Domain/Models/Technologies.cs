using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Technologies:BaseEntity<int>
    {
        public string Name { get; set; }
        public string? IconUrl { get; set; }

        public List<ProjectTechnologies> ProjectTechnologies { get; set; }
    }
}
